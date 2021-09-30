using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Configuration;
using System.Collections.Specialized;
using System.Text.RegularExpressions;



namespace ReservationsDolphinDiscoveryII.Clases
{
    public class DataBase
    {
        #region "Atributos"
        private SqlConnection _sqlConnection;
        private SqlTransaction _sqlTransaction = null;
        private static String _connection = "reservacionesEntities";  //Conexion Por Default
        private static String _connectionString = String.Empty;
        private String _connectionStringLocal = String.Empty;
        private int? _connectionTimeout = null;
        #endregion

        #region "Propiedades"
        public static String ConnectionString
        {
            get
            {
                return _connectionString;
            }
        }

        public String ConnectionStringLocal
        {
            get
            {
                return _connectionStringLocal;
            }
        }

        /// <summary>
        /// Se obtiene o se asigna, el nombre de la conexiÃ³n.
        /// </summary>
        public String NameConnection
        {
            get { return _connection; }
            set { _connection = value; }
        }

        /// <summary>
        /// Se asigna el tiempo de espera de la conexiÃ³n.
        /// </summary>
        public int ConnectionTimeout
        {
            set { _connectionTimeout = value; }
        }
        #endregion

        #region "Constructores"

        /// <summary>
        /// Crea la conexion con la conexion estatica 
        /// </summary>
        public DataBase()
        {
            try
            {
                if (_connectionString == String.Empty)
                    _connectionString = ConfigurationManager.ConnectionStrings[_connection].ToString();
                _sqlConnection = new SqlConnection(_connectionString);
            }
            catch (System.Configuration.ConfigurationErrorsException ex)
            {
                throw new Exception("Error en la Clase DataBase: Constructor()", ex);
            }
        }

        /// <summary>
        /// Inicializar la connectionString local
        /// </summary>
        /// <param name="connectionString">nueva cadena de conexión</param> 
        public DataBase(String connectionString)
        {
            _connectionStringLocal = connectionString;
            _sqlConnection = new SqlConnection(connectionString);
        }

        /// <summary>
        /// Inicializa el constructor con un usuario y contraseña.
        /// </summary>
        /// <param name="usuario">Usuario de Base de Datos.</param> 
        /// <param name="password">Password de Base de Datos.</param> 
        public DataBase(String usuario, String password)
        {
            try
            {
                if (_connectionString == String.Empty)
                    _connectionString = ConfigurationManager.ConnectionStrings[_connection].ToString();
                _connectionString = Regex.Replace(_connectionString, @"User ID ?= ?(\w)*;", "User ID=" + usuario + ";");
                _connectionString = Regex.Replace(_connectionString, @"Password ?= ?(\w)*;", "Password=" + password + ";");
                _sqlConnection = new SqlConnection(_connectionString);
            }
            catch (System.Configuration.ConfigurationErrorsException ex)
            {
                throw new Exception("Error en la Clase DataBase: Constructor()", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la Clase DataBase: Constructor()", ex);
            }
        }
        #endregion

        #region "Funciones"          
        /// <summary>
        /// Ejecuta un proceso almacenado y devuelve un DataSet
        /// </summary>
        /// <param name="procedureName">El nombre del proceso almacenado.</param> 
        /// <param name="arguments">Los parámetros de entrada del proceso almacenado.</param> 
        /// <returns></returns>
        public DataSet GetProcedure(String procedureName, ref ParamTable arguments)
        {
            DataSet ds;
            SqlDataAdapter adapter;
            try
            {
                SqlCommand cmd = new SqlCommand(procedureName, _sqlConnection);
                ds = new DataSet();
                //Se valida que si no tiene un tiempo especifico de espera toma el default de 15 seg.
                cmd.CommandTimeout = _connectionTimeout != null ? _connectionTimeout.Value : _sqlConnection.ConnectionTimeout;

                cmd.CommandType = CommandType.StoredProcedure;
                if (_sqlTransaction != null)
                    cmd.Transaction = _sqlTransaction;
                foreach (DictionaryEntry argument in arguments)
                {
                    cmd.Parameters.Add((SqlParameter)argument.Value);
                }

                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                arguments.Clear();
                foreach (SqlParameter param in cmd.Parameters)
                {
                    if (param.Direction.Equals(ParameterDirection.Output))
                    {
                        arguments.Add(param.ParameterName.ToString(), param.Value);
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw new Exception("Error de Base de Datos: GetProcedure()" + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la Clase DataBase: GetProcedure()" + ex.Message, ex);
            }
            return ds;
        }

        /// <summary>
        /// Se ejecuta el procedimiento almacenado y no regresa ningun valor, 
        /// en el parámetro arguments regresa los valores de los parámetros de salida del procedimiento.
        /// </summary>
        /// <param name="procedureName">Nombre del procedimiento almacenado.</param> 
        /// <param name="arguments">Son los parámetros que se le van a pasar al procedimiento, se almacena los parámetros devueltos.</param> 
        public void ExecuteStoreProcedure(String procedureName, ref ParamTable arguments)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(procedureName, _sqlConnection);
                DataSet ds = new DataSet();
                //Se valida que si no tiene un tiempo especifico de espera toma el default de 15 seg.
                cmd.CommandTimeout = _connectionTimeout != null ? _connectionTimeout.Value : _sqlConnection.ConnectionTimeout;
                cmd.CommandType = CommandType.StoredProcedure;
                if (_sqlTransaction != null)
                    cmd.Transaction = _sqlTransaction;

                foreach (DictionaryEntry argument in arguments)
                {
                    cmd.Parameters.Add((SqlParameter)argument.Value);
                }

                if (_sqlTransaction == null)
                    _sqlConnection.Open();
                cmd.ExecuteNonQuery();
                arguments.Clear();
                foreach (SqlParameter param in cmd.Parameters)
                {
                    if (param.Direction.Equals(ParameterDirection.Output))
                    {
                        arguments.Add(param.ParameterName.ToString(), param.Value);
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw new Exception("Error de Base de Datos: ExecuteStoreProcedure() " + ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la Clase DataBase: ExecuteStoreProcedure() " + ex);
            }
            finally
            {
                if (_sqlTransaction == null)
                    _sqlConnection.Close();
            }
        }

        /// <summary>
        /// Se utiliza para inicializar un transaccion.
        /// </summary>
        public void BeginTransaction()
        {
            try
            {
                if (_sqlConnection.State == ConnectionState.Closed)
                    _sqlConnection.Open();
                _sqlTransaction = _sqlConnection.BeginTransaction();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw new Exception("Error de Base de Datos: BeginTransaction()", ex);
            }
            catch (System.InvalidOperationException ex)
            {
                throw new Exception("Error de Base de Datos: BeginTransaction()", ex);
            }
        }

        /// <summary>
        /// Se utiliza para aplicar todas las transacciones. 
        /// </summary>
        public void Commit()
        {
            try
            {
                if (_sqlTransaction.Connection != null)
                {
                    _sqlTransaction.Commit();
                    _sqlTransaction = null;
                }
            }
            catch (System.NullReferenceException ex)
            {
                throw new Exception("Error de Base de Datos: Commit():la variable _sqlTransaction es NULL", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error de Base de Datos: Commit()", ex);
            }
            finally
            {
                if (_sqlConnection.State == ConnectionState.Open)
                    _sqlConnection.Close();
            }
        }

        /// <summary>
        /// Se utiliza para desacer todas las transacciones que se realizaron.
        /// </summary>
        public void RollBack()
        {
            try
            {
                if (_sqlTransaction != null)
                {
                    if (_sqlTransaction.Connection != null)
                    {
                        _sqlTransaction.Rollback();
                        _sqlTransaction = null;
                    }
                }
            }
            catch (System.NullReferenceException ex)
            {
                throw new Exception("Error de Base de Datos: RollBack(): la variable _sqlTransaction es NULL", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error de Base de Datos: RollBack()", ex);
            }
            finally
            {
                if (_sqlConnection.State == ConnectionState.Open)
                    _sqlConnection.Close();
            }
        }

        #endregion

    }
}