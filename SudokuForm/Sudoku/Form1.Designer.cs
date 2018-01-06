using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sudoku
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ResolverButton = new System.Windows.Forms.Button();
            this.MostrarErButton = new System.Windows.Forms.Button();
            this.LimpiarErButton = new System.Windows.Forms.Button();
            this.LimpiarTabButton = new System.Windows.Forms.Button();
            this.Cargarbutton = new System.Windows.Forms.Button();
            this.GuardarButton = new System.Windows.Forms.Button();
            this.tableroSudoku = new System.Windows.Forms.TableLayoutPanel();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ResolverButton
            // 
            this.ResolverButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ResolverButton.BackgroundImage")));
            this.ResolverButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ResolverButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ResolverButton.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResolverButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ResolverButton.Location = new System.Drawing.Point(518, 126);
            this.ResolverButton.Name = "ResolverButton";
            this.ResolverButton.Size = new System.Drawing.Size(171, 37);
            this.ResolverButton.TabIndex = 1;
            this.ResolverButton.Text = "Resolver";
            this.ResolverButton.UseVisualStyleBackColor = true;
            this.ResolverButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CambiarFondoBotonIn);
            this.ResolverButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ResolverButton_MouseUp);
            // 
            // MostrarErButton
            // 
            this.MostrarErButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MostrarErButton.BackgroundImage")));
            this.MostrarErButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MostrarErButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MostrarErButton.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MostrarErButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.MostrarErButton.Location = new System.Drawing.Point(518, 210);
            this.MostrarErButton.Name = "MostrarErButton";
            this.MostrarErButton.Size = new System.Drawing.Size(171, 37);
            this.MostrarErButton.TabIndex = 2;
            this.MostrarErButton.Text = "Mostrar errores";
            this.MostrarErButton.UseVisualStyleBackColor = true;
            this.MostrarErButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CambiarFondoBotonIn);
            this.MostrarErButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MostrarErButton_MouseUp);
            // 
            // LimpiarErButton
            // 
            this.LimpiarErButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LimpiarErButton.BackgroundImage")));
            this.LimpiarErButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LimpiarErButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LimpiarErButton.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LimpiarErButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.LimpiarErButton.Location = new System.Drawing.Point(518, 297);
            this.LimpiarErButton.Name = "LimpiarErButton";
            this.LimpiarErButton.Size = new System.Drawing.Size(171, 37);
            this.LimpiarErButton.TabIndex = 3;
            this.LimpiarErButton.Text = "Limpiar errores";
            this.LimpiarErButton.UseVisualStyleBackColor = true;
            this.LimpiarErButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CambiarFondoBotonIn);
            this.LimpiarErButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LimpiarErButton_MouseUp);
            // 
            // LimpiarTabButton
            // 
            this.LimpiarTabButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LimpiarTabButton.BackgroundImage")));
            this.LimpiarTabButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LimpiarTabButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LimpiarTabButton.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LimpiarTabButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.LimpiarTabButton.Location = new System.Drawing.Point(518, 379);
            this.LimpiarTabButton.Name = "LimpiarTabButton";
            this.LimpiarTabButton.Size = new System.Drawing.Size(171, 37);
            this.LimpiarTabButton.TabIndex = 4;
            this.LimpiarTabButton.Text = "Limpiar tablero";
            this.LimpiarTabButton.UseVisualStyleBackColor = true;
            this.LimpiarTabButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CambiarFondoBotonIn);
            this.LimpiarTabButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LimpiarTabButton_MouseUp);
            // 
            // Cargarbutton
            // 
            this.Cargarbutton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Cargarbutton.BackgroundImage")));
            this.Cargarbutton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Cargarbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cargarbutton.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cargarbutton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Cargarbutton.Location = new System.Drawing.Point(34, 477);
            this.Cargarbutton.Name = "Cargarbutton";
            this.Cargarbutton.Size = new System.Drawing.Size(165, 37);
            this.Cargarbutton.TabIndex = 5;
            this.Cargarbutton.Text = "Cargar tablero";
            this.Cargarbutton.UseVisualStyleBackColor = true;
            this.Cargarbutton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CambiarFondoBotonIn);
            this.Cargarbutton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Cargarbutton_MouseUp);
            // 
            // GuardarButton
            // 
            this.GuardarButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("GuardarButton.BackgroundImage")));
            this.GuardarButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GuardarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GuardarButton.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GuardarButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.GuardarButton.Location = new System.Drawing.Point(260, 477);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(165, 37);
            this.GuardarButton.TabIndex = 6;
            this.GuardarButton.Text = "Guardar tablero";
            this.GuardarButton.UseVisualStyleBackColor = true;
            this.GuardarButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CambiarFondoBotonIn);
            this.GuardarButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GuardarButton_MouseUp);
            // 
            // tableroSudoku
            // 
            this.tableroSudoku.Location = new System.Drawing.Point(0, 0);
            this.tableroSudoku.Name = "tableroSudoku";
            this.tableroSudoku.Size = new System.Drawing.Size(200, 100);
            this.tableroSudoku.TabIndex = 0;
            // 
            // InfoLabel
            // 
            this.InfoLabel.AutoSize = true;
            this.InfoLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.InfoLabel.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InfoLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.InfoLabel.Location = new System.Drawing.Point(486, 50);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(0, 26);
            this.InfoLabel.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(518, 477);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(171, 37);
            this.button1.TabIndex = 8;
            this.button1.Text = "Tablero vacio";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CambiarFondoBotonIn);
            this.button1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button1_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BackgroundImage = global::Sudoku.Properties.Resources.fondo;
            this.ClientSize = new System.Drawing.Size(734, 551);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.InfoLabel);
            this.Controls.Add(this.GuardarButton);
            this.Controls.Add(this.Cargarbutton);
            this.Controls.Add(this.LimpiarTabButton);
            this.Controls.Add(this.LimpiarErButton);
            this.Controls.Add(this.MostrarErButton);
            this.Controls.Add(this.ResolverButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(750, 590);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(50);
            this.Text = "Sudoku";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion
        private System.Windows.Forms.Button ResolverButton;
        private System.Windows.Forms.Button MostrarErButton;
        private System.Windows.Forms.Button LimpiarErButton;
        private System.Windows.Forms.Button LimpiarTabButton;
        private System.Windows.Forms.Button Cargarbutton;
        private System.Windows.Forms.Button GuardarButton;
        private System.Windows.Forms.TableLayoutPanel tableroSudoku;
        private Label InfoLabel;
        private Button button1;
    }
}

