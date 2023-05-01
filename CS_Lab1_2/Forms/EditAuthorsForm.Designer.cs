namespace CS_Lab1_2
{
    partial class EditAuthorsForm
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
            authorNameLabel = new Label();
            deleteButton = new Button();
            addButton = new Button();
            authorNameTB = new TextBox();
            authorsGrid = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)authorsGrid).BeginInit();
            SuspendLayout();
            // 
            // authorNameLabel
            // 
            authorNameLabel.AutoSize = true;
            authorNameLabel.Location = new Point(267, 15);
            authorNameLabel.Name = "authorNameLabel";
            authorNameLabel.Size = new Size(80, 15);
            authorNameLabel.TabIndex = 14;
            authorNameLabel.Text = "Author name:";
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(261, 148);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(101, 41);
            deleteButton.TabIndex = 13;
            deleteButton.Text = "Delete selected authors";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // addButton
            // 
            addButton.Location = new Point(443, 41);
            addButton.Name = "addButton";
            addButton.Size = new Size(85, 23);
            addButton.TabIndex = 12;
            addButton.Text = "Add author";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // authorNameTB
            // 
            authorNameTB.AccessibleDescription = "bmnghm";
            authorNameTB.Location = new Point(346, 12);
            authorNameTB.Name = "authorNameTB";
            authorNameTB.Size = new Size(182, 23);
            authorNameTB.TabIndex = 11;
            // 
            // authorsGrid
            // 
            authorsGrid.BackgroundColor = SystemColors.HotTrack;
            authorsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            authorsGrid.Location = new Point(12, 12);
            authorsGrid.Name = "authorsGrid";
            authorsGrid.RowTemplate.Height = 25;
            authorsGrid.Size = new Size(243, 426);
            authorsGrid.TabIndex = 8;
            authorsGrid.CellBeginEdit += authorsGrid_CellBeginEdit;
            authorsGrid.CellEndEdit += authorsGrid_CellEndEdit;
            // 
            // EditAuthorsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gold;
            ClientSize = new Size(800, 450);
            Controls.Add(authorNameLabel);
            Controls.Add(deleteButton);
            Controls.Add(addButton);
            Controls.Add(authorNameTB);
            Controls.Add(authorsGrid);
            Name = "EditAuthorsForm";
            Text = "EditAuthorsForm";
            Load += EditAuthorsForm_Load;
            ((System.ComponentModel.ISupportInitialize)authorsGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label authorNameLabel;
        private Button deleteButton;
        private Button addButton;
        private TextBox authorNameTB;
        private DataGridView authorsGrid;
    }
}