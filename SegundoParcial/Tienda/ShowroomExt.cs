using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class ShowroomExt
    {
        public static void Restar1Stock(this int stock, int i)
        {
            Showroom.listaStockProductos[i].Stock = stock - 1;
        }
        public static void Aumentar1Stock(int codigoProducto)
        {
            for (int i = 0; i < Showroom.listaStockProductos.Count; i++)
            {
                if (Showroom.listaStockProductos[i].Codigo == codigoProducto)
                {
                    Showroom.listaStockProductos[i].Stock++;
                    break;
                }
            }

        }
    }
}
