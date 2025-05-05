namespace Sapi
{
    partial class dasboard
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.logout = new System.Windows.Forms.Button();
            this.datapakan = new System.Windows.Forms.Button();
            this.datasapi = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(161, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(381, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pendataan Sapi";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-2, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(709, 99);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(3, 97);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(211, 357);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Moccasin;
            this.panel3.Controls.Add(this.logout);
            this.panel3.Controls.Add(this.datapakan);
            this.panel3.Controls.Add(this.datasapi);
            this.panel3.Location = new System.Drawing.Point(-1, 98);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(213, 351);
            this.panel3.TabIndex = 2;
            // 
            // logout
            // 
            this.logout.BackColor = System.Drawing.Color.Crimson;
            this.logout.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logout.ForeColor = System.Drawing.Color.White;
            this.logout.Location = new System.Drawing.Point(49, 291);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(97, 33);
            this.logout.TabIndex = 4;
            this.logout.Text = "Logout";
            this.logout.UseVisualStyleBackColor = false;
            this.logout.Click += new System.EventHandler(this.button3_Click);
            // 
            // datapakan
            // 
            this.datapakan.BackColor = System.Drawing.Color.PaleGreen;
            this.datapakan.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datapakan.Location = new System.Drawing.Point(13, 92);
            this.datapakan.Name = "datapakan";
            this.datapakan.Size = new System.Drawing.Size(179, 34);
            this.datapakan.TabIndex = 3;
            this.datapakan.Text = "Tambah Data Pakan";
            this.datapakan.UseVisualStyleBackColor = false;
            this.datapakan.Click += new System.EventHandler(this.button2_Click);
            // 
            // datasapi
            // 
            this.datasapi.BackColor = System.Drawing.Color.PaleGreen;
            this.datasapi.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datasapi.Location = new System.Drawing.Point(13, 40);
            this.datasapi.Name = "datasapi";
            this.datasapi.Size = new System.Drawing.Size(179, 34);
            this.datasapi.TabIndex = 0;
            this.datasapi.Text = "Tambah Data Sapi";
            this.datasapi.UseVisualStyleBackColor = false;
            this.datasapi.Click += new System.EventHandler(this.button1_Click);
            // 
            // dasboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.IndianRed;
            this.ClientSize = new System.Drawing.Size(706, 447);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "dasboard";
            this.Text = "dasboard";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button logout;
        private System.Windows.Forms.Button datapakan;
        private System.Windows.Forms.Button datasapi;
    }
}