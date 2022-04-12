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
        /// <summary>
        /// Constructor de FormCalculadora que inicializa el form
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Evento que se ejecuta al iniciar el formulario.
        /// Limpia el valor de los campos invocando al método Limpiar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
           Limpiar();
        }
        /// <summary>
        /// Asigna un string vacio a cada textBox, ComboBox y Label Resultado
        /// </summary>
        private void Limpiar()
        {
            this.txtBoxNumero1.Clear();
            this.txtBoxNumero2.Clear();
            this.cmbOperador.Text = String.Empty;
            this.lblResultado.Text = String.Empty;
        }
        /// <summary>
        /// Invoca al metodo Operar que realiza una operacion matematica entre dos numeros
        /// </summary>
        /// <param name="numero1">Objeto de tipo Operando</param>
        /// <param name="numero2">Objeto de tipo Operando</param>
        /// <param name="operador">Operador aritmetico elegido</param>
        /// <returns></returns>
        private static double Operar(string numero1, string numero2, char operador)
        {
            Operando operando1 = new Operando(numero1);
            Operando operando2 = new Operando(numero2);
            return Calculadora.Operar(operando1,operando2,operador);
        }
        /// <summary>
        /// Limpia el valor de los campos invocando al método Limpiar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        /// <summary>
        /// Realiza una operacion matemática con los numeros ingresados en txtBoxNumero1 y txtBoxNumero2
        /// Utiliza el operador elegido en el cmbOperador
        /// Asigna el resultado en lblResultado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            char operador;
            char.TryParse(cmbOperador.Text, out operador);
            double resultado = FormCalculadora.Operar(this.txtBoxNumero1.Text, this.txtBoxNumero2.Text, operador);
            this.lblResultado.Text = resultado.ToString();
            this.lstOperaciones.Items.Add($"{this.txtBoxNumero1.Text} {this.cmbOperador.Text} {this.txtBoxNumero2.Text} = {resultado.ToString()}");
        }
        /// <summary>
        /// Cierra el formulario. Utiliza el evento Form Closing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Convierte el resultado a su representacion en binario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = new Operando().DecimalBinario(this.lblResultado.Text);
        }
        /// <summary>
        /// Convierte el resultado a su representacion en decimal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = new Operando().BinarioDecimal(this.lblResultado.Text);
        }
        /// <summary>
        /// Antes de cerrar pregunta si esta seguro de querer salir.
        /// De ser "si" cierra el formulario, de los contrario el formulario continua ejecutandose.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult resultado = MessageBox.Show("¿Está seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.No)
                {
                    e.Cancel = true;//esto impide que cierre el form, se fija si el evento tiene q ser cancelado o no
                }
            }
        }
    }
}
