using Buscaminas.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buscaminas
{
    public partial class Form1 : Form
    {
        //https://gist.github.com/fero23/3a8900554401a1272375
        public Form1()
        {
            InitializeComponent();
        }

        private Celda[][] tableroJuego;
        private bool inicializado = false;
        private int CeldasClickeadas = 0;
        private List<Celda> marcados = new List<Celda>();
        private int WFila;
        private int HColumna;
        private int Minas;
        const int tamañoCelda = 35;
        PictureBox picture;
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            HColumna = Convert.ToInt32(numVertical.Value);
            WFila = Convert.ToInt32(numHorizont.Value);
            Minas = Convert.ToInt32(numMinas.Value);
            if (HColumna < 4)
            {
                MessageBox.Show("Debe ingresar minimo 4 Columnas", "Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (WFila < 4)
            {
                MessageBox.Show("Debe ingresar minimo 4 Filas", "Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                CrearTablero();
            }
        }

        public void CrearTablero()
        {
            picture = new PictureBox();
            picture.Location = new System.Drawing.Point(284, 11);
            picture.Name = "pictFail";
            picture.Size = new System.Drawing.Size(73, 50);
            picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            picture.TabIndex = 12;
            picture.TabStop = false;

            this.ClientSize = new Size(tamañoCelda * WFila + 180, tamañoCelda * HColumna + 100); //Tamaño de la ventana
            tableroJuego = (from nFila in Enumerable.Range(0, WFila)
                            select (from nCol in Enumerable.Range(0, HColumna)
                                    select new Celda()//Creamos el boton con sus propiedades
                                    {
                                        TieneBomba = false,
                                        Columna = nCol,
                                        Fila = nFila,
                                        Top = nFila * tamañoCelda,
                                        Left = nCol * tamañoCelda,
                                        Size = new Size(tamañoCelda, tamañoCelda),
                                        TextAlign = ContentAlignment.MiddleCenter,
                                        BackColor = Color.LightGray
                                    }).ToArray()).ToArray();

            foreach (var fila in tableroJuego) //Agregamos los eventos de cada celda
            {
                foreach (var Celda in fila)
                {
                    Celda.Click += Celda_Click;
                    Celda.MouseUp += Celda_MouseUp;
                    pnlTablero.Controls.Add(Celda);
                }
            }
            lblMarcador.Text = "Minas restantes: " + (Minas - marcados.Count);
        }
        #region Eventos

        private void Celda_Click(object sender, EventArgs evt)
        {
            Celda celdaClic = sender as Celda;
            if (!marcados.Any(xCelda => object.ReferenceEquals(xCelda, celdaClic)))
            {
                SeleccionarCelda(celdaClic);
            }
        }

        private void Celda_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Celda c = sender as Celda;
                if (marcados.Any(Celda => object.ReferenceEquals(Celda, c)))
                {
                    marcados.Remove(c);
                    c.Text = string.Empty;
                    c.BackColor = Color.LightGray;
                    lblMarcador.Text = "Minas restantes: " + (Minas - marcados.Count());
                }
                else
                {
                    if (marcados.Count < Minas)
                    {
                        c.Text = "F";
                        c.BackColor = Color.Orange;
                        marcados.Add(c);

                        lblMarcador.Text = "Minas restantes: " + (Minas - marcados.Count());
                        if (marcados.Count == Minas && marcados.All(Celda => Celda.TieneBomba))
                        {
                            lblMarcador.Text = "¡Felicidades! ¡Has ganado!";
                            DeshabilitarTablero();
                        }
                    }
                }
            }
        }

        #endregion
        private void SeleccionarCelda(Celda celdaActual)
        {
            celdaActual.Click -= Celda_Click;
            celdaActual.Enabled = false;
            CeldasClickeadas++;
            celdaActual.BackColor = Color.White;
            lblMarcador.Focus();

            if (!inicializado)
            {
                var random = new Random();
                int bombasGeneradas = 0;
                while (bombasGeneradas < Minas)
                {
                    foreach (var fila in tableroJuego)
                    {
                        foreach (var Celda in fila)
                        {
                            if (random.Next(1, Minas) == 5)
                            {
                                if (!object.ReferenceEquals(celdaActual, Celda) && bombasGeneradas < Minas)
                                {
                                    bombasGeneradas++;
                                    Celda.TieneBomba = true;
                                }
                            }
                        }
                    }
                }
                inicializado = true;
            }

            celdaActual.FlatStyle = FlatStyle.Flat;
            if (celdaActual.TieneBomba)
            {
                celdaActual.BackColor = Color.Black;
                //celdaActual.Text = "M";
                celdaActual.BackgroundImage = Buscaminas.Properties.Resources.Mina;
                celdaActual.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                picture.Image = Buscaminas.Properties.Resources.Triste;
                this.Controls.Add(picture);
                lblMarcador.Text = "¡Caiste en una bomba! ¡Has perdido!";
                DeshabilitarTablero();
            }
            else
            {
                int bombasAlrededor = ContarBombasAlrededor(celdaActual);
                if (ContarBombasAlrededor(celdaActual) != 0)
                {
                    celdaActual.Text = bombasAlrededor.ToString();
                }
                else
                {
                    SeleccionarVacíosAlrededor(celdaActual);
                }
            }

            if (CeldasClickeadas == 54)
            {
                lblMarcador.Text = "¡Felicidades! ¡Has ganado!";
                DeshabilitarTablero();
            }
        }

        private void DeshabilitarTablero()
        {
            pnlTablero.Enabled = false;
        }


        private int contarBombasAlrededorRecursivo(List<Celda> celdas)
        {
            if(celdas.Count == 1)
            {
                return celdas[0].TieneBomba ? 1 : 0;
            }

            int TotalMinas = 0;
            int posicionMedia = celdas.Count / 2;
            TotalMinas += contarBombasAlrededorRecursivo(celdas.GetRange(0, posicionMedia));
            TotalMinas += contarBombasAlrededorRecursivo(celdas.GetRange(posicionMedia, posicionMedia));
            return TotalMinas;
        }

        private List<Celda> getCeldasAlrededor(Celda celdaActual)
        {
            int filaActual = celdaActual.Fila;
            int columnaActual = celdaActual.Columna;


            var lista =  new List<Celda>() {
                getCeldaDesdeCeldaActual(celdaActual, 1,1),
                getCeldaDesdeCeldaActual(celdaActual, 1,-1),
                getCeldaDesdeCeldaActual(celdaActual, 1,0),
                getCeldaDesdeCeldaActual(celdaActual, -1,1),
                getCeldaDesdeCeldaActual(celdaActual, -1,-1),
                getCeldaDesdeCeldaActual(celdaActual, -1,0),
                getCeldaDesdeCeldaActual(celdaActual, 0,-1),
                getCeldaDesdeCeldaActual(celdaActual, 0,1)
            };

            lista.RemoveAll(item => item == null);
            return lista;
        }

        private Celda getCeldaDesdeCeldaActual(Celda celdaActual, int fila, int columna)
        {
            int filaActual = celdaActual.Fila + fila;
            int columnaActual = celdaActual.Columna + columna;
            if (filaActual >= 0 && filaActual < WFila && columnaActual >= 0 && columnaActual < HColumna)
            {
                return tableroJuego[filaActual][columnaActual];
            }
            return null;
        }

        private int ContarBombasAlrededor(Celda celdaActual)
        {
            List<Celda> celdas = getCeldasAlrededor(celdaActual);
            int bombasAlrededorRecursivo = contarBombasAlrededorRecursivo(celdas);
            
            int bombasAlrededor = 0;
            RevisarBombaAlrededor(celdaActual, ref bombasAlrededor, 1, 1);
            RevisarBombaAlrededor(celdaActual, ref bombasAlrededor, 1, -1);
            RevisarBombaAlrededor(celdaActual, ref bombasAlrededor, 1, 0);
            RevisarBombaAlrededor(celdaActual, ref bombasAlrededor, -1, 1);
            RevisarBombaAlrededor(celdaActual, ref bombasAlrededor, -1, -1);
            RevisarBombaAlrededor(celdaActual, ref bombasAlrededor, -1, 0);
            RevisarBombaAlrededor(celdaActual, ref bombasAlrededor, 0, -1);
            RevisarBombaAlrededor(celdaActual, ref bombasAlrededor, 0, 1);

            Console.WriteLine("Total recursivo: " + bombasAlrededorRecursivo+" , "+ "Total iterativo: " + bombasAlrededor);
            return bombasAlrededorRecursivo;
        }


        private void SeleccionarVacíosAlrededor(Celda celdaActual)
        {
            SeleccionarVacíosAlrededor(celdaActual, 1, 1);
            SeleccionarVacíosAlrededor(celdaActual, 1, -1);
            SeleccionarVacíosAlrededor(celdaActual, 1, 0);
            SeleccionarVacíosAlrededor(celdaActual, -1, 1);
            SeleccionarVacíosAlrededor(celdaActual, -1, -1);
            SeleccionarVacíosAlrededor(celdaActual, -1, 0);
            SeleccionarVacíosAlrededor(celdaActual, 0, -1);
            SeleccionarVacíosAlrededor(celdaActual, 0, 1);
        }

        

        private void SeleccionarVacíosAlrededor(Celda celdaActual, short incCol, short incFila)
        {
            int fila = celdaActual.Fila + incFila;
            int columna = celdaActual.Columna + incCol;
            if (fila >= 0 && fila < WFila && columna >= 0 && columna < HColumna)
            {
                var Celda = tableroJuego[fila][columna];
                if (!Celda.TieneBomba && ContarBombasAlrededor(Celda) == 0 && Celda.Enabled)
                {
                    SeleccionarCelda(Celda);
                }
            }
        }

        private void RevisarBombaAlrededor(Celda celdaActual, ref int contador, short incCol, short incFila)
        {
            int fila = celdaActual.Fila + incFila;
            int columna = celdaActual.Columna + incCol;
            if (fila >= 0 && fila < WFila && columna >= 0 && columna < HColumna
                && tableroJuego[fila][columna].TieneBomba)
            {
                contador++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
             Socket miPrimerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint direccion = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);

            miPrimerSocket.Bind(direccion);

            miPrimerSocket.Listen(5);

            MessageBox.Show("Escuchando...");

            Socket Escuchar = miPrimerSocket.Accept();

            MessageBox.Show("Conectado con exito SERVER");


            byte[] ByRec = new byte[255];

            int a = Escuchar.Receive(ByRec, 0, ByRec.Length, 0);

            Array.Resize(ref ByRec, a);

            MessageBox.Show("Cliente dice: " + Encoding.Default.GetString(ByRec)); //mostramos lo recibido

            miPrimerSocket.Close();

            MessageBox.Show("Presione cualquier tecla para terminar SERVER");

            Console.ReadKey();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Socket miPrimerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint miDireccion = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);

            miPrimerSocket.Connect(miDireccion); // Conectamos               

            MessageBox.Show("Conectado con exito CLIENTE");
            MessageBox.Show("Ingrese La Informacion a Enviar\n\n");



            string info = textBox1.Text;

            byte[] infoEnviar = Encoding.Default.GetBytes(info);

            miPrimerSocket.Send(infoEnviar, 0, infoEnviar.Length, 0);

            miPrimerSocket.Close();


            MessageBox.Show("Presione cualquier tecla para terminar CLIENTE");

        }
    }
}
