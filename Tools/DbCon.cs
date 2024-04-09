using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Db.Tools
{
    public class DbCon
    {
        private readonly string connection = string.Empty;
        private readonly SqlConnection connect;

        private SqlCommand command;
        private SqlDataAdapter da;
        private DataTable dt;
        private DataSet ds;

        public DbCon(string chain)
        {
            connection = chain;
            connect = new SqlConnection(connection);
        }

        private SqlConnection ConnectToDb()
        {
            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return connect;
        }
        private void CloseConnection()
        {
            if (connect.State != ConnectionState.Closed) connect.Close();
        }
        public string SelectString(string query)
        {
            string chain = string.Empty;

            try
            {
                ConnectToDb();
                command = new SqlCommand(query, connect);
                var firstColumn = command.ExecuteScalar();

                if (firstColumn != null)
                {
                    chain = firstColumn.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                chain = string.Empty;
            }
            finally
            {
                CloseConnection();
            }
            return chain;
        }
        public bool ExecuteCommand(string query)
        {
            bool success = false;
            try
            {
                ConnectToDb();
                command = new SqlCommand(query, connect);
                command.ExecuteNonQuery();
                success = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                success = false;
            }
            finally
            {
                CloseConnection();
            }
            return success;
        }
        public bool ExecuteMultiCommand(string query)
        {
            bool success = false;

            try
            {
                string[] commands = query.Split(new string[] { Environment.NewLine + "GO" + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                ConnectToDb();

                foreach (string cmd in commands)
                {
                    command = new SqlCommand(cmd, connect);
                    command.ExecuteNonQuery();
                }
                success = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                success = false;
            }
            finally
            {
                CloseConnection();
            }
            return success;
        }
        public object ExecuteScalar(string query)
        {
            object result = null;

            try
            {
                ConnectToDb();
                command = new SqlCommand(query, connect);
                result = command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseConnection();
            }

            return result;
        }
        public DataTable SelectDataTable(string query)
        {
            dt = new DataTable();
            try
            {
                dt = new DataTable();
                try
                {
                    ConnectToDb();
                    da = new SqlDataAdapter(query, connect);
                    da.Fill(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    ConnectToDb();
                }
                return dt;
            }
            catch
            {

            }
            finally
            {

                CloseConnection();
            }
            return dt;
        }
        public bool SelectDataTable(string query, out DataTable dataTable)
        {
            bool result = false;
            dt = new DataTable();

            try
            {
                ConnectToDb();
                da = new SqlDataAdapter(query, connect);
                da.Fill(dt);

                if (dt != null)
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseConnection();
            }
            dataTable = dt;
            return result;
        }
        public DataSet SelectDataSet(string query, string table)
        {
            ds = new DataSet();

            try
            {
                ConnectToDb();
                da = new SqlDataAdapter(query, connect);
                da.Fill(ds, table);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseConnection();
            }
            return ds;

        }
        public string ReadCell(string sql, string column)
        {
            string value = null;
            try
            {
                ConnectToDb();
                command = new SqlCommand(sql, connect);

                SqlDataReader read = command.ExecuteReader();

                if (read.Read())
                {
                    //índice de la columna del nombre indicado
                    int columnIndex = read.GetOrdinal(column);

                    // Verificar si el índice es válido (-1 si no existe)
                    if (columnIndex != -1)
                    {
                        value = read[columnIndex].ToString();
                    }
                    else
                    {
                        // La columna no existe = null
                        value = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseConnection();
            }

            return value;
        }
        public string IdNext(string table)
        {
            //id
            string consult = "";
            string id_new = "";
            int Id = 0;

            try
            {
                ConnectToDb();
                command = new SqlCommand("select MAX (Id) from " + table + "", connect);
                consult = command.ExecuteScalar().ToString();

                Id = int.Parse(consult);
                id_new = Convert.ToString(Id + 1);
            }
            catch { }

            CloseConnection();

            if (id_new == "") id_new = "1";
            return id_new;
        }
        public bool ExecuteStoreProcedure(string namestoreprocedure)
        {
            try
            {
                ConnectToDb();
                command = new SqlCommand(namestoreprocedure, connect);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }
        public DataTable SelectDataTableFromStoreProcedure(string namestoreprocedure)
        {
            dt = new DataTable();
            try
            {
                ConnectToDb();
                command = new SqlCommand(namestoreprocedure, connect);//
                command.CommandType = CommandType.StoredProcedure;
                dt = new DataTable();
                da = new SqlDataAdapter();
                da.SelectCommand = command;
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseConnection();
            }
            return dt;
        }
    }
}


