using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public sealed class Accesorios : Producto
    {
        #region Atributos

        private string subTipo;

        #endregion

        #region Propiedades

        public string SubTipoAcc { get { return this.subTipo; } set { this.subTipo = value; } }

        #endregion


        #region Constructores
        public Accesorios()
        {

        }
        public Accesorios(string nombre, EColor color, float precio, int codigo, ETipo tipo, int stock, string subTipo) : base(nombre, color, precio, codigo, tipo, stock)
        {
            this.subTipo = subTipo;
        }

        #endregion


        #region Métodos

        public override string ObtenerSubtipo()
        {
            return this.SubTipoAcc;
        }
        /// <summary>
        /// Genera toda la info de un accesorio
        /// </summary>
        /// <returns>string con la informacion</returns>
        public override string GenerarInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.GenerarInfo());
            sb.AppendLine("TIPO: " + this.subTipo);

            return sb.ToString();
        }

        ///// <summary>
        ///// Método que me permite comprar
        ///// </summary>
        //public string GenerarTicket()
        //{
        //    StringBuilder sb = new StringBuilder();

        //    sb.AppendLine($"CÓDIGO: {this.Codigo}");
        //    sb.AppendLine($"NOMBRE: {this.Nombre}");
        //    sb.AppendLine($"COLOR: {this.Color}");
        //    sb.AppendLine($"PRECIO: {this.Precio}");
        //    sb.AppendLine("TIPO: " + this.tipodeAccesorio);

        //    return sb.ToString();
        //}
        #endregion




    }
}
