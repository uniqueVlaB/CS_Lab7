namespace CS_Lab1_2
{
    partial class TracksEditForm
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
            tracksGrid = new DataGridView();
            comboBox1 = new ComboBox();
            label1 = new Label();
            trackButton = new Button();
            deleteButton = new Button();
            filterTypeCB = new ComboBox();
            label2 = new Label();
            filterValueCB = new ComboBox();
            label3 = new Label();
            resetFiltersButton = new Button();
            ((System.ComponentModel.ISupportInitialize)tracksGrid).BeginInit();
            SuspendLayout();
            // 
            // tracksGrid
            // 
            tracksGrid.BackgroundColor = SystemColors.HotTrack;
            tracksGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tracksGrid.Location = new Point(12, 12);
            tracksGrid.Name = "tracksGrid";
            tracksGrid.RowTemplate.Height = 25;
            tracksGrid.Size = new Size(603, 426);
            tracksGrid.TabIndex = 0;
            tracksGrid.CellBeginEdit += tracksGrid_CellBeginEdit;
            tracksGrid.CellClick += tracksGrid_CellClick;
            tracksGrid.CellEndEdit += tracksGrid_CellEndEdit;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(631, 30);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(236, 23);
            comboBox1.TabIndex = 1;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(631, 11);
            label1.Name = "label1";
            label1.Size = new Size(173, 15);
            label1.TabIndex = 2;
            label1.Text = "Lists for author, genre or album";
            // 
            // trackButton
            // 
            trackButton.Location = new Point(631, 110);
            trackButton.Name = "trackButton";
            trackButton.Size = new Size(71, 42);
            trackButton.TabIndex = 3;
            trackButton.Text = "Add track form";
            trackButton.UseVisualStyleBackColor = true;
            trackButton.Click += trackButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(631, 59);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(98, 45);
            deleteButton.TabIndex = 4;
            deleteButton.Text = "Delete selected tracks";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // filterTypeCB
            // 
            filterTypeCB.FormattingEnabled = true;
            filterTypeCB.Items.AddRange(new object[] { "Author", "Album", "Genre" });
            filterTypeCB.Location = new Point(694, 161);
            filterTypeCB.Name = "filterTypeCB";
            filterTypeCB.Size = new Size(173, 23);
            filterTypeCB.TabIndex = 5;
            filterTypeCB.SelectedIndexChanged += filterTypeCB_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(621, 161);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 6;
            label2.Text = "Filter by:";
            // 
            // filterValueCB
            // 
            filterValueCB.FormattingEnabled = true;
            filterValueCB.Location = new Point(694, 190);
            filterValueCB.Name = "filterValueCB";
            filterValueCB.Size = new Size(173, 23);
            filterValueCB.TabIndex = 7;
            filterValueCB.SelectedIndexChanged += filterValueCB_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(621, 190);
            label3.Name = "label3";
            label3.Size = new Size(67, 15);
            label3.TabIndex = 8;
            label3.Text = "Filter value:";
            // 
            // resetFiltersButton
            // 
            resetFiltersButton.Location = new Point(792, 219);
            resetFiltersButton.Name = "resetFiltersButton";
            resetFiltersButton.Size = new Size(75, 23);
            resetFiltersButton.TabIndex = 9;
            resetFiltersButton.Text = "Reset filters";
            resetFiltersButton.UseVisualStyleBackColor = true;
            resetFiltersButton.Click += resetFiltersButton_Click;
            // 
            // TracksEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gold;
            ClientSize = new Size(879, 450);
            Controls.Add(resetFiltersButton);
            Controls.Add(label3);
            Controls.Add(filterValueCB);
            Controls.Add(label2);
            Controls.Add(filterTypeCB);
            Controls.Add(deleteButton);
            Controls.Add(trackButton);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(tracksGrid);
            Name = "TracksEditForm";
            Text = "TracksEditForm";
            Load += TracksEditForm_Load;
            ((System.ComponentModel.ISupportInitialize)tracksGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView tracksGrid;
        private ComboBox comboBox1;
        private Label label1;
        private Button trackButton;
        private Button deleteButton;
        private ComboBox filterTypeCB;
        private Label label2;
        private ComboBox filterValueCB;
        private Label label3;
        private Button resetFiltersButton;
    }
}