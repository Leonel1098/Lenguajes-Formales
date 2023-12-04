namespace Reproductor
{
    partial class Reproductor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reproductor));
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            this.MiReproductor = new AxWMPLib.AxWindowsMediaPlayer();
            this.MisCanciones = new System.Windows.Forms.ListView();
            this.nombre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.artista = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.album = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.year = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.duracion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.url = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.repe = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.reproducir = new System.Windows.Forms.Button();
            this.eliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MiReproductor)).BeginInit();
            this.SuspendLayout();
            // 
            // MiReproductor
            // 
            this.MiReproductor.Enabled = true;
            this.MiReproductor.Location = new System.Drawing.Point(12, 24);
            this.MiReproductor.Name = "MiReproductor";
            this.MiReproductor.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MiReproductor.OcxState")));
            this.MiReproductor.Size = new System.Drawing.Size(812, 45);
            this.MiReproductor.TabIndex = 0;
            this.MiReproductor.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.MiReproductor_PlayStateChange);
            // 
            // MisCanciones
            // 
            this.MisCanciones.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.MisCanciones.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nombre,
            this.artista,
            this.album,
            this.year,
            this.duracion,
            this.url,
            this.repe});
            this.MisCanciones.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MisCanciones.ForeColor = System.Drawing.Color.Turquoise;
            this.MisCanciones.FullRowSelect = true;
            listViewGroup1.Header = "ListViewGroup";
            listViewGroup1.Name = "Nombre";
            this.MisCanciones.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
            this.MisCanciones.Location = new System.Drawing.Point(12, 88);
            this.MisCanciones.Name = "MisCanciones";
            this.MisCanciones.Size = new System.Drawing.Size(834, 299);
            this.MisCanciones.TabIndex = 1;
            this.MisCanciones.UseCompatibleStateImageBehavior = false;
            this.MisCanciones.View = System.Windows.Forms.View.Details;
            // 
            // nombre
            // 
            this.nombre.Text = "Nombre";
            this.nombre.Width = 98;
            // 
            // artista
            // 
            this.artista.Text = "Artista";
            this.artista.Width = 107;
            // 
            // album
            // 
            this.album.Text = "Album";
            this.album.Width = 106;
            // 
            // year
            // 
            this.year.Text = "Año";
            this.year.Width = 59;
            // 
            // duracion
            // 
            this.duracion.Text = "Duracion";
            this.duracion.Width = 77;
            // 
            // url
            // 
            this.url.Text = "URL";
            this.url.Width = 241;
            // 
            // repe
            // 
            this.repe.Text = "Repeticion";
            this.repe.Width = 77;
            // 
            // reproducir
            // 
            this.reproducir.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.reproducir.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reproducir.Location = new System.Drawing.Point(78, 398);
            this.reproducir.Name = "reproducir";
            this.reproducir.Size = new System.Drawing.Size(127, 34);
            this.reproducir.TabIndex = 2;
            this.reproducir.Text = "Reproducir";
            this.reproducir.UseVisualStyleBackColor = false;
            this.reproducir.Click += new System.EventHandler(this.button1_Click);
            this.reproducir.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            this.reproducir.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            // 
            // eliminar
            // 
            this.eliminar.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eliminar.Location = new System.Drawing.Point(419, 398);
            this.eliminar.Name = "eliminar";
            this.eliminar.Size = new System.Drawing.Size(137, 34);
            this.eliminar.TabIndex = 3;
            this.eliminar.Text = "Eliminar";
            this.eliminar.UseVisualStyleBackColor = true;
            this.eliminar.Click += new System.EventHandler(this.eliminar_Click);
            // 
            // Reproductor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(858, 466);
            this.Controls.Add(this.eliminar);
            this.Controls.Add(this.reproducir);
            this.Controls.Add(this.MisCanciones);
            this.Controls.Add(this.MiReproductor);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Reproductor";
            this.Text = "Reproductor";
            this.TransparencyKey = System.Drawing.Color.Black;
            this.Load += new System.EventHandler(this.Reproductor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MiReproductor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer MiReproductor;
        private System.Windows.Forms.ListView MisCanciones;
        private System.Windows.Forms.ColumnHeader nombre;
        private System.Windows.Forms.ColumnHeader artista;
        private System.Windows.Forms.ColumnHeader album;
        private System.Windows.Forms.ColumnHeader year;
        private System.Windows.Forms.ColumnHeader duracion;
        private System.Windows.Forms.ColumnHeader url;
        private System.Windows.Forms.ColumnHeader repe;
        private System.Windows.Forms.Button reproducir;
        private System.Windows.Forms.Button eliminar;
    }
}