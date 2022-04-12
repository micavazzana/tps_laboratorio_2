using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
           Limpiar();
        }
        private void Limpiar()
        {
            this.txtBoxNumero1.Clear();
            this.txtBoxNumero2.Clear();
            this.cmbOperador.Text = String.Empty;
            this.lblResultado.Text = String.Empty;
        }

        private static double Operar(string numero1, string numero2, char operador)
        {
            Operando operando1 = new Operando(numero1);
            Operando operando2 = new Operando(numero2);
            return Calculadora.Operar(operando1,operando2,operador);
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void btnOperar_Click(object sender, EventArgs e)
        {
            char operador;
            char.TryParse(cmbOperador.Text, out operador);
            double resultado = FormCalculadora.Operar(this.txtBoxNumero1.Text, this.txtBoxNumero2.Text,operador);
            this.lblResultado.Text = resultado.ToString();
            //this.lstOperaciones.Text = $"{this.txtBoxNumero1.Text} {this.cmbOperador.Text} {this.txtBoxNumero2} = {resultado.ToString()}";
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = new Operando().DecimalBinario(this.lblResultado.Text);
        }
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = new Operando().BinarioDecimal(this.lblResultado.Text);
        }

        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult resultado = MessageBox.Show("¿Está seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado != DialogResult.Yes)
                {
                    e.Cancel = true;//esto impide que cierre el form
                }
            }
        }
    }
}
