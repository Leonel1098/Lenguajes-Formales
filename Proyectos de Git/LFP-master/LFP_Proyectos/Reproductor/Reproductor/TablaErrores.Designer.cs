namespace Reproductor
{
    partial class TablaErrores
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
            this.tablaError = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.tablaError)).BeginInit();
            this.SuspendLayout();
            // 
            // tablaError
            // 
            this.tablaError.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaError.Location = new System.Drawing.Point(12, 12);
            this.tablaError.Name = "tablaError";
            this.tablaError.Size = new System.Drawing.Size(851, 486);
            this.tablaError.TabIndex = 0;
            // 
            // TablaErrores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 510);
            this.Controls.Add(this.tablaError);
            this.Name = "TablaErrores";
            this.Text = "TablaErrores";
            this.Load += new System.EventHandler(this.TablaErrores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablaError)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tablaError;
    }
}