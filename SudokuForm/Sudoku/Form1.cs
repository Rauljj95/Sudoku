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
                        aux.Margin = new Padding(2, 2, 4, 2);
                    else if (j % 3 == 0 && i % 3 != 2)
                        aux.Margin = new Padding(4, 2, 2, 2);
                    else if (j % 3 == 2 && i % 3 == 2)
                        aux.Margin = new Padding(2, 2, 4, 6);
                    else if (j % 3 == 0 && i % 3 == 2)
                        aux.Margin = new Padding(4, 2, 2, 6);
                    else if (i % 3 == 2)
                        aux.Margin = new Padding(2, 2, 2, 6);
                    else
                        aux.Margin = new System.Windows.Forms.Padding(2);



                    aux.MaxLength = 1;
                   
                    aux.Name = "textBox" + i.ToString() + j.ToString();
                    aux.Size = new System.Drawing.Size(37, 37);
                    aux.TabIndex = 35;
                    aux.Location = new Point(50, 50);
                    aux.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
                    aux.BackColor = Color.Silver;
                }
            }
            tablero = new Elementos.TableroSudoku();

            foreach (Control auxc in tableroSudoku.Controls)
            {
                auxc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Tecla_Valida);
                auxc.MouseClick += new MouseEventHandler(CambiarColorCasillasActual);
            }




        }


        public void CambiarColorCasillasActual(object sender, MouseEventArgs e)
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
        }
        public void CambiarFondoBotonIn(object sender, MouseEventArgs e)
        {
            InfoLabel.ResetText();
            MostrarFondos();
            Button b = (Button)sender;
            b.BackgroundImage = Properties.Resources.tablero_invertido;
            b.ForeColor = Color.Black;
        }

        public void CambiarFondoBoton(object sender, MouseEventArgs e)
        {
            Button b = (Button)sender;
            b.BackgroundImage = Properties.Resources.fondo_tablero;
            b.ForeColor = Color.White;
        }

        private void LimpiarTabButton_MouseUp(object sender, MouseEventArgs e)
        {
            InfoLabel.ResetText();
            CambiarFondoBoton(sender, e);
            tablero.LimpiarTablero();
            MostrarCasillas();
            MostrarFondos();
        }


        private void LimpiarErButton_MouseUp(object sender, MouseEventArgs e)
        {
            InfoLabel.ResetText();

            CambiarFondoBoton(sender, e);

            if (tablero.ComprobarTablero() == true)
                InfoLabel.Text = "No hay errores.";
            else             
                tablero.LimpiarErrores();
           
            MostrarCasillas();
            MostrarFondos();
        }



        private void GuardarButton_MouseUp(object sender, MouseEventArgs e)
        {
            InfoLabel.ResetText();
            CambiarFondoBoton(sender, e);
            tablero.ComprobarTablero();
            tablero.LimpiarErrores();
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

        private void LimpiarTablero()
        {
            TextBox auxb;
            foreach(Control aux in tableroSudoku.Controls)
            {
                auxb = (TextBox)aux;
                auxb.ResetText();
                auxb.ReadOnly = false;
                auxb.BackColor = Color.DarkSeaGreen;
            }
        }

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
                            WaitSeconds(0.2);
                            tablero.ResolverTablero();
                            if(tablero.TableroLleno() != true && tablero.ComprobarTablero() != true)
                            {
                                MessageBox.Show("El tablero cargado no se pudo resolver. Seleccione otro tablero.");
                                
                            }
                            else
                            {
                                InfoLabel.Text = "Tablero cargado.";
                            }
                           
                            
                            tablero.LimpiarTablero();
                                LimpiarTablero();
                                for (int i = 0; i < 9; i++)
                                {
                                    for (int j = 0; j < 9; j++)
                                    {
                                        auxb = (TextBox)tableroSudoku.GetControlFromPosition(j, i);
                                        if (tablero.BuscarCasilla(i, j).Estatico == true)
                                        {
                                            auxb.ReadOnly = true;
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




        private void ResolverButton_MouseUp(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.AppStarting;
            InfoLabel.ResetText();
            InfoLabel.Text = "Resolviendo...";


            WaitSeconds(0.2);
            CambiarFondoBoton(sender, e);
            if(tablero.ComprobarTablero() == false)
            {
             
                InfoLabel.Text = "No hay solucion.";               
                MostrarCasillas();
                MostrarFondos();
                return;
            }
            else
           // tablero.LimpiarErrores();
            tablero.ResolverTablero();
            MostrarCasillas();
            MostrarFondos();
            this.Cursor = Cursors.Default;

            if (tablero.TableroLleno() == true && tablero.ComprobarTablero() == true)
                InfoLabel.Text = "Tablero resuelto.";
            else
                InfoLabel.Text = "No hay solucion.";

            
            return;

        }



        private void MostrarErButton_MouseUp(object sender, MouseEventArgs e)
        {
           
            InfoLabel.ResetText();
            if (sender != null && e != null)
                CambiarFondoBoton(sender, e);
           
            if (tablero.ComprobarTablero() == true)
                InfoLabel.Text = "No hay ningun error.";
            else
            {
                MostrarFondos();
     
            }
                
        }

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
       
        private void Tecla_Valida(Object sender, KeyPressEventArgs e)
        {
            InfoLabel.ResetText();
            int.TryParse(e.KeyChar.ToString(), out int number);
            //MessageBox.Show(number.ToString());

            
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
                        MessageBox.Show("Has resuelto el sudoku!");
                    else
                        MostrarErButton_MouseUp(null, null);
            }
                
        }

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

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            InfoLabel.ResetText();
            CambiarFondoBoton(sender, e);
            LimpiarTablero();
            tablero = new Elementos.TableroSudoku();
        }
    }
}
