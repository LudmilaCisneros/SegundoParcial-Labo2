using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Excepciones;
using Archivos;

namespace Entidades
{
    public static class DAO
    {
        static SqlConnection conexion;
        static DAO()
        {
            conexion = new SqlConnection("Data Source=.\\sqlExpress; Initial Catalog=Showroom;Integrated Security=True");
        }
        //public static string ObtenerConnectionString()
        //{
        //    Texto auxTxt = new Texto();
        //    string path = AppDomain.CurrentDomain.BaseDirectory + "ConnectionString.txt";
        //    string datos;
        //    auxTxt.Leer(path, out datos);

        //    return CorregirConnection(datos);
        //}
        //public static string CorregirConnection(string datos)
        //{

        //    string aux = datos.Substring(0,15);
        //    return aux + datos.Substring(17);
        //}
        public static List<Producto> ObtenerStockDeBD()
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT * FROM Stock";
                conexion.Open();//conecta al server
                SqlDataReader dato = comando.ExecuteReader();//devuelve el resultado de la query

                while (dato.Read())
                {
                    switch (dato["Tipo"].ToString())
                    {
                        //Accesorios
                        case "accesorios":
                            Showroom.listaStockProductos.Add(new Accesorios(dato["Nombre"].ToString(),
                            (Producto.EColor)Enum.Parse(typeof(Producto.EColor), dato["Color"].ToString()),
                            float.Parse(dato["Precio"].ToString()),
                            int.Parse(dato["Código"].ToString()),
                            (Producto.ETipo)Enum.Parse(typeof(Producto.ETipo), dato["Tipo"].ToString()),
                            int.Parse(dato["Stock"].ToString()),
                            /*(Accesorios.ESubTipoAcc)Enum.Parse(typeof(Accesorios.ESubTipoAcc), dato["Subtipo"].ToString())));*/
                            dato["Subtipo"].ToString()));
                            break;


                        case "maquillaje":
                            Showroom.listaStockProductos.Add(new Maquillaje(dato["Nombre"].ToString(),
                            (Producto.EColor)Enum.Parse(typeof(Producto.EColor), dato["Color"].ToString()),
                            float.Parse(dato["Precio"].ToString()),
                            int.Parse(dato["Código"].ToString()),
                            (Producto.ETipo)Enum.Parse(typeof(Producto.ETipo), dato["Tipo"].ToString()),
                            int.Parse(dato["Stock"].ToString()),
                            dato["Subtipo"].ToString()));
                            //(Maquillaje.ESubTipoMaq) Enum.Parse (typeof(Maquillaje.ESubTipoMaq), dato["Subtipo"].ToString())));
                            break;
                    }
                }
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw new ErrorBDException(ex);
            }

            return Showroom.listaStockProductos;
        }

    }
}