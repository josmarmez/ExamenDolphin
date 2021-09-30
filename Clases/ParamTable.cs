using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace ReservationsDolphinDiscoveryII.Clases
{
  
        public class ParamTable : Hashtable
        {
            public ParamTable(int i)
                : base(i)
            {

            }

            /// <summary>
            /// Agrega un parámetro de entrada a la tabla de parámetros
            /// </summary>
            /// <param name="key">La llave del elemento que se agregará</param>
            /// <param name="value">El valor del elemento que se agregará</param>
            public override void Add(object key, object value)
            {
                try
                {
                    SqlParameter parametros;
                    if (value == null || value.ToString() == String.Empty)
                        parametros = new SqlParameter(key.ToString(), DBNull.Value);
                    else
                        parametros = new SqlParameter(key.ToString(), value);
                    parametros.Direction = ParameterDirection.Input;


                    base.Add(key.ToString(), parametros);
                }
                catch (System.Exception ex)
                {
                    throw new Exception("Error en la Clase ParamTable: Add()", ex);
                }


            }
            /// <summary>
            /// Agerga un parámetro de salida a la tabla de parámetros
            /// </summary>
            /// <param name="key">La llave del elemento que se agregará</param>
            /// <param name="tipoParametro">El tipo de datos que recibirá el parámetro</param>
            public void AddOut(object key, SqlDbType tipoParametro)
            {
                try
                {
                    SqlParameter parametros;
                    parametros = new SqlParameter(key.ToString(), tipoParametro);
                    parametros.Direction = ParameterDirection.Output;
                    base.Add(key.ToString(), parametros);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error en la Clase ParamTable: AddOut()", ex);
                }
            }
            /// <summary>
            /// Agerga un parÃ¡metro de salida a la tabla de parÃ¡metros, indicando la longitud
            /// </summary>
            /// <param name="key">La llave del elemento que se agregarÃ¡</param>
            /// <param name="tipoParametro">El tipo de datos que recibirÃ¡ el parÃ¡metro</param>
            /// <param name="size">La longitud de tipo de dato.</param>
            public void AddOut(object key, SqlDbType tipoParametro, int size)
            {
                try
                {
                    SqlParameter parametros;
                    parametros = new SqlParameter(key.ToString(), tipoParametro, size);
                    parametros.Direction = ParameterDirection.Output;
                    base.Add(key.ToString(), parametros);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error en la Clase ParamTable: AddOut()", ex);

                }
            }
        }
    
}