using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Sudoku
{
    public partial class Form1 : Form
    {
        private Elementos.TableroSudoku tablero;

        /// <summary>
        /// Constructor del formulario
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            TextBox aux;
            InfoLabel.BackColor = Color.Transparent;
            this.Controls.Add(tableroSudoku);
            InfoLabel.ResetText();
            this.tableroSudoku.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tableroSudoku.BackgroundImage = Properties.Resources.fondo_tablero;
            this.tableroSudoku.ColumnCount = 9;
            this.tableroSudoku.RowCount = 9;
            this.tableroSudoku.Padding = new Padding(6, 9, 6, 5);
            this.tableroSudoku.Location = new Point(32, 32);

            this.tableroSudoku.MouseLeave += new EventHandler(CambiarColorCasillasOriginal);
            this.tableroSudoku.AutoSize = true;
            this.tableroSudoku.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    aux = new System.Windows.Forms.TextBox();
                    //this.Controls.Add(aux);
                    this.tableroSudoku.Controls.Add(aux, j, i);

                    aux.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    aux.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));


                    if (j % 3 == 2 && i % 3 != 2)
                        aux.Margin = new Padding(1, 1, 4, 1);
                    else if (j % 3 == 0 && i % 3 != 2)
                        aux.Margin = new Padding(4, 1, 1, 1);
                    else if (j % 3 == 2 && i % 3 == 2)
                        aux.Margin = new Padding(1, 1, 4, 6);
                    else if (j % 3 == 0 && i % 3 == 2)
                        aux.Margin = new Padding(4, 1, 1, 6);
                    else if (i % 3 == 2)
                        aux.Margin = new Padding(1, 1, 1, 6);
                    else
                        aux.Margin = new System.Windows.Forms.Padding(1);



                    aux.MaxLength = 1;

                    aux.Name = "textBox" + i.ToString() + j.ToString();
                    aux.Size = new System.Drawing.Size(37, 37);
                    aux.TabIndex = 35;
                    aux.Location = new Point(50, 50);
                    aux.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
                    aux.BackColor = Color.Silver;
                    aux.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Tecla_Valida);
                
                    aux.MouseEnter += new EventHandler(CambiarColorCasillasActual);
            
                }
            }
            comboDificultad.Items.Add("Muy fácil");

            comboDificultad.Items.Add("Fácil");
            comboDificultad.Items.Add("Medio");
            comboDificultad.Items.Add("Difícil");
            comboDificultad.Items.Add("Muy difícil");
            comboDificultad.Text = "Dificultad";
            tablero = new Elementos.TableroSudoku();


        }

    

      


        /// <summary>
        /// Cambia el color del cuadrante, la fila y la columna de la casilla seleccionada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CambiarColorCasillasActual(object sender, EventArgs e)
        {

            MostrarFondos();
            int i = 0, j = 0;
            double dSize = (double)tablero.Size();
            int modulo = (int)Math.Sqrt(Convert.ToDouble(dSize));
            int fila = tableroSudoku.GetRow((Control)sender);
            int columna = tableroSudoku.GetColumn((Control)sender);
            //MessageBox.Show("fila: " + fila.ToString() + " columna: " + columna.ToString());
            int minFila = fila - (fila % modulo);
            int minCol = columna - (columna % modulo);
            TextBox aux = (TextBox)sender;
            
          


            for (i = minFila; i < (minFila + modulo); i++)
            {
                for (j = minCol; j < (minCol + modulo); j++)
                {
                    //MessageBox.Show("fila: " + i.ToString() + " columna: " + j.ToString());
                    tableroSudoku.GetControlFromPosition(j, i).BackColor = Color.PapayaWhip;

                }
            }
            for (i = 0; i < 9; i++)
            {

                tableroSudoku.GetControlFromPosition(columna, i).BackColor = Color.PapayaWhip;
                tableroSudoku.GetControlFromPosition(i, fila).BackColor = Color.PapayaWhip;
            }
            aux.BackColor = Color.LightSkyBlue;
        }



        /// <summary>
        /// Devuelve a las casillas su color de fondo habitual cuando el ratón sale del tablero
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CambiarColorCasillasOriginal(object sender, EventArgs e)
        {
            MostrarCasillas();
            MostrarFondos();
        }



        /// <summary>
        /// Cambia el color del boton cuando haces click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CambiarFondoBotonIn(object sender, MouseEventArgs e)
        {
            InfoLabel.ResetText();
            MostrarFondos();
            Button b = (Button)sender;
            b.BackgroundImage = Properties.Resources.tablero_invertido;
            b.ForeColor = Color.Black;
        }


        /// <summary>
        /// Cambia el color del boton cuando haces click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CambiarFondoBoton(object sender, MouseEventArgs e)
        {
            Button b = (Button)sender;
            b.BackgroundImage = Properties.Resources.fondo_tablero;
            b.ForeColor = Color.White;
        }


        /// <summary>
        /// Limpia el tablero, dejando las casillas del tablero cargado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LimpiarTabButton_MouseUp(object sender, MouseEventArgs e)
        {
            InfoLabel.ResetText();
            CambiarFondoBoton(sender, e);
            tablero.LimpiarTablero();
            MostrarCasillas();
            MostrarFondos();
        }


        /// <summary>
        /// Limpia los errores que estan actualmente mostrados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LimpiarErButton_MouseUp(object sender, MouseEventArgs e)
        {
            InfoLabel.ResetText();

            CambiarFondoBoton(sender, e);

            if (tablero.ComprobarTablero() == true)
                InfoLabel.Text = "No hay ningún error.";
            else
                tablero.LimpiarErrores();

            MostrarCasillas();
            MostrarFondos();
        }


        /// <summary>
        /// Guarda el tablero actual en un fichero xml
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GuardarButton_MouseUp(object sender, MouseEventArgs e)
        {
            InfoLabel.ResetText();
            CambiarFondoBoton(sender, e);
            tablero.ComprobarTablero();
            //tablero.LimpiarErrores();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = @Directory.GetCurrentDirectory().ToString() + "\\Tableros";
            saveFileDialog1.Filter = "xml (*.xml)|*.xml|All files (*.*)|*.*";
            saveFileDialog1.Title = "Guarda el fichero xml";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.
                System.IO.FileStream fs =
                   (System.IO.FileStream)saveFileDialog1.OpenFile();
                // Saves the Image in the appropriate ImageFormat based upon the
                // File type selected in the dialog box.
                // NOTE that the FilterIndex property is one-based.
                tablero.GuardarTablero(fs);
                InfoLabel.Text = "Tablero guardado.";
                fs.Close();
            }
        }


        /// <summary>
        /// Limpia todas las casillas del tablero
        /// </summary>
        private void LimpiarTablero()
        {
            TextBox auxb;
            InfoLabel.ResetText();

            foreach (Control aux in tableroSudoku.Controls)
            {
                auxb = (TextBox)aux;
                auxb.ResetText();
                auxb.Enabled = true;
                auxb.ReadOnly = false;
                auxb.BackColor = Color.DarkSeaGreen;
            }
        }


        /// <summary>
        /// Espera los segundos pasados por parametro antes de seguir con la siguiente instruccion
        /// </summary>
        /// <param name="nSecs"></param>
        private static void WaitSeconds(double nSecs)
        {
            // Esperar los segundos indicados

            // Crear la cadena para convertir en TimeSpan
            string s = "0.00:00:" + nSecs.ToString().Replace(",", ".");
            TimeSpan ts = TimeSpan.Parse(s);

            // Añadirle la diferencia a la hora actual
            DateTime t1 = DateTime.Now.Add(ts);

            // Esta asignación solo es necesaria
            // si la comprobación se hace al principio del bucle
            DateTime t2 = DateTime.Now;

            // Mientras no haya pasado el tiempo indicado
            while (t2 < t1)
            {
                // Un respiro para el sitema
                System.Windows.Forms.Application.DoEvents();
                // Asignar la hora actual
                t2 = DateTime.Now;
            }
        }

        /// <summary>
        /// Genera un tablero aleatorio según la dificultad
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerarTablero(object sender, MouseEventArgs e)
        {
            InfoLabel.ResetText();
            tablero = new Elementos.TableroSudoku();
            LimpiarTablero();

            this.Cursor = Cursors.AppStarting;
            CambiarFondoBoton(sender, e);
            InfoLabel.Text = "Generando tablero.";
            WaitSeconds(0.1);
            WaitSeconds(0.1);
            try

            {
                switch (comboDificultad.SelectedIndex)
                {
                    case 0:
                        tablero.GenerarTablero(28);
                        break;
                    case 1:
                        tablero.GenerarTablero(25);
                        break;

                    case 2:
                        tablero.GenerarTablero(23);
                        break;
                    case 3:
                        tablero.GenerarTablero(18);
                        break;
                    case 4:
                        tablero.GenerarTablero(15);
                        break;
                    default:

                        InfoLabel.Text = "Selecciona dificultad.";
                        break;
                }
            }catch
            {
             
                GenerarTablero(null, null);
            }


           
            InfoLabel.Text = "Tablero generado.";
            TextBox auxb;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    auxb = (TextBox)tableroSudoku.GetControlFromPosition(j, i);
                    if (tablero.BuscarCasilla(i, j).Estatico == true)
                    {
                        auxb.ReadOnly = true;
                        auxb.Enabled = false;
                    }
                }
            }
            MostrarCasillas();
            MostrarFondos();
            
            
            this.Cursor = Cursors.Default;
        }


        /// <summary>
        /// Carga un tablero desde un fichero xml si es posible resolverlo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cargarbutton_MouseUp(object sender, MouseEventArgs e)
        {
            InfoLabel.ResetText();
        

            this.Cursor = Cursors.AppStarting;
            CambiarFondoBoton(sender, e);
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = @Directory.GetCurrentDirectory().ToString() + "\\Tableros";
            openFileDialog1.Filter = "All files (*.*)|*.*|xml (*.xml)|*.xml";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            TextBox auxb;
            Elementos.TableroSudoku tableroAux = tablero;
           
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            InfoLabel.Text = "Cargando tablero.";
                            tablero = new Elementos.TableroSudoku();
                            tablero.CargarTablero(myStream);
                            myStream.Close();
                            InfoLabel.Text = "Comprobando...";
                            LimpiarTablero();

                            if (tablero.TableroLleno() != true && tablero.ComprobarTablero() != true)
                            {
                                MessageBox.Show("El tablero cargado no se puede resolver. Se mostrarán los fallos para su modificación.");                              
                            }
                            else if(tablero.TableroLleno() == true && tablero.ComprobarTablero() == true)
                            {
                                InfoLabel.Text = "Tablero resuelto.";
                            }
                            else
                            {
                                InfoLabel.Text = "Tablero cargado.";
                            }
                            
                            //tablero.LimpiarTablero();
                            
                                for (int i = 0; i < 9; i++)
                                {
                                    for (int j = 0; j < 9; j++)
                                    {
                                        auxb = (TextBox)tableroSudoku.GetControlFromPosition(j, i);
                                        if (tablero.BuscarCasilla(i, j).Estatico == true)
                                        {
                                            auxb.ReadOnly = true;
                                            auxb.Enabled = false;
                                    }
                                    }
                                }
                             MostrarCasillas();
                             MostrarFondos();                            
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
           
            this.Cursor = Cursors.Default;
        }


        /// <summary>
        /// Resuelve el tablero con los valores actuales, mostrando los fallos si los hay
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResolverButton_MouseUp(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.AppStarting;
            InfoLabel.ResetText();
            InfoLabel.Text = "Resolviendo...";
            CambiarFondoBoton(sender, e);
            


            if (tablero.ComprobarTablero() == false)
            {
             
                InfoLabel.Text = "No hay solucion.";               
                MostrarCasillas();
                MostrarFondos();
                return;
            }
            
           // tablero.LimpiarErrores();
            tablero.ResolverTablero(0, 0);
            MostrarCasillas();
            MostrarFondos();
            this.Cursor = Cursors.Default;

            if (tablero.TableroLleno() == true && tablero.ComprobarTablero() == true)
                InfoLabel.Text = "Tablero resuelto.";
            else
                InfoLabel.Text = "No hay solucion.";
            
            return;

        }


        /// <summary>
        /// Muestra las casillas con errores en color rojo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MostrarErButton_MouseUp(object sender, MouseEventArgs e)
        {
           
            InfoLabel.ResetText();
            if (sender != null && e != null)
                CambiarFondoBoton(sender, e);
           
            if (tablero.ComprobarTablero() == true)
                InfoLabel.Text = "No hay ningún error.";
            else
            {
                MostrarFondos();
     
            }
                
        }


        /// <summary>
        /// Muestra en el tablero el valor de las casillas
        /// </summary>
        private void MostrarCasillas()
        {
            TextBox auxb;
            int numero = 0;

            for(int i = 0; i < 9; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    auxb = (TextBox)tableroSudoku.GetControlFromPosition(j, i);
                    numero = tablero.BuscarCasilla(i, j).Valor;
                    if (numero == 0)
                    {
                        auxb.ResetText();
                    }
                    else
                    {
                        auxb.Text = Math.Abs(numero).ToString();
                    }                       
                }
            }
        }
       

        /// <summary>
        /// Guarda en una casilla el valor que introduce el usuario, si es un numero del 1 al 9, y la casilla no es estatica
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tecla_Valida(Object sender, KeyEventArgs e)
        {
            
            InfoLabel.ResetText();

            int.TryParse(Convert.ToChar(e.KeyValue).ToString(), out int number);
          
            
            TextBox t = (TextBox)sender;
            if (t.ReadOnly == true)
                return;
            if (number > 9 || number < 1)
            {
                t.Text = " ";
                InfoLabel.Text = "Numero del 1 al 9.";
                tablero.BuscarCasilla(tableroSudoku.GetRow((Control)sender), tableroSudoku.GetColumn((Control)sender)).Valor = 0;
               
            }
               
            else
            {
                t.Text = number.ToString();
                tablero.BuscarCasilla(tableroSudoku.GetRow((Control)sender), tableroSudoku.GetColumn((Control)sender)).Valor = number;
                //MessageBox.Show(tablero.BuscarCasilla(tableroSudoku.GetRow((Control)sender), tableroSudoku.GetColumn((Control)sender)).Valor.ToString()+ " fila " + tableroSudoku.GetRow((Control)sender).ToString() + " columna " + tableroSudoku.GetColumn((Control)sender).ToString());
                if (tablero.TableroLleno() == true)
                    if (tablero.ComprobarTablero() == true)
                    {
                        MessageBox.Show("Has resuelto el sudoku!");
                    }
                       
                    else
                        MostrarErButton_MouseUp(null, null);
            }
                
        }


        /// <summary>
        /// Muestra el color de fondo de las casillas, indicando si hay fallo o no
        /// </summary>
        private void MostrarFondos()
        {
         
            TextBox auxc;
            foreach (Control aux in tableroSudoku.Controls)
            {
                auxc = (TextBox)aux;
                if (auxc.ReadOnly == true)
                    aux.BackColor = Color.LightSteelBlue;
                else if(tablero.BuscarCasilla(tableroSudoku.GetRow(aux), tableroSudoku.GetColumn(aux)).Valor < 0)
                {
                    aux.BackColor = Color.LightCoral;
                }
                else
                {
                    aux.BackColor = Color.DarkSeaGreen;
                }
                    
            }
            
        }


        /// <summary>
        /// Reestablece el tablero
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            InfoLabel.ResetText();
            CambiarFondoBoton(sender, e);
            LimpiarTablero();
            tablero = new Elementos.TableroSudoku();
        }
    }
}
