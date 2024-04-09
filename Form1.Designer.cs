namespace Db
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgv = new DataGridView();
            lblAppYear = new Label();
            lblAppVersion = new Label();
            lblAppRoute = new Label();
            btnUp = new Button();
            txtDatoNow = new TextBox();
            lblDato = new Label();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            SuspendLayout();
            // 
            // dgv
            // 
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Location = new Point(13, 302);
            dgv.Name = "dgv";
            dgv.RowTemplate.Height = 25;
            dgv.Size = new Size(1303, 222);
            dgv.TabIndex = 20;
            // 
            // lblAppYear
            // 
            lblAppYear.AutoSize = true;
            lblAppYear.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblAppYear.ForeColor = Color.Blue;
            lblAppYear.Location = new Point(13, 240);
            lblAppYear.Name = "lblAppYear";
            lblAppYear.Size = new Size(125, 32);
            lblAppYear.TabIndex = 19;
            lblAppYear.Text = "AppYear: ";
            // 
            // lblAppVersion
            // 
            lblAppVersion.AutoSize = true;
            lblAppVersion.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblAppVersion.ForeColor = Color.Blue;
            lblAppVersion.Location = new Point(13, 191);
            lblAppVersion.Name = "lblAppVersion";
            lblAppVersion.Size = new Size(160, 32);
            lblAppVersion.TabIndex = 18;
            lblAppVersion.Text = "AppVersion: ";
            // 
            // lblAppRoute
            // 
            lblAppRoute.AutoSize = true;
            lblAppRoute.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblAppRoute.ForeColor = Color.Blue;
            lblAppRoute.Location = new Point(13, 143);
            lblAppRoute.Name = "lblAppRoute";
            lblAppRoute.Size = new Size(142, 32);
            lblAppRoute.TabIndex = 17;
            lblAppRoute.Text = "AppRoute: ";
            // 
            // btnUp
            // 
            btnUp.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            btnUp.ForeColor = Color.Blue;
            btnUp.Location = new Point(623, 81);
            btnUp.Name = "btnUp";
            btnUp.Size = new Size(110, 45);
            btnUp.TabIndex = 16;
            btnUp.Text = "Up";
            btnUp.UseVisualStyleBackColor = true;
            btnUp.Click += btnUp_Click;
            // 
            // txtDatoNow
            // 
            txtDatoNow.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            txtDatoNow.ForeColor = Color.Blue;
            txtDatoNow.Location = new Point(13, 84);
            txtDatoNow.Name = "txtDatoNow";
            txtDatoNow.Size = new Size(583, 39);
            txtDatoNow.TabIndex = 15;
            // 
            // lblDato
            // 
            lblDato.AutoSize = true;
            lblDato.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblDato.ForeColor = Color.Blue;
            lblDato.Location = new Point(13, 12);
            lblDato.Name = "lblDato";
            lblDato.Size = new Size(83, 32);
            lblDato.TabIndex = 14;
            lblDato.Text = "Dato: ";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1328, 537);
            Controls.Add(dgv);
            Controls.Add(lblAppYear);
            Controls.Add(lblAppVersion);
            Controls.Add(lblAppRoute);
            Controls.Add(btnUp);
            Controls.Add(txtDatoNow);
            Controls.Add(lblDato);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgv;
        private Label lblAppYear;
        private Label lblAppVersion;
        private Label lblAppRoute;
        private Button btnUp;
        private TextBox txtDatoNow;
        private Label lblDato;
    }
}