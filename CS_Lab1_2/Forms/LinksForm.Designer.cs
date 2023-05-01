namespace CS_Lab1_2
{
    partial class LinksForm
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
            linksCB = new ComboBox();
            label1 = new Label();
            valueCB = new ComboBox();
            label2 = new Label();
            valuesGrid = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)valuesGrid).BeginInit();
            SuspendLayout();
            // 
            // linksCB
            // 
            linksCB.FormattingEnabled = true;
            linksCB.Items.AddRange(new object[] { "Author-Genres", "Author-Tracks", "Genre-Tracks" });
            linksCB.Location = new Point(581, 12);
            linksCB.Name = "linksCB";
            linksCB.Size = new Size(207, 23);
            linksCB.TabIndex = 1;
            linksCB.SelectedIndexChanged += linksCB_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(487, 15);
            label1.Name = "label1";
            label1.Size = new Size(89, 15);
            label1.TabIndex = 2;
            label1.Text = "Select link type:";
            // 
            // valueCB
            // 
            valueCB.FormattingEnabled = true;
            valueCB.Location = new Point(581, 41);
            valueCB.Name = "valueCB";
            valueCB.Size = new Size(207, 23);
            valueCB.TabIndex = 3;
            valueCB.SelectedIndexChanged += valueCB_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(503, 41);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 4;
            label2.Text = "Select value:";
            // 
            // valuesGrid
            // 
            valuesGrid.AllowUserToOrderColumns = true;
            valuesGrid.BackgroundColor = SystemColors.HotTrack;
            valuesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            valuesGrid.Location = new Point(9, 12);
            valuesGrid.Name = "valuesGrid";
            valuesGrid.RowTemplate.Height = 25;
            valuesGrid.Size = new Size(472, 426);
            valuesGrid.TabIndex = 5;
            // 
            // LinksForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gold;
            ClientSize = new Size(800, 450);
            Controls.Add(valuesGrid);
            Controls.Add(label2);
            Controls.Add(valueCB);
            Controls.Add(label1);
            Controls.Add(linksCB);
            Name = "LinksForm";
            Text = "LinksForm";
            Load += LinksForm_Load;
            ((System.ComponentModel.ISupportInitialize)valuesGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox linksCB;
        private Label label1;
        private ComboBox valueCB;
        private Label label2;
        private DataGridView valuesGrid;
    }
}