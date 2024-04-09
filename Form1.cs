using Db.Tools;
using System.Data;

namespace Db
{
    public partial class Form1 : Form
    {
        DbCon _dbCon = new DbCon(Data.Chain1);
        Logger _logger = new Logger();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblDato.Text = Data.AppName;
            lblAppRoute.Text = Data.AppRoute;
            lblAppVersion.Text = Data.AppVersion;
            lblAppYear.Text = Data.AppYear;

            string query = "SELECT [Id], [Name], [Mobile] " +
                            "FROM [Test].[dbo].[TableTest]";
            DataTable dt;

            if (_dbCon.SelectDataTable(query, out dt))
            {
                dgv.DataSource = dt;
                _logger.TrAcE(1, "Form1", 29, "Se carga en dgv la query: " + query);
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            Data.AppName = txtDatoNow.Text;
            lblDato.Text = "Dato : " + txtDatoNow.Text;

            _logger.TrAcE(1, "Form1", 38, "Hemos grabado en AppName = Dato: " + txtDatoNow.Text);
        }
    }
}