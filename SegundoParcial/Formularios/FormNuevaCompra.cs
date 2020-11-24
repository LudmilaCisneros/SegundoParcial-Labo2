using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Archivos;


namespace Formularios
{
    public partial class FormNuevaCompra : Form
    {
        private Cliente miCliente;

        public FormNuevaCompra()
        {
            InitializeComponent();
            miCliente = new Cliente();
        }

        private void FormNuevaCompra_Load(object sender, EventArgs e)
        {
            try
            {
                if (Showroom.listaStockProductos.Count > 0)
                {
                     //guarda los datos de la bd en la lista de stock
                    dtgvStock.DataSource = null;
                    dtgvStock.DataSource = Showroom.listaStockProductos;
                }
                else
                {
                    DAO.ObtenerStockDeBD();
                    dtgvStock.DataSource = null;
                    dtgvStock.DataSource = Showroom.listaStockProductos;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DataGridViewRow db = dtgvStock.CurrentRow;
            DataGridViewCellCollection coleccionCeldas = db.Cells;

            {
                if (!CargarProductoAListaCarrito(coleccionCeldas))
                {
                    MessageBox.Show("No hay stock", "Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);//exception
                }
                else
                {
                    dtgvStock.DataSource = null;
                    dtgvStock.DataSource = Showroom.listaStockProductos;
                    dtgvCarrito.DataSource = null;
                    dtgvCarrito.DataSource = miCliente.carritoCliente;
                }
            }
        }
        /// <summary>
        /// Agrega la fila del drgv a la lista carrito
        /// </summary>
        /// <param name="coleccionDeCeldasSelect"></param>
        /// <returns></returns>
        private bool CargarProductoAListaCarrito(DataGridViewCellCollection coleccionDeCeldasSelect)
        {
            bool hayStock = false;
            int i;

            string nombre = coleccionDeCeldasSelect[0].Value.ToString();
            float precio = float.Parse(coleccionDeCeldasSelect[1].Value.ToString());
            string color = coleccionDeCeldasSelect[2].Value.ToString();
            int stock = int.Parse(coleccionDeCeldasSelect[3].Value.ToString());
            string tipo = coleccionDeCeldasSelect[4].Value.ToString();
            int codigo = int.Parse(coleccionDeCeldasSelect[5].Value.ToString());

            hayStock = Producto.VerificarStock(stock);
            if (hayStock)
            {
                i = Showroom.EncontrarIndexEnLista(codigo);
                if (i != -1)
                {
                    ShowroomExt.Restar1Stock(stock, i);
                }

                switch (tipo)
                {
                    case "accesorios":
                        miCliente.carritoCliente.Add(new Accesorios(
                            nombre,
                            (Producto.EColor)Enum.Parse(typeof(Producto.EColor), color),
                            precio,
                            codigo,
                            (Producto.ETipo)Enum.Parse(typeof(Producto.ETipo), tipo),
                            1,
                            Showroom.listaStockProductos[i].ObtenerSubtipo()));
                        break;

                    case "maquillaje":
                        miCliente.carritoCliente.Add(new Maquillaje(nombre,
                        (Producto.EColor)Enum.Parse(typeof(Producto.EColor), color),
                        precio, codigo,
                        (Producto.ETipo)Enum.Parse(typeof(Producto.ETipo), tipo),
                        1,
                        Showroom.listaStockProductos[i].ObtenerSubtipo()));
                        break;
                }
                return true;
            }
            return false;
        }
        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DataGridViewRow db = dtgvCarrito.CurrentRow;
            DataGridViewCellCollection coleccionCeldas = db.Cells;
            int codigo = int.Parse(coleccionCeldas[5].Value.ToString());
            miCliente.EliminarProductoCarrito(codigo);

            //ActualizarDtgv
            dtgvCarrito.DataSource = null;
            dtgvCarrito.DataSource = miCliente.carritoCliente;
            //Sumamos un stock ya que el producto fue devuelvo
            ShowroomExt.Aumentar1Stock(codigo);
            dtgvStock.DataSource = null;
            dtgvStock.DataSource = Showroom.listaStockProductos;
        }

        private void btnRealizarPedido_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBoxNombre.Text.ToString()))//Serializa el cliente (venta)
            {
                miCliente.Nombre = txtBoxNombre.Text.ToString();
                Showroom.filaClientes.Add(miCliente);
                Showroom.GuardarVentasXml(Showroom.filaClientes);
                MessageBox.Show("Pedido generado con exito", "Pedido", MessageBoxButtons.OK);
                this.Close();
            }
            else
            {
                MessageBox.Show("No ingreso nombre");
            }
        }


    }
}






