﻿namespace GYM
{
    partial class Instructor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Instructor));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.rutinaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearRutinaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mostrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ejercicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearEjercicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox_logo = new System.Windows.Forms.PictureBox();
            this.panel_MostrarRutinas = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewEjercicio = new System.Windows.Forms.DataGridView();
            this.dataGridViewRutina = new System.Windows.Forms.DataGridView();
            this.panel_CrearRutina = new System.Windows.Forms.Panel();
            this.button_CambiarHora = new System.Windows.Forms.Button();
            this.button_EliminarEjercicio = new System.Windows.Forms.Button();
            this.button_AgrerarEjercicio2 = new System.Windows.Forms.Button();
            this.button_BuscarRutina = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_ModificarrutinaId = new System.Windows.Forms.TextBox();
            this.button_agregarEjercicios = new System.Windows.Forms.Button();
            this.dataGridView_AgregarEjercicios = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_CrearHorasRutina = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_CrearIdRutina = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox_Descricpcion = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dataGridView_aparatos = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_Repeticiones = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_logo)).BeginInit();
            this.panel_MostrarRutinas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEjercicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRutina)).BeginInit();
            this.panel_CrearRutina.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_AgregarEjercicios)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_aparatos)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rutinaToolStripMenuItem,
            this.ejercicioToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(702, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // rutinaToolStripMenuItem
            // 
            this.rutinaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crearRutinaToolStripMenuItem,
            this.modificarToolStripMenuItem,
            this.mostrarToolStripMenuItem});
            this.rutinaToolStripMenuItem.Name = "rutinaToolStripMenuItem";
            this.rutinaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.rutinaToolStripMenuItem.Text = "Rutina";
            // 
            // crearRutinaToolStripMenuItem
            // 
            this.crearRutinaToolStripMenuItem.Name = "crearRutinaToolStripMenuItem";
            this.crearRutinaToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.crearRutinaToolStripMenuItem.Text = "Crear Rutina";
            this.crearRutinaToolStripMenuItem.Click += new System.EventHandler(this.crearRutinaToolStripMenuItem_Click);
            // 
            // modificarToolStripMenuItem
            // 
            this.modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            this.modificarToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.modificarToolStripMenuItem.Text = " Modificar";
            this.modificarToolStripMenuItem.Click += new System.EventHandler(this.modificarToolStripMenuItem_Click);
            // 
            // mostrarToolStripMenuItem
            // 
            this.mostrarToolStripMenuItem.Name = "mostrarToolStripMenuItem";
            this.mostrarToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.mostrarToolStripMenuItem.Text = "Mostrar";
            this.mostrarToolStripMenuItem.Click += new System.EventHandler(this.mostrarToolStripMenuItem_Click);
            // 
            // ejercicioToolStripMenuItem
            // 
            this.ejercicioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crearEjercicioToolStripMenuItem});
            this.ejercicioToolStripMenuItem.Name = "ejercicioToolStripMenuItem";
            this.ejercicioToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.ejercicioToolStripMenuItem.Text = "Ejercicio";
            // 
            // crearEjercicioToolStripMenuItem
            // 
            this.crearEjercicioToolStripMenuItem.Name = "crearEjercicioToolStripMenuItem";
            this.crearEjercicioToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.crearEjercicioToolStripMenuItem.Text = "Crear ejercicio";
            this.crearEjercicioToolStripMenuItem.Click += new System.EventHandler(this.crearEjercicioToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(90, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bienvendio";
            // 
            // pictureBox_logo
            // 
            this.pictureBox_logo.Image = global::GYM.Properties.Resources.Logo;
            this.pictureBox_logo.Location = new System.Drawing.Point(95, 113);
            this.pictureBox_logo.Name = "pictureBox_logo";
            this.pictureBox_logo.Size = new System.Drawing.Size(305, 136);
            this.pictureBox_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_logo.TabIndex = 2;
            this.pictureBox_logo.TabStop = false;
            // 
            // panel_MostrarRutinas
            // 
            this.panel_MostrarRutinas.Controls.Add(this.label3);
            this.panel_MostrarRutinas.Controls.Add(this.label2);
            this.panel_MostrarRutinas.Controls.Add(this.dataGridViewEjercicio);
            this.panel_MostrarRutinas.Controls.Add(this.dataGridViewRutina);
            this.panel_MostrarRutinas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_MostrarRutinas.Location = new System.Drawing.Point(0, 24);
            this.panel_MostrarRutinas.Name = "panel_MostrarRutinas";
            this.panel_MostrarRutinas.Size = new System.Drawing.Size(702, 432);
            this.panel_MostrarRutinas.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(385, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(189, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ejercicios de la rutina";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Rutinas";
            // 
            // dataGridViewEjercicio
            // 
            this.dataGridViewEjercicio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEjercicio.Location = new System.Drawing.Point(389, 60);
            this.dataGridViewEjercicio.Name = "dataGridViewEjercicio";
            this.dataGridViewEjercicio.Size = new System.Drawing.Size(306, 349);
            this.dataGridViewEjercicio.TabIndex = 1;
            // 
            // dataGridViewRutina
            // 
            this.dataGridViewRutina.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRutina.Location = new System.Drawing.Point(24, 60);
            this.dataGridViewRutina.MultiSelect = false;
            this.dataGridViewRutina.Name = "dataGridViewRutina";
            this.dataGridViewRutina.Size = new System.Drawing.Size(306, 349);
            this.dataGridViewRutina.TabIndex = 0;
            this.dataGridViewRutina.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridViewRutina_KeyPress);
            // 
            // panel_CrearRutina
            // 
            this.panel_CrearRutina.Controls.Add(this.button_CambiarHora);
            this.panel_CrearRutina.Controls.Add(this.button_EliminarEjercicio);
            this.panel_CrearRutina.Controls.Add(this.button_AgrerarEjercicio2);
            this.panel_CrearRutina.Controls.Add(this.button_BuscarRutina);
            this.panel_CrearRutina.Controls.Add(this.label6);
            this.panel_CrearRutina.Controls.Add(this.textBox_ModificarrutinaId);
            this.panel_CrearRutina.Controls.Add(this.button_agregarEjercicios);
            this.panel_CrearRutina.Controls.Add(this.dataGridView_AgregarEjercicios);
            this.panel_CrearRutina.Controls.Add(this.label5);
            this.panel_CrearRutina.Controls.Add(this.textBox_CrearHorasRutina);
            this.panel_CrearRutina.Controls.Add(this.label4);
            this.panel_CrearRutina.Controls.Add(this.textBox_CrearIdRutina);
            this.panel_CrearRutina.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_CrearRutina.Location = new System.Drawing.Point(0, 24);
            this.panel_CrearRutina.Name = "panel_CrearRutina";
            this.panel_CrearRutina.Size = new System.Drawing.Size(702, 432);
            this.panel_CrearRutina.TabIndex = 4;
            // 
            // button_CambiarHora
            // 
            this.button_CambiarHora.Location = new System.Drawing.Point(389, 104);
            this.button_CambiarHora.Name = "button_CambiarHora";
            this.button_CambiarHora.Size = new System.Drawing.Size(99, 23);
            this.button_CambiarHora.TabIndex = 11;
            this.button_CambiarHora.Text = "Cambiar hora";
            this.button_CambiarHora.UseVisualStyleBackColor = true;
            this.button_CambiarHora.Click += new System.EventHandler(this.button_CambiarHora_Click);
            // 
            // button_EliminarEjercicio
            // 
            this.button_EliminarEjercicio.Location = new System.Drawing.Point(425, 386);
            this.button_EliminarEjercicio.Name = "button_EliminarEjercicio";
            this.button_EliminarEjercicio.Size = new System.Drawing.Size(75, 23);
            this.button_EliminarEjercicio.TabIndex = 10;
            this.button_EliminarEjercicio.Text = "Eliminar";
            this.button_EliminarEjercicio.UseVisualStyleBackColor = true;
            this.button_EliminarEjercicio.Click += new System.EventHandler(this.button_EliminarEjercicio_Click);
            // 
            // button_AgrerarEjercicio2
            // 
            this.button_AgrerarEjercicio2.Location = new System.Drawing.Point(196, 386);
            this.button_AgrerarEjercicio2.Name = "button_AgrerarEjercicio2";
            this.button_AgrerarEjercicio2.Size = new System.Drawing.Size(75, 23);
            this.button_AgrerarEjercicio2.TabIndex = 9;
            this.button_AgrerarEjercicio2.Text = "Agregar";
            this.button_AgrerarEjercicio2.UseVisualStyleBackColor = true;
            this.button_AgrerarEjercicio2.Click += new System.EventHandler(this.button_AgrerarEjercicio2_Click);
            // 
            // button_BuscarRutina
            // 
            this.button_BuscarRutina.Location = new System.Drawing.Point(389, 24);
            this.button_BuscarRutina.Name = "button_BuscarRutina";
            this.button_BuscarRutina.Size = new System.Drawing.Size(99, 23);
            this.button_BuscarRutina.TabIndex = 8;
            this.button_BuscarRutina.Text = "Buscar";
            this.button_BuscarRutina.UseVisualStyleBackColor = true;
            this.button_BuscarRutina.Click += new System.EventHandler(this.button2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(238, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Id";
            // 
            // textBox_ModificarrutinaId
            // 
            this.textBox_ModificarrutinaId.Location = new System.Drawing.Point(275, 27);
            this.textBox_ModificarrutinaId.Name = "textBox_ModificarrutinaId";
            this.textBox_ModificarrutinaId.Size = new System.Drawing.Size(100, 20);
            this.textBox_ModificarrutinaId.TabIndex = 6;
            // 
            // button_agregarEjercicios
            // 
            this.button_agregarEjercicios.Location = new System.Drawing.Point(308, 386);
            this.button_agregarEjercicios.Name = "button_agregarEjercicios";
            this.button_agregarEjercicios.Size = new System.Drawing.Size(75, 23);
            this.button_agregarEjercicios.TabIndex = 5;
            this.button_agregarEjercicios.Text = "Agregar";
            this.button_agregarEjercicios.UseVisualStyleBackColor = true;
            this.button_agregarEjercicios.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView_AgregarEjercicios
            // 
            this.dataGridView_AgregarEjercicios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_AgregarEjercicios.Location = new System.Drawing.Point(158, 137);
            this.dataGridView_AgregarEjercicios.Name = "dataGridView_AgregarEjercicios";
            this.dataGridView_AgregarEjercicios.Size = new System.Drawing.Size(376, 233);
            this.dataGridView_AgregarEjercicios.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(155, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Horas para la rutina";
            // 
            // textBox_CrearHorasRutina
            // 
            this.textBox_CrearHorasRutina.Location = new System.Drawing.Point(275, 107);
            this.textBox_CrearHorasRutina.Name = "textBox_CrearHorasRutina";
            this.textBox_CrearHorasRutina.Size = new System.Drawing.Size(108, 20);
            this.textBox_CrearHorasRutina.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(166, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Nombre de rutina";
            // 
            // textBox_CrearIdRutina
            // 
            this.textBox_CrearIdRutina.Location = new System.Drawing.Point(275, 66);
            this.textBox_CrearIdRutina.Name = "textBox_CrearIdRutina";
            this.textBox_CrearIdRutina.Size = new System.Drawing.Size(213, 20);
            this.textBox_CrearIdRutina.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.textBox_Descricpcion);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.dataGridView_aparatos);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.textBox_Repeticiones);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(702, 432);
            this.panel1.TabIndex = 12;
            // 
            // textBox_Descricpcion
            // 
            this.textBox_Descricpcion.Location = new System.Drawing.Point(132, 175);
            this.textBox_Descricpcion.MaxLength = 199;
            this.textBox_Descricpcion.Multiline = true;
            this.textBox_Descricpcion.Name = "textBox_Descricpcion";
            this.textBox_Descricpcion.Size = new System.Drawing.Size(198, 179);
            this.textBox_Descricpcion.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(63, 175);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Descripción";
            // 
            // dataGridView_aparatos
            // 
            this.dataGridView_aparatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_aparatos.Location = new System.Drawing.Point(369, 89);
            this.dataGridView_aparatos.MultiSelect = false;
            this.dataGridView_aparatos.Name = "dataGridView_aparatos";
            this.dataGridView_aparatos.Size = new System.Drawing.Size(311, 236);
            this.dataGridView_aparatos.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(57, 140);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Repeticiones";
            // 
            // textBox_Repeticiones
            // 
            this.textBox_Repeticiones.Location = new System.Drawing.Point(132, 137);
            this.textBox_Repeticiones.MaxLength = 4;
            this.textBox_Repeticiones.Name = "textBox_Repeticiones";
            this.textBox_Repeticiones.Size = new System.Drawing.Size(198, 20);
            this.textBox_Repeticiones.TabIndex = 1;
            this.textBox_Repeticiones.Leave += new System.EventHandler(this.textBox_Repeticiones_Leave);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(336, 376);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Instructor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(702, 456);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_CrearRutina);
            this.Controls.Add(this.panel_MostrarRutinas);
            this.Controls.Add(this.pictureBox_logo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Instructor";
            this.Text = "Instructor";
            this.Load += new System.EventHandler(this.Instructor_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_logo)).EndInit();
            this.panel_MostrarRutinas.ResumeLayout(false);
            this.panel_MostrarRutinas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEjercicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRutina)).EndInit();
            this.panel_CrearRutina.ResumeLayout(false);
            this.panel_CrearRutina.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_AgregarEjercicios)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_aparatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem rutinaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crearRutinaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ejercicioToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem mostrarToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox_logo;
        private System.Windows.Forms.Panel panel_MostrarRutinas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewEjercicio;
        private System.Windows.Forms.DataGridView dataGridViewRutina;
        private System.Windows.Forms.Panel panel_CrearRutina;
        private System.Windows.Forms.TextBox textBox_CrearIdRutina;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_agregarEjercicios;
        private System.Windows.Forms.DataGridView dataGridView_AgregarEjercicios;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_CrearHorasRutina;
        private System.Windows.Forms.ToolStripMenuItem crearEjercicioToolStripMenuItem;
        private System.Windows.Forms.Button button_BuscarRutina;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_ModificarrutinaId;
        private System.Windows.Forms.Button button_EliminarEjercicio;
        private System.Windows.Forms.Button button_AgrerarEjercicio2;
        private System.Windows.Forms.Button button_CambiarHora;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox_Descricpcion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dataGridView_aparatos;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_Repeticiones;
        private System.Windows.Forms.Button button1;
    }
}