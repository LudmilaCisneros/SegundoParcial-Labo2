using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Archivos;

namespace Entidades
{
    [Serializable]
    public sealed class Cliente
    {
        private string nombre;
        public List<Producto> carritoCliente;

        public Cliente()
        {
            carritoCliente = new List<Producto>();

        }

        public Cliente(List<Producto> carritoCliente) :this()
        {
            this.carritoCliente.AddRange(carritoCliente);
        }
        public Cliente(List<Producto> carritoCliente,string nombre) :this(carritoCliente)
        {
            this.nombre = nombre;
        }

        /// <summary>
        /// Propiedad Nombre
        /// </summary>
        public string Nombre { get { return this.nombre; } set { this.nombre = value; } }
        
        public void EliminarProductoCarrito(int codigoProducto)
        {
            for (int i = 0; i < this.carritoCliente.Count; i++)
            {
                if(this.carritoCliente[i].Codigo == codigoProducto)
                {
                    this.carritoCliente.RemoveAt(i);
                }
            }

        }
        /// <summary>
        /// Devuelve el nombre a mostrar
        /// </summary>
        /// <returns></returns>
        public string MostrarVenta()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat($"::. CLIENTE: {this.Nombre}");

            return sb.ToString();
        }
        public static string ObtenerNombreCte(string itemSeleccionado)
        {
            return itemSeleccionado.Substring(13);
        }

    }
}
