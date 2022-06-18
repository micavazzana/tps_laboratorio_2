namespace VistaForm
{
    partial class FrmMails
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
            this.rtbMails = new System.Windows.Forms.RichTextBox();
            this.btnCopiar = new System.Windows.Forms.Button();
            this.btnTraerXml = new System.Windows.Forms.Button();
            this.btnTraerSql = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbMails
            // 
            this.rtbMails.Location = new System.Drawing.Point(12, 46);
            this.rtbMails.Name = "rtbMails";
            this.rtbMails.Size = new System.Drawing.Size(364, 399);
            this.rtbMails.TabIndex = 0;
            this.rtbMails.Text = "";
            // 
            // btnCopiar
            // 
            this.btnCopiar.Location = new System.Drawing.Point(112, 451);
            this.btnCopiar.Name = "btnCopiar";
            this.btnCopiar.Size = new System.Drawing.Size(155, 37);
            this.btnCopiar.TabIndex = 1;
            this.btnCopiar.Text = "Copiar al portapapeles";
            this.btnCopiar.UseVisualStyleBackColor = true;
            this.btnCopiar.Click += new System.EventHandler(this.btnCopiar_Click);
            // 
            // btnTraerXml
            // 
            this.btnTraerXml.Location = new System.Drawing.Point(12, 12);
            this.btnTraerXml.Name = "btnTraerXml";
            this.btnTraerXml.Size = new System.Drawing.Size(179, 23);
            this.btnTraerXml.TabIndex = 2;
            this.btnTraerXml.Text = "Traer Datos desde XML";
            this.btnTraerXml.UseVisualStyleBackColor = true;
            this.btnTraerXml.Click += new System.EventHandler(this.btnTraerXml_Click);
            // 
            // btnTraerSql
            // 
            this.btnTraerSql.Location = new System.Drawing.Point(197, 12);
            this.btnTraerSql.Name = "btnTraerSql";
            this.btnTraerSql.Size = new System.Drawing.Size(179, 23);
            this.btnTraerSql.TabIndex = 3;
            this.btnTraerSql.Text = "Traer desde Base de Datos SQL";
            this.btnTraerSql.UseVisualStyleBackColor = true;
            this.btnTraerSql.Click += new System.EventHandler(this.btnTraerSql_Click);
            // 
            // FrmMails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 500);
            this.Controls.Add(this.btnTraerSql);
            this.Controls.Add(this.btnTraerXml);
            this.Controls.Add(this.btnCopiar);
            this.Controls.Add(this.rtbMails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmMails";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mails Clientes";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbMails;
        private System.Windows.Forms.Button btnCopiar;
        private System.Windows.Forms.Button btnTraerXml;
        private System.Windows.Forms.Button btnTraerSql;
    }
}