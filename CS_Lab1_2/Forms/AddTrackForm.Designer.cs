namespace CS_Lab1_2
{
    partial class AddTrackForm
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
            timeTextBox = new TextBox();
            nameTextBox = new TextBox();
            authorCB = new ComboBox();
            genreCB = new ComboBox();
            addButton = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            albumCB = new ComboBox();
            SuspendLayout();
            // 
            // timeTextBox
            // 
            timeTextBox.BackColor = Color.LightBlue;
            timeTextBox.Location = new Point(12, 26);
            timeTextBox.Name = "timeTextBox";
            timeTextBox.Size = new Size(181, 23);
            timeTextBox.TabIndex = 0;
            // 
            // nameTextBox
            // 
            nameTextBox.BackColor = Color.LightBlue;
            nameTextBox.Location = new Point(12, 79);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(181, 23);
            nameTextBox.TabIndex = 1;
            // 
            // authorCB
            // 
            authorCB.BackColor = Color.LightBlue;
            authorCB.FormattingEnabled = true;
            authorCB.Location = new Point(232, 26);
            authorCB.Name = "authorCB";
            authorCB.Size = new Size(181, 23);
            authorCB.TabIndex = 3;
            authorCB.SelectedIndexChanged += authorCB_SelectedIndexChanged;
            // 
            // genreCB
            // 
            genreCB.BackColor = Color.LightBlue;
            genreCB.FormattingEnabled = true;
            genreCB.Location = new Point(232, 79);
            genreCB.Name = "genreCB";
            genreCB.Size = new Size(181, 23);
            genreCB.TabIndex = 4;
            // 
            // addButton
            // 
            addButton.Location = new Point(287, 136);
            addButton.Name = "addButton";
            addButton.Size = new Size(75, 23);
            addButton.TabIndex = 5;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(74, 8);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 6;
            label1.Text = "Time(Sec.)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(83, 61);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 7;
            label2.Text = "Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(83, 118);
            label3.Name = "label3";
            label3.Size = new Size(43, 15);
            label3.TabIndex = 8;
            label3.Text = "Album";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(300, 8);
            label4.Name = "label4";
            label4.Size = new Size(44, 15);
            label4.TabIndex = 9;
            label4.Text = "Author";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(306, 61);
            label5.Name = "label5";
            label5.Size = new Size(38, 15);
            label5.TabIndex = 10;
            label5.Text = "Genre";
            // 
            // albumCB
            // 
            albumCB.BackColor = Color.LightBlue;
            albumCB.FormattingEnabled = true;
            albumCB.Location = new Point(12, 137);
            albumCB.Name = "albumCB";
            albumCB.Size = new Size(181, 23);
            albumCB.TabIndex = 11;
            // 
            // AddTrackForm
            // 
            BackColor = Color.Gold;
            ClientSize = new Size(449, 212);
            Controls.Add(albumCB);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(addButton);
            Controls.Add(genreCB);
            Controls.Add(authorCB);
            Controls.Add(nameTextBox);
            Controls.Add(timeTextBox);
            Name = "AddTrackForm";
            Text = "Add Track";
            Load += AddTrackForm_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private TextBox timeTextBox;
        private TextBox nameTextBox;
        private ComboBox authorCB;
        private ComboBox genreCB;
        private Button addButton;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private ComboBox albumCB;
    }
}