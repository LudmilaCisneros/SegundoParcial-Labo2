namespace Formularios
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.btnNuevoPedido = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblEnPreparacion = new System.Windows.Forms.Label();
            this.lblRealizados = new System.Windows.Forms.Label();
            this.listBxEnQueue = new System.Windows.Forms.ListBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnComenzar = new System.Windows.Forms.Button();
            this.listBxRealizados = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnNuevoPedido
            // 
            this.btnNuevoPedido.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnNuevoPedido.Location = new System.Drawing.Point(456, 365);
            this.btnNuevoPedido.Name = "btnNuevoPedido";
            this.btnNuevoPedido.Size = new System.Drawing.Size(156, 58);
            this.btnNuevoPedido.TabIndex = 0;
            this.btnNuevoPedido.Text = "Nuevo pedido";
            this.btnNuevoPedido.UseVisualStyleBackColor = true;
            this.btnNuevoPedido.Click += new System.EventHandler(this.btnNuevoPedido_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(29, 406);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(102, 41);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lblEnPreparacion
            // 
            this.lblEnPreparacion.AutoSize = true;
            this.lblEnPreparacion.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnPreparacion.Location = new System.Drawing.Point(547, 43);
            this.lblEnPreparacion.Name = "lblEnPreparacion";
            this.lblEnPreparacion.Size = new System.Drawing.Size(135, 19);
            this.lblEnPreparacion.TabIndex = 4;
            this.lblEnPreparacion.Text = "EN PREPARACIÓN";
            // 
            // lblRealizados
            // 
            this.lblRealizados.AutoSize = true;
            this.lblRealizados.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRealizados.Location = new System.Drawing.Point(141, 43);
            this.lblRealizados.Name = "lblRealizados";
            this.lblRealizados.Size = new System.Drawing.Size(117, 19);
            this.lblRealizados.TabIndex = 5;
            this.lblRealizados.Text = "PARA RETIRAR";
            // 
            // listBxEnQueue
            // 
            this.listBxEnQueue.BackColor = System.Drawing.Color.RosyBrown;
            this.listBxEnQueue.FormattingEnabled = true;
            this.listBxEnQueue.Location = new System.Drawing.Point(474, 75);
            this.listBxEnQueue.Name = "listBxEnQueue";
            this.listBxEnQueue.Size = new System.Drawing.Size(297, 225);
            this.listBxEnQueue.TabIndex = 6;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(790, 103);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(97, 47);
            this.btnEliminar.TabIndex = 7;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnComenzar
            // 
            this.btnComenzar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnComenzar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnComenzar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnComenzar.Location = new System.Drawing.Point(249, 365);
            this.btnComenzar.Name = "btnComenzar";
            this.btnComenzar.Size = new System.Drawing.Size(156, 58);
            this.btnComenzar.TabIndex = 8;
            this.btnComenzar.Text = "Comenzar";
            this.btnComenzar.UseVisualStyleBackColor = true;
            this.btnComenzar.Click += new System.EventHandler(this.btnComenzar_Click);
            // 
            // listBxRealizados
            // 
            this.listBxRealizados.BackColor = System.Drawing.Color.Bisque;
            this.listBxRealizados.FormattingEnabled = true;
            this.listBxRealizados.Location = new System.Drawing.Point(79, 75);
            this.listBxRealizados.Name = "listBxRealizados";
            this.listBxRealizados.Size = new System.Drawing.Size(297, 225);
            this.listBxRealizados.TabIndex = 9;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(899, 470);
            this.Controls.Add(this.listBxRealizados);
            this.Controls.Add(this.btnComenzar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.listBxEnQueue);
            this.Controls.Add(this.lblRealizados);
            this.Controls.Add(this.lblEnPreparacion);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnNuevoPedido);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormPrincipal";
            this.Text = "Showroom";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPrincipal_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNuevoPedido;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblEnPreparacion;
        private System.Windows.Forms.Label lblRealizados;
        private System.Windows.Forms.ListBox listBxEnQueue;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnComenzar;
        private System.Windows.Forms.ListBox listBxRealizados;
    }
}

