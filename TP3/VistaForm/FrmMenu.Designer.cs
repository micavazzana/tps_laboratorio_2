namespace VistaForm
{
    partial class FrmMenu
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
            this.components = new System.ComponentModel.Container();
            this.btnRealizarReserva = new System.Windows.Forms.Button();
            this.btnReservas = new System.Windows.Forms.Button();
            this.btnMails = new System.Windows.Forms.Button();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.picBoxLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRealizarReserva
            // 
            this.btnRealizarReserva.Location = new System.Drawing.Point(27, 127);
            this.btnRealizarReserva.Name = "btnRealizarReserva";
            this.btnRealizarReserva.Size = new System.Drawing.Size(228, 45);
            this.btnRealizarReserva.TabIndex = 1;
            this.btnRealizarReserva.Text = "Realizar Reserva";
            this.btnRealizarReserva.UseVisualStyleBackColor = true;
            this.btnRealizarReserva.Click += new System.EventHandler(this.btnRealizarReserva_Click);
            // 
            // btnReservas
            // 
            this.btnReservas.Location = new System.Drawing.Point(27, 178);
            this.btnReservas.Name = "btnReservas";
            this.btnReservas.Size = new System.Drawing.Size(228, 45);
            this.btnReservas.TabIndex = 2;
            this.btnReservas.Text = "Reservas Realizadas";
            this.btnReservas.UseVisualStyleBackColor = true;
            this.btnReservas.Click += new System.EventHandler(this.btnReservas_Click);
            // 
            // btnMails
            // 
            this.btnMails.Location = new System.Drawing.Point(27, 229);
            this.btnMails.Name = "btnMails";
            this.btnMails.Size = new System.Drawing.Size(228, 45);
            this.btnMails.TabIndex = 4;
            this.btnMails.Text = "Mails Clientes";
            this.btnMails.UseVisualStyleBackColor = true;
            this.btnMails.Click += new System.EventHandler(this.btnMails_Click);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // picBoxLogo
            // 
            this.picBoxLogo.Image = global::VistaForm.Properties.Resources.Isologo_horizontal_2;
            this.picBoxLogo.Location = new System.Drawing.Point(27, 22);
            this.picBoxLogo.Name = "picBoxLogo";
            this.picBoxLogo.Size = new System.Drawing.Size(228, 99);
            this.picBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxLogo.TabIndex = 5;
            this.picBoxLogo.TabStop = false;
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 289);
            this.Controls.Add(this.picBoxLogo);
            this.Controls.Add(this.btnMails);
            this.Controls.Add(this.btnReservas);
            this.Controls.Add(this.btnRealizarReserva);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMenu";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnRealizarReserva;
        private System.Windows.Forms.Button btnReservas;
        private System.Windows.Forms.Button btnMails;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.PictureBox picBoxLogo;
    }
}
