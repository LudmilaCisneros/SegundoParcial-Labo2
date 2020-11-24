using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public sealed class Maquillaje : Producto
    {

        #region Atributos

        private string subTipo;

        #endregion


        #region Propiedades
        public string SubTipoMaq { get { return this.subTipo; } set { this.subTipo = value; } }

        #endregion

        #region Constructores

        public Maquillaje()
        {

        }
        public Maquillaje(string nombre, EColor color, float precio, int codigo, ETipo tipo, int stock, string subTipo) 
            : base(nombre, color, precio, codigo, tipo,stock)
        {
            this.subTipo = subTipo;
        }
        #endregion

        #region Métodos
        public override string ObtenerSubtipo()
        {
            return this.SubTipoMaq;
        }
        /// <summary>
        /// Genera toda la info de un maquillaje
        /// </summary>
        /// <returns>string con la informacion</returns>
        public override string GenerarInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.GenerarInfo());
            sb.AppendLine("TIPO: " + this.subTipo);

            return sb.ToString();
        }

        #endregion
    }
}