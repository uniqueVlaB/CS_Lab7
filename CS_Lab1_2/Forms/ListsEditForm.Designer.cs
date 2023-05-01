namespace CS_Lab1_2
{
    partial class ListsEditForm
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
            dataGridView1 = new DataGridView();
            authorRButton = new RadioButton();
            genreRButton = new RadioButton();
            addItemButton = new Button();
            addItemText = new TextBox();
            label1 = new Label();
            DeteleItemButton = new Button();
            albumRButton = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowDrop = true;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(21, 11);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(257, 406);
            dataGridView1.TabIndex = 0;
            // 
            // authorRButton
            // 
            authorRButton.AutoSize = true;
            authorRButton.Checked = true;
            authorRButton.Location = new Point(284, 12);
            authorRButton.Name = "authorRButton";
            authorRButton.Size = new Size(83, 19);
            authorRButton.TabIndex = 1;
            authorRButton.TabStop = true;
            authorRButton.Text = "Author List";
            authorRButton.UseVisualStyleBackColor = true;
            authorRButton.CheckedChanged += authorRButton_CheckedChanged;
            // 
            // genreRButton
            // 
            genreRButton.AutoSize = true;
            genreRButton.Location = new Point(284, 37);
            genreRButton.Name = "genreRButton";
            genreRButton.Size = new Size(77, 19);
            genreRButton.TabIndex = 2;
            genreRButton.Text = "Genre List";
            genreRButton.UseVisualStyleBackColor = true;
            genreRButton.CheckedChanged += genreRButton_CheckedChanged;
            // 
            // addItemButton
            // 
            addItemButton.Location = new Point(481, 121);
            addItemButton.Name = "addItemButton";
            addItemButton.Size = new Size(65, 23);
            addItemButton.TabIndex = 3;
            addItemButton.Text = "Add item";
            addItemButton.UseVisualStyleBackColor = true;
            addItemButton.Click += addItemButton_Click;
            // 
            // addItemText
            // 
            addItemText.Location = new Point(343, 92);
            addItemText.Name = "addItemText";
            addItemText.Size = new Size(203, 23);
            addItemText.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(282, 95);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 5;
            label1.Text = "Print text";
            // 
            // DeteleItemButton
            // 
            DeteleItemButton.Location = new Point(343, 121);
            DeteleItemButton.Name = "DeteleItemButton";
            DeteleItemButton.Size = new Size(132, 23);
            DeteleItemButton.TabIndex = 6;
            DeteleItemButton.Text = "Delete selected items";
            DeteleItemButton.UseVisualStyleBackColor = true;
            DeteleItemButton.Click += DeteleItemButton_Click;
            // 
            // albumRButton
            // 
            albumRButton.AutoSize = true;
            albumRButton.Location = new Point(284, 62);
            albumRButton.Name = "albumRButton";
            albumRButton.Size = new Size(82, 19);
            albumRButton.TabIndex = 7;
            albumRButton.Text = "Album List";
            albumRButton.UseVisualStyleBackColor = true;
            albumRButton.CheckedChanged += albumRButton_CheckedChanged;
            // 
            // ListsEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(albumRButton);
            Controls.Add(DeteleItemButton);
            Controls.Add(label1);
            Controls.Add(addItemText);
            Controls.Add(addItemButton);
            Controls.Add(genreRButton);
            Controls.Add(authorRButton);
            Controls.Add(dataGridView1);
            Name = "ListsEditForm";
            Text = "ListsEditForm";
            Load += ListsEditForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private RadioButton authorRButton;
        private RadioButton genreRButton;
        private Button addItemButton;
        private TextBox addItemText;
        private Label label1;
        private Button DeteleItemButton;
        private RadioButton albumRButton;
    }
}