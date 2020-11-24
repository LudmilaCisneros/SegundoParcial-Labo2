using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Hilo
    {
        private Thread hilo;
        private int intervaloMin;
        private int intervaloMax;

        public delegate void encargadoTiempo();
        public event encargadoTiempo EventoTiempo;

        public Hilo(int intervaloMin,int intervaloMax)
        {
            this.intervaloMin = intervaloMin;
            this.intervaloMax = intervaloMax;
        }
        public Hilo(int intervalo)
        {
            this.intervaloMin = intervalo;
            this.intervaloMax = intervalo;
        }
        public bool Activo
        {
            get
            {
                if (this.hilo != null)
                {
                    return this.hilo.IsAlive;
                }
                return false;
            }
            set
            {
                if (value)
                {
                    if (this.hilo == null || !this.hilo.IsAlive)
                    {
                        this.hilo = new Thread(Corriendo);
                        this.hilo.Start();
                    }
                }
                else
                {
                    if (this.hilo != null && this.hilo.IsAlive)
                    {
                        this.hilo.Abort();
                    }
                }
            }
        }
        public int IntervaloMin
        {
            get { return this.intervaloMin; }
            set { this.intervaloMin = value; }
        }

        public int IntervaloMax
        {
            get { return this.intervaloMax; }
            set { this.intervaloMax = value; }
        }

        private void Corriendo()
        {
            while (true)
            {
                if (EventoTiempo != null)
                {
                    EventoTiempo.Invoke();
                }
                Random r = new Random();
                Thread.Sleep(r.Next(intervaloMin,IntervaloMax));
                
            }
        }

    }
}

