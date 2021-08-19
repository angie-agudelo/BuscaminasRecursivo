
namespace Buscaminas
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
            this.numVertical = new System.Windows.Forms.NumericUpDown();
            this.numHorizont = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numMinas = new System.Windows.Forms.NumericUpDown();
            this.pnlTablero = new System.Windows.Forms.Panel();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.lblMarcador = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numVertical)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHorizont)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinas)).BeginInit();
            this.SuspendLayout();
            // 
            // numVertical
            // 
            this.numVertical.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numVertical.Location = new System.Drawing.Point(9, 33);
            this.numVertical.Name = "numVertical";
            this.numVertical.Size = new System.Drawing.Size(59, 29);
            this.numVertical.TabIndex = 2;
            this.numVertical.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // numHorizont
            // 
            this.numHorizont.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numHorizont.Location = new System.Drawing.Point(78, 32);
            this.numHorizont.Name = "numHorizont";
            this.numHorizont.Size = new System.Drawing.Size(59, 29);
            this.numHorizont.TabIndex = 3;
            this.numHorizont.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Vertical";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(74, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Horizontal";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(157, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "# Minas";
            // 
            // numMinas
            // 
            this.numMinas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMinas.Location = new System.Drawing.Point(161, 32);
            this.numMinas.Name = "numMinas";
            this.numMinas.Size = new System.Drawing.Size(59, 29);
            this.numMinas.TabIndex = 6;
            this.numMinas.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // pnlTablero
            // 
            this.pnlTablero.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTablero.Location = new System.Drawing.Point(9, 87);
            this.pnlTablero.Name = "pnlTablero";
            this.pnlTablero.Size = new System.Drawing.Size(846, 341);
            this.pnlTablero.TabIndex = 9;
            // 
            // btnIniciar
            // 
            this.btnIniciar.BackgroundImage = global::Buscaminas.Properties.Resources.Play;
            this.btnIniciar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnIniciar.Location = new System.Drawing.Point(226, 23);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(40, 38);
            this.btnIniciar.TabIndex = 8;
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // lblMarcador
            // 
            this.lblMarcador.AutoSize = true;
            this.lblMarcador.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarcador.Location = new System.Drawing.Point(74, 64);
            this.lblMarcador.Name = "lblMarcador";
            this.lblMarcador.Size = new System.Drawing.Size(160, 20);
            this.lblMarcador.TabIndex = 11;
            this.lblMarcador.Text = "Bombas restantes:  0";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(282, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 34);
            this.button1.TabIndex = 12;
            this.button1.Text = "Server";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(352, 23);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(64, 34);
            this.button2.TabIndex = 13;
            this.button2.Text = "Cliente";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(422, 33);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(200, 20);
            this.textBox1.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 440);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblMarcador);
            this.Controls.Add(this.pnlTablero);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numMinas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numHorizont);
            this.Controls.Add(this.numVertical);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Busca minas";
            ((System.ComponentModel.ISupportInitialize)(this.numVertical)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHorizont)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown numVertical;
        private System.Windows.Forms.NumericUpDown numHorizont;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numMinas;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Panel pnlTablero;
        private System.Windows.Forms.Label lblMarcador;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
    }
}

