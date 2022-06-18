using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Entidades
{
    /// <summary>
    /// Clase que va a gestionar la lectura y escritura de los clientes de la base de datos enchulame_db
    /// </summary>
    public class GestorSqlCliente
    {
        private static string connectionString;

        /// <summary>
        /// Constructor que carga "connectionString" inicializandolo con la informacion para la conexion
        /// </summary>
        static GestorSqlCliente()
        {
            GestorSqlCliente.connectionString = "Server=.;Database=enchulame_db;Trusted_Connection=True;";
        }

        /// <summary>
        /// Establece la conexion con la base de datos
        /// Carga una lista de clientes con los datos que contiene la base de datos
        /// No contiene parametros de entrada
        /// </summary>
        /// <returns>Una lista de clientes con todos los datos de los clientes</returns>
        /// <exception cref="SqlException">Arroja una excepcion que contendra la primer excepcion que se haya producido</exception>
        public static List<Cliente> LeerDatos()
        {
            List<Cliente> listaClientes = new List<Cliente>();
            string query = "select * from clientes";
            try
            {
                using (SqlConnection connection = new SqlConnection(GestorSqlCliente.connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string nombre = reader.GetString(0);
                        string apellido = reader.GetString(1);
                        string dni = reader.GetString(2);
                        DateTime fecha = reader.GetDateTime(3);
                        string mail = reader.GetString(4);
                        int idReserva = reader.GetInt32(5);
                        bool esEstudiante = reader.GetBoolean(6);
                        Cliente cliente = new Cliente(nombre, apellido, dni, fecha, mail);
                        cliente.IdReserva = idReserva;
                        cliente.EsEstudiante = esEstudiante;
                        listaClientes.Add(cliente);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new SqlException("Error al leer los datos del cliente de la base de datos sql", ex);
            }
            return listaClientes;
        }
        /// <summary>
        /// Realiza el alta de un nuevo cliente y lo agrega a la base de datos
        /// </summary>
        /// <param name="cliente">Cliente que se da de alta</param>
        /// <exception cref="SqlException">Arroja una excepcion que contendra la primer excepcion que se haya producido</exception>
        public static void AltaCliente(Cliente cliente)
        {
            string query = "insert into clientes (nombre, apellido, dni, fechaReserva, mail, esEstudiante) " +
                "values (@nombre, @apellido, @dni, @fechaReserva, @mail, @esEstudiante)";
            try
            {
                using (SqlConnection connection = new SqlConnection(GestorSqlCliente.connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("nombre", cliente.Nombre);
                    cmd.Parameters.AddWithValue("apellido", cliente.Apellido);
                    cmd.Parameters.AddWithValue("dni", cliente.Dni);
                    cmd.Parameters.AddWithValue("fechaReserva", cliente.FechaReserva);
                    cmd.Parameters.AddWithValue("mail", cliente.Mail);
                    cmd.Parameters.AddWithValue("esEstudiante", cliente.EsEstudiante);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new SqlException("Error dar de alta un cliente en al base de datos sql", ex);
            }
        }
        /// <summary>
        /// Establece la conexion con la base de datos
        /// Carga una lista de mails con el dato mail que contiene la base de datos
        /// No contiene parametros de entrada
        /// </summary>
        /// <returns>Lista de emails de los clientes</returns>
        /// <exception cref="SqlException">Arroja una excepcion que contendra la primer excepcion que se haya producido</exception>
        public static List<string> LeerMailsSinDuplicados()
        {
            List<string> listaMails = new List<string>();
            string query = "select mail from clientes group by mail";
            try
            {
                using (SqlConnection connection = new SqlConnection(GestorSqlCliente.connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string mail = reader.GetString(0);
                        listaMails.Add(mail);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new SqlException("Error al leer los mails de la base de datos sql", ex);
            }
            return listaMails;
        }
    }
}