namespace CS_Lab1_2
{
    partial class EditAlbumsForm
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
            albumsGrid = new DataGridView();
            authorCB = new ComboBox();
            label1 = new Label();
            albumNameTB = new TextBox();
            addButton = new Button();
            deleteButton = new Button();
            label2 = new Label();
            resetButton = new Button();
            ((System.ComponentModel.ISupportInitialize)albumsGrid).BeginInit();
            SuspendLayout();
            // 
            // albumsGrid
            // 
            albumsGrid.BackgroundColor = SystemColors.HotTrack;
            albumsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            albumsGrid.Location = new Point(12, 12);
            albumsGrid.Name = "albumsGrid";
            albumsGrid.RowTemplate.Height = 25;
            albumsGrid.Size = new Size(243, 426);
            albumsGrid.TabIndex = 0;
            albumsGrid.CellBeginEdit += albumsGrid_CellBeginEdit;
            albumsGrid.CellEndEdit += albumsGrid_CellEndEdit;
            // 
            // authorCB
            // 
            authorCB.FormattingEnabled = true;
            authorCB.Location = new Point(340, 9);
            authorCB.Name = "authorCB";
            authorCB.Size = new Size(182, 23);
            authorCB.TabIndex = 1;
            authorCB.SelectedIndexChanged += authorCB_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(261, 12);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 2;
            label1.Text = "Author:";
            // 
            // albumNameTB
            // 
            albumNameTB.AccessibleDescription = "bmnghm";
            albumNameTB.Location = new Point(340, 38);
            albumNameTB.Name = "albumNameTB";
            albumNameTB.Size = new Size(182, 23);
            albumNameTB.TabIndex = 3;
            // 
            // addButton
            // 
            addButton.Location = new Point(437, 67);
            addButton.Name = "addButton";
            addButton.Size = new Size(85, 23);
            addButton.TabIndex = 4;
            addButton.Text = "Add album";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(261, 148);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(101, 41);
            deleteButton.TabIndex = 5;
            deleteButton.Text = "Delete selected albums";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(261, 41);
            label2.Name = "label2";
            label2.Size = new Size(79, 15);
            label2.TabIndex = 6;
            label2.Text = "Album name:";
            // 
            // resetButton
            // 
            resetButton.Location = new Point(575, 37);
            resetButton.Name = "resetButton";
            resetButton.Size = new Size(75, 23);
            resetButton.TabIndex = 7;
            resetButton.Text = "Reset";
            resetButton.UseVisualStyleBackColor = true;
            resetButton.Click += resetButton_Click;
            // 
            // EditAlbumsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gold;
            ClientSize = new Size(800, 450);
            Controls.Add(resetButton);
            Controls.Add(label2);
            Controls.Add(deleteButton);
            Controls.Add(addButton);
            Controls.Add(albumNameTB);
            Controls.Add(label1);
            Controls.Add(authorCB);
            Controls.Add(albumsGrid);
            Name = "EditAlbumsForm";
            Tag = "Print album name";
            Text = "EditAlbumsForm";
            Load += EditAlbumsForm_Load;
            ((System.ComponentModel.ISupportInitialize)albumsGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView albumsGrid;
        private ComboBox authorCB;
        private Label label1;
        private TextBox albumNameTB;
        private Button addButton;
        private Button deleteButton;
        private Label label2;
        private Button resetButton;
    }
}