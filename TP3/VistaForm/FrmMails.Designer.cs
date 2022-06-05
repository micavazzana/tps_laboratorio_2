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
            this.SuspendLayout();
            // 
            // rtbMails
            // 
            this.rtbMails.Location = new System.Drawing.Point(12, 12);
            this.rtbMails.Name = "rtbMails";
            this.rtbMails.Size = new System.Drawing.Size(356, 399);
            this.rtbMails.TabIndex = 0;
            this.rtbMails.Text = "";
            // 
            // btnCopiar
            // 
            this.btnCopiar.Location = new System.Drawing.Point(114, 420);
            this.btnCopiar.Name = "btnCopiar";
            this.btnCopiar.Size = new System.Drawing.Size(155, 37);
            this.btnCopiar.TabIndex = 1;
            this.btnCopiar.Text = "Copiar al portapapeles";
            this.btnCopiar.UseVisualStyleBackColor = true;
            this.btnCopiar.Click += new System.EventHandler(this.btnCopiar_Click);
            // 
            // FrmMails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 466);
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
    }
}