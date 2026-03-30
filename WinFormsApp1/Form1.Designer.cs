namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            load_csv = new Button();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // load_csv
            // 
            load_csv.Location = new Point(343, 335);
            load_csv.Name = "load_csv";
            load_csv.Size = new Size(99, 23);
            load_csv.TabIndex = 0;
            load_csv.Text = "Wczytaj CSV";
            load_csv.UseVisualStyleBackColor = true;
            load_csv.Click += button1_Click;
            // 
            // button1
            // 
            button1.Location = new Point(12, 335);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "kategorie";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // button2
            // 
            button2.Location = new Point(93, 335);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 2;
            button2.Text = "produkty";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(792, 370);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(load_csv);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button load_csv;
        private Button button1;
        private Button button2;
    }
}
