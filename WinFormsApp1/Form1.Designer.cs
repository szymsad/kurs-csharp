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
            chartType = new Button();
            panel2 = new Panel();
            dateTo = new DateTimePicker();
            dateFrom = new DateTimePicker();
            dataGridView2 = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // load_csv
            // 
            load_csv.Anchor = AnchorStyles.Bottom;
            load_csv.Location = new Point(332, 335);
            load_csv.Name = "load_csv";
            load_csv.Size = new Size(99, 23);
            load_csv.TabIndex = 0;
            load_csv.Text = "Wczytaj CSV";
            load_csv.UseVisualStyleBackColor = true;
            load_csv.Click += button1_Click;
            // 
            // chartType
            // 
            chartType.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            chartType.Location = new Point(12, 335);
            chartType.Name = "chartType";
            chartType.Size = new Size(75, 23);
            chartType.TabIndex = 1;
            chartType.Text = "Produkty";
            chartType.UseVisualStyleBackColor = true;
            chartType.Click += chartType_Click;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel2.Location = new Point(370, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(422, 329);
            panel2.TabIndex = 3;
            // 
            // dateTo
            // 
            dateTo.Format = DateTimePickerFormat.Short;
            dateTo.Location = new Point(655, 335);
            dateTo.MaxDate = new DateTime(2030, 12, 31, 0, 0, 0, 0);
            dateTo.MinDate = new DateTime(2024, 1, 1, 0, 0, 0, 0);
            dateTo.Name = "dateTo";
            dateTo.Size = new Size(76, 23);
            dateTo.TabIndex = 1;
            dateTo.ValueChanged += dateTo_ValueChanged;
            // 
            // dateFrom
            // 
            dateFrom.Format = DateTimePickerFormat.Short;
            dateFrom.Location = new Point(517, 335);
            dateFrom.MaxDate = new DateTime(2030, 12, 31, 0, 0, 0, 0);
            dateFrom.MinDate = new DateTime(2024, 1, 1, 0, 0, 0, 0);
            dateFrom.Name = "dateFrom";
            dateFrom.Size = new Size(76, 23);
            dateFrom.TabIndex = 0;
            dateFrom.ValueChanged += dateFrom_ValueChanged;
            // 
            // dataGridView2
            // 
            dataGridView2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(1, 0);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(363, 329);
            dataGridView2.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(485, 339);
            label1.Name = "label1";
            label1.Size = new Size(26, 15);
            label1.TabIndex = 5;
            label1.Text = "Od:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(623, 339);
            label2.Name = "label2";
            label2.Size = new Size(25, 15);
            label2.TabIndex = 6;
            label2.Text = "Do:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(792, 370);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dateTo);
            Controls.Add(dataGridView2);
            Controls.Add(dateFrom);
            Controls.Add(panel2);
            Controls.Add(chartType);
            Controls.Add(load_csv);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button load_csv;
        private Button chartType;
        private Panel panel2;
        private DataGridView dataGridView2;
        private DateTimePicker dateTo;
        private DateTimePicker dateFrom;
        private Label label1;
        private Label label2;
    }
}
