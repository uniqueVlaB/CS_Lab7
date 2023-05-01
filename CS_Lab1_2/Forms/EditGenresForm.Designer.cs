namespace CS_Lab1_2
{
    partial class EditGenresForm
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
            genreNameLabel = new Label();
            deleteButton = new Button();
            addButton = new Button();
            genreNameTB = new TextBox();
            genresGrid = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)genresGrid).BeginInit();
            SuspendLayout();
            // 
            // genreNameLabel
            // 
            genreNameLabel.AutoSize = true;
            genreNameLabel.Location = new Point(267, 15);
            genreNameLabel.Name = "genreNameLabel";
            genreNameLabel.Size = new Size(74, 15);
            genreNameLabel.TabIndex = 19;
            genreNameLabel.Text = "Genre name:";
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(261, 148);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(101, 41);
            deleteButton.TabIndex = 18;
            deleteButton.Text = "Delete selected genres";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // addButton
            // 
            addButton.Location = new Point(443, 41);
            addButton.Name = "addButton";
            addButton.Size = new Size(85, 23);
            addButton.TabIndex = 17;
            addButton.Text = "Add genre";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // genreNameTB
            // 
            genreNameTB.AccessibleDescription = "bmnghm";
            genreNameTB.Location = new Point(346, 12);
            genreNameTB.Name = "genreNameTB";
            genreNameTB.Size = new Size(182, 23);
            genreNameTB.TabIndex = 16;
            // 
            // genresGrid
            // 
            genresGrid.BackgroundColor = SystemColors.HotTrack;
            genresGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            genresGrid.Location = new Point(12, 12);
            genresGrid.Name = "genresGrid";
            genresGrid.RowTemplate.Height = 25;
            genresGrid.Size = new Size(243, 426);
            genresGrid.TabIndex = 15;
            genresGrid.CellBeginEdit += genresGrid_CellBeginEdit;
            genresGrid.CellEndEdit += genresGrid_CellEndEdit;
            // 
            // EditGenresForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gold;
            ClientSize = new Size(800, 450);
            Controls.Add(genreNameLabel);
            Controls.Add(deleteButton);
            Controls.Add(addButton);
            Controls.Add(genreNameTB);
            Controls.Add(genresGrid);
            Name = "EditGenresForm";
            Text = "EditGenresForm";
            Load += EditGenresForm_Load;
            ((System.ComponentModel.ISupportInitialize)genresGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label genreNameLabel;
        private Button deleteButton;
        private Button addButton;
        private TextBox genreNameTB;
        private DataGridView genresGrid;
    }
}