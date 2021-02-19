
namespace Interfaz_De_Usuario
{
    partial class MainPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.lblExample = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPressure = new System.Windows.Forms.Button();
            this.btnVisibility = new System.Windows.Forms.Button();
            this.btnWind = new System.Windows.Forms.Button();
            this.btnHumidity = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panMain = new System.Windows.Forms.Panel();
            this.lblSky = new System.Windows.Forms.Label();
            this.lblInformation = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblInformation2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblExample
            // 
            this.lblExample.AutoSize = true;
            this.lblExample.Location = new System.Drawing.Point(109, 72);
            this.lblExample.Name = "lblExample";
            this.lblExample.Size = new System.Drawing.Size(34, 23);
            this.lblExample.TabIndex = 0;
            this.lblExample.Text = "lbl";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPressure);
            this.panel1.Controls.Add(this.btnVisibility);
            this.panel1.Controls.Add(this.btnWind);
            this.panel1.Controls.Add(this.btnHumidity);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(241, 336);
            this.panel1.TabIndex = 1;
            // 
            // btnPressure
            // 
            this.btnPressure.FlatAppearance.BorderSize = 0;
            this.btnPressure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPressure.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnPressure.Image = ((System.Drawing.Image)(resources.GetObject("btnPressure.Image")));
            this.btnPressure.Location = new System.Drawing.Point(0, 258);
            this.btnPressure.Name = "btnPressure";
            this.btnPressure.Size = new System.Drawing.Size(241, 54);
            this.btnPressure.TabIndex = 6;
            this.btnPressure.UseVisualStyleBackColor = true;
            this.btnPressure.Click += new System.EventHandler(this.btnPressure_Click);
            // 
            // btnVisibility
            // 
            this.btnVisibility.FlatAppearance.BorderSize = 0;
            this.btnVisibility.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVisibility.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnVisibility.Image = ((System.Drawing.Image)(resources.GetObject("btnVisibility.Image")));
            this.btnVisibility.Location = new System.Drawing.Point(0, 198);
            this.btnVisibility.Name = "btnVisibility";
            this.btnVisibility.Size = new System.Drawing.Size(241, 54);
            this.btnVisibility.TabIndex = 4;
            this.btnVisibility.UseVisualStyleBackColor = true;
            this.btnVisibility.Click += new System.EventHandler(this.btnVisibility_Click);
            // 
            // btnWind
            // 
            this.btnWind.FlatAppearance.BorderSize = 0;
            this.btnWind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWind.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnWind.Image = ((System.Drawing.Image)(resources.GetObject("btnWind.Image")));
            this.btnWind.Location = new System.Drawing.Point(0, 138);
            this.btnWind.Name = "btnWind";
            this.btnWind.Size = new System.Drawing.Size(241, 54);
            this.btnWind.TabIndex = 3;
            this.btnWind.UseVisualStyleBackColor = true;
            this.btnWind.Click += new System.EventHandler(this.btnWind_Click);
            // 
            // btnHumidity
            // 
            this.btnHumidity.FlatAppearance.BorderSize = 0;
            this.btnHumidity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHumidity.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHumidity.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnHumidity.Image = ((System.Drawing.Image)(resources.GetObject("btnHumidity.Image")));
            this.btnHumidity.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnHumidity.Location = new System.Drawing.Point(3, 80);
            this.btnHumidity.Name = "btnHumidity";
            this.btnHumidity.Size = new System.Drawing.Size(241, 52);
            this.btnHumidity.TabIndex = 2;
            this.btnHumidity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHumidity.UseVisualStyleBackColor = true;
            this.btnHumidity.Click += new System.EventHandler(this.btnHumidity_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(241, 80);
            this.panel3.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "current weather";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Montevideo, Uruguay";
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(241, 239);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(351, 97);
            this.panel2.TabIndex = 2;
            // 
            // panMain
            // 
            this.panMain.Controls.Add(this.lblInformation2);
            this.panMain.Controls.Add(this.lblSky);
            this.panMain.Controls.Add(this.lblInformation);
            this.panMain.Controls.Add(this.lblTitle);
            this.panMain.Location = new System.Drawing.Point(241, 0);
            this.panMain.Name = "panMain";
            this.panMain.Size = new System.Drawing.Size(334, 357);
            this.panMain.TabIndex = 3;
            // 
            // lblSky
            // 
            this.lblSky.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.lblSky.AutoSize = true;
            this.lblSky.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSky.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblSky.Location = new System.Drawing.Point(21, 32);
            this.lblSky.Name = "lblSky";
            this.lblSky.Size = new System.Drawing.Size(64, 30);
            this.lblSky.TabIndex = 8;
            this.lblSky.Text = "Sky, ";
            // 
            // lblInformation
            // 
            this.lblInformation.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.lblInformation.AutoSize = true;
            this.lblInformation.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInformation.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblInformation.Location = new System.Drawing.Point(73, 147);
            this.lblInformation.Name = "lblInformation";
            this.lblInformation.Size = new System.Drawing.Size(0, 22);
            this.lblInformation.TabIndex = 7;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTitle.Location = new System.Drawing.Point(73, 109);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(0, 30);
            this.lblTitle.TabIndex = 4;
            // 
            // lblInformation2
            // 
            this.lblInformation2.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.lblInformation2.AutoSize = true;
            this.lblInformation2.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInformation2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblInformation2.Location = new System.Drawing.Point(74, 171);
            this.lblInformation2.Name = "lblInformation2";
            this.lblInformation2.Size = new System.Drawing.Size(0, 22);
            this.lblInformation2.TabIndex = 9;
            // 
            // MainPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(592, 336);
            this.Controls.Add(this.panMain);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblExample);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainPage";
            this.Text = "MainPage";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panMain.ResumeLayout(false);
            this.panMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblExample;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnHumidity;
        private System.Windows.Forms.Button btnTemperature;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnVisibility;
        private System.Windows.Forms.Button btnWind;
        private System.Windows.Forms.Button btnPressure;
        private System.Windows.Forms.Panel panMain;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblInformation;
        private System.Windows.Forms.Label lblSky;
        private System.Windows.Forms.Label lblInformation2;
    }
}