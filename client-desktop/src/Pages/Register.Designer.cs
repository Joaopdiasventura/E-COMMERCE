namespace client_desktop.Pages
{
    partial class Register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nameInput = new System.Windows.Forms.MaskedTextBox();
            this.emailInput = new System.Windows.Forms.MaskedTextBox();
            this.passwordInput = new System.Windows.Forms.MaskedTextBox();
            this.cepInput = new System.Windows.Forms.MaskedTextBox();
            this.numberInput = new System.Windows.Forms.MaskedTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cepLabel = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "NOME:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "EMAIL:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "SENHA:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "CEP:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "NÚMERO:";
            // 
            // nameInput
            // 
            this.nameInput.BackColor = System.Drawing.Color.Black;
            this.nameInput.ForeColor = System.Drawing.Color.White;
            this.nameInput.Location = new System.Drawing.Point(15, 25);
            this.nameInput.Name = "nameInput";
            this.nameInput.Size = new System.Drawing.Size(100, 20);
            this.nameInput.TabIndex = 5;
            // 
            // emailInput
            // 
            this.emailInput.BackColor = System.Drawing.Color.Black;
            this.emailInput.ForeColor = System.Drawing.Color.White;
            this.emailInput.Location = new System.Drawing.Point(15, 64);
            this.emailInput.Name = "emailInput";
            this.emailInput.Size = new System.Drawing.Size(100, 20);
            this.emailInput.TabIndex = 6;
            // 
            // passwordInput
            // 
            this.passwordInput.BackColor = System.Drawing.Color.Black;
            this.passwordInput.ForeColor = System.Drawing.Color.White;
            this.passwordInput.Location = new System.Drawing.Point(15, 103);
            this.passwordInput.Name = "passwordInput";
            this.passwordInput.Size = new System.Drawing.Size(100, 20);
            this.passwordInput.TabIndex = 7;
            // 
            // cepInput
            // 
            this.cepInput.BackColor = System.Drawing.Color.Black;
            this.cepInput.ForeColor = System.Drawing.Color.White;
            this.cepInput.Location = new System.Drawing.Point(15, 142);
            this.cepInput.Name = "cepInput";
            this.cepInput.Size = new System.Drawing.Size(100, 20);
            this.cepInput.TabIndex = 8;
            // 
            // numberInput
            // 
            this.numberInput.BackColor = System.Drawing.Color.Black;
            this.numberInput.ForeColor = System.Drawing.Color.White;
            this.numberInput.Location = new System.Drawing.Point(15, 210);
            this.numberInput.Name = "numberInput";
            this.numberInput.Size = new System.Drawing.Size(100, 20);
            this.numberInput.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::client_desktop.Properties.Resources.preto;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(15, 168);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "VALIDAR CEP";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::client_desktop.Properties.Resources.preto;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Location = new System.Drawing.Point(12, 236);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "REGISTRAR-SE";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cepLabel
            // 
            this.cepLabel.AutoSize = true;
            this.cepLabel.Location = new System.Drawing.Point(121, 147);
            this.cepLabel.Name = "cepLabel";
            this.cepLabel.Size = new System.Drawing.Size(0, 13);
            this.cepLabel.TabIndex = 12;
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::client_desktop.Properties.Resources.preto;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.Location = new System.Drawing.Point(325, 426);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(147, 23);
            this.button3.TabIndex = 13;
            this.button3.Text = "VOLTAR PARA A PÁGINA INICAL";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.cepLabel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.numberInput);
            this.Controls.Add(this.cepInput);
            this.Controls.Add(this.passwordInput);
            this.Controls.Add(this.emailInput);
            this.Controls.Add(this.nameInput);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CRIAR CONTA";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox nameInput;
        private System.Windows.Forms.MaskedTextBox emailInput;
        private System.Windows.Forms.MaskedTextBox passwordInput;
        private System.Windows.Forms.MaskedTextBox cepInput;
        private System.Windows.Forms.MaskedTextBox numberInput;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label cepLabel;
        private System.Windows.Forms.Button button3;
    }
}