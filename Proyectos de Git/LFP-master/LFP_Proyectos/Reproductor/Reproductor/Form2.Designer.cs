namespace Reproductor
{
    partial class Tokens
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
            this.tablatoken = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.tablatoken)).BeginInit();
            this.SuspendLayout();
            // 
            // tablatoken
            // 
            this.tablatoken.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablatoken.Location = new System.Drawing.Point(24, 12);
            this.tablatoken.Name = "tablatoken";
            this.tablatoken.Size = new System.Drawing.Size(793, 470);
            this.tablatoken.TabIndex = 0;
            // 
            // Tokens
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 494);
            this.Controls.Add(this.tablatoken);
            this.Name = "Tokens";
            this.Text = "Tabla de Tokens";
            this.Load += new System.EventHandler(this.Tokens_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablatoken)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tablatoken;
    }
}