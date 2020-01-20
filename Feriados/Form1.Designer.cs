namespace Feriados
{
    partial class FrmFeriados
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
            this.label1 = new System.Windows.Forms.Label();
            this.maskedTxtB_ano = new System.Windows.Forms.MaskedTextBox();
            this.button_calcular = new System.Windows.Forms.Button();
            this.richTxtB_resultado = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ano:";
            // 
            // maskedTxtB_ano
            // 
            this.maskedTxtB_ano.Location = new System.Drawing.Point(53, 18);
            this.maskedTxtB_ano.Mask = "0000";
            this.maskedTxtB_ano.Name = "maskedTxtB_ano";
            this.maskedTxtB_ano.Size = new System.Drawing.Size(99, 20);
            this.maskedTxtB_ano.TabIndex = 1;
            this.maskedTxtB_ano.ValidatingType = typeof(int);
            // 
            // button_calcular
            // 
            this.button_calcular.Location = new System.Drawing.Point(177, 18);
            this.button_calcular.Name = "button_calcular";
            this.button_calcular.Size = new System.Drawing.Size(128, 23);
            this.button_calcular.TabIndex = 2;
            this.button_calcular.Text = "Calcular feriados";
            this.button_calcular.UseVisualStyleBackColor = true;
            this.button_calcular.Click += new System.EventHandler(this.button_calcular_Click);
            // 
            // richTxtB_resultado
            // 
            this.richTxtB_resultado.Location = new System.Drawing.Point(12, 63);
            this.richTxtB_resultado.Name = "richTxtB_resultado";
            this.richTxtB_resultado.Size = new System.Drawing.Size(345, 294);
            this.richTxtB_resultado.TabIndex = 3;
            this.richTxtB_resultado.Text = "";
            // 
            // FrmFeriados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 369);
            this.Controls.Add(this.richTxtB_resultado);
            this.Controls.Add(this.button_calcular);
            this.Controls.Add(this.maskedTxtB_ano);
            this.Controls.Add(this.label1);
            this.Name = "FrmFeriados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculadora de feriados";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox maskedTxtB_ano;
        private System.Windows.Forms.Button button_calcular;
        private System.Windows.Forms.RichTextBox richTxtB_resultado;
    }
}

