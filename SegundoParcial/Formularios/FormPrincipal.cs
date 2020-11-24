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
    public partial class FormPrincipal : Form
    {
        Hilo hiloFilaClientes = new Hilo(2000);
        Hilo hiloPedidosRealizados = new Hilo(4000,6000);
        static int index = 0;

        public FormPrincipal()
        {
            InitializeComponent();
            try
            {
                Showroom.ObtenerVentasXml();
                this.CargarPedidos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Button inicializador de threads
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnComenzar_Click(object sender, EventArgs e)
        {
            hiloFilaClientes.EventoTiempo += Actualizar;
            hiloFilaClientes.Activo = true;

            hiloPedidosRealizados.EventoTiempo += Atender;
            hiloPedidosRealizados.Activo = true;
        }

        /// <summary>
        /// Metodo suscripto al evento del hiloFilaClientes
        /// </summary>
        private void Actualizar()
        {
            if (listBxEnQueue.InvokeRequired)
            {
                listBxEnQueue.BeginInvoke((MethodInvoker)delegate ()
                {
                    CargarPedidos();
                }
                );
            }
            else
            {
                CargarPedidos();
            }
        }
        /// <summary>
        /// Metodo encargado de actualizar
        /// </summary>
        private void CargarPedidos()
        {
            this.listBxEnQueue.Items.Clear();
            foreach (Cliente item in Showroom.filaClientes)
            {
                this.listBxEnQueue.Items.Add(item.MostrarVenta());
            }
        }

        /// <summary>
        /// Metodo suscripto al evento del hiloFilaClientes
        /// </summary>
        private void Atender()
        {
            if (listBxRealizados.InvokeRequired)
            {
                listBxRealizados.BeginInvoke((MethodInvoker)delegate ()
                {
                    AtendiendoClientes();
                }
                );
            }
            else
            {
                AtendiendoClientes();
            }
        }
        private void AtendiendoClientes()
        {
            int i = index;

            if(Showroom.filaClientes.Count > 0)
            {
                Showroom.ventasRealizadas.Add(Showroom.filaClientes[i]);
                Showroom.filaClientes.RemoveAt(i);
                listBxRealizados.Items.Add(Showroom.ventasRealizadas[i].MostrarVenta());
            }
            index++;
        }

        private void btnNuevoPedido_Click(object sender, EventArgs e)
        {
            FormNuevaCompra formNueva = new FormNuevaCompra();
            formNueva.Show();
        }

        /// <summary>
        /// El btnEliminar borra un pedido en preparacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int i;
            string auxNombreCte = listBxEnQueue.SelectedItem.ToString();
            if (!string.IsNullOrWhiteSpace(auxNombreCte))
            {
                auxNombreCte = Cliente.ObtenerNombreCte(auxNombreCte);
                i = Showroom.BuscarClientePorNombre(auxNombreCte);
                if (i != -1)
                {
                    Showroom.filaClientes.RemoveAt(i);
                    listBxEnQueue.Items.Clear();
                    foreach (Cliente item in Showroom.filaClientes)
                    {
                        listBxEnQueue.Items.Add(item.MostrarVenta());
                    }

                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error inesperado");
                }
            }
        }

        /// <summary>
        /// Antes de cerrar el form, aborta los hilos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            hiloFilaClientes.Activo = false;
            hiloPedidosRealizados.Activo = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea salir?", "Saliendo...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

    }
}

