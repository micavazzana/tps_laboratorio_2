namespace VistaForm
{
    partial class FrmReservas
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
            this.btnModificarReserva = new System.Windows.Forms.Button();
            this.lstReservas = new System.Windows.Forms.ListBox();
            this.btnEliminarReserva = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnModificarReserva
            // 
            this.btnModificarReserva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModificarReserva.Location = new System.Drawing.Point(386, 307);
            this.btnModificarReserva.Name = "btnModificarReserva";
            this.btnModificarReserva.Size = new System.Drawing.Size(129, 37);
            this.btnModificarReserva.TabIndex = 1;
            this.btnModificarReserva.Text = "Modificar";
            this.btnModificarReserva.UseVisualStyleBackColor = true;
            this.btnModificarReserva.Click += new System.EventHandler(this.btnModificarReserva_Click);
            // 
            // lstReservas
            // 
            this.lstReservas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstReservas.FormattingEnabled = true;
            this.lstReservas.ItemHeight = 15;
            this.lstReservas.Location = new System.Drawing.Point(12, 12);
            this.lstReservas.Name = "lstReservas";
            this.lstReservas.Size = new System.Drawing.Size(636, 289);
            this.lstReservas.TabIndex = 2;
            // 
            // btnEliminarReserva
            // 
            this.btnEliminarReserva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminarReserva.Location = new System.Drawing.Point(521, 307);
            this.btnEliminarReserva.Name = "btnEliminarReserva";
            this.btnEliminarReserva.Size = new System.Drawing.Size(129, 37);
            this.btnEliminarReserva.TabIndex = 3;
            this.btnEliminarReserva.Text = "Eliminar";
            this.btnEliminarReserva.UseVisualStyleBackColor = true;
            this.btnEliminarReserva.Click += new System.EventHandler(this.btnEliminarReserva_Click);
            // 
            // FrmReservas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 356);
            this.Controls.Add(this.btnEliminarReserva);
            this.Controls.Add(this.lstReservas);
            this.Controls.Add(this.btnModificarReserva);
            this.Name = "FrmReservas";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reservas realizadas";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnModificarReserva;
        private System.Windows.Forms.ListBox lstReservas;
        private System.Windows.Forms.Button btnEliminarReserva;
    }
}