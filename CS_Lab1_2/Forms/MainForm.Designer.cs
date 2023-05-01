namespace CS_Lab1_2
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            tracksGrid = new DataGridView();
            sortButton = new Button();
            ascRButton = new RadioButton();
            desRButton = new RadioButton();
            sortCBox = new ComboBox();
            label1 = new Label();
            EditTracksButton = new Button();
            loadButton = new Button();
            bindingSource1 = new BindingSource(components);
            resetFiltersButton = new Button();
            label3 = new Label();
            filterValueCB = new ComboBox();
            label2 = new Label();
            filterTypeCB = new ComboBox();
            editAuthorsButton = new Button();
            editAlbumsButton = new Button();
            editGenresButton = new Button();
            linksButton = new Button();
            ((System.ComponentModel.ISupportInitialize)tracksGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // tracksGrid
            // 
            tracksGrid.AllowUserToAddRows = false;
            tracksGrid.AllowUserToDeleteRows = false;
            tracksGrid.AllowUserToResizeColumns = false;
            tracksGrid.AllowUserToResizeRows = false;
            tracksGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            tracksGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            tracksGrid.BackgroundColor = SystemColors.HotTrack;
            tracksGrid.BorderStyle = BorderStyle.None;
            tracksGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tracksGrid.GridColor = SystemColors.ActiveCaptionText;
            tracksGrid.Location = new Point(12, 12);
            tracksGrid.Name = "tracksGrid";
            tracksGrid.ReadOnly = true;
            tracksGrid.RowTemplate.Height = 25;
            tracksGrid.Size = new Size(726, 426);
            tracksGrid.TabIndex = 0;
            // 
            // sortButton
            // 
            sortButton.Location = new Point(893, 39);
            sortButton.Name = "sortButton";
            sortButton.Size = new Size(75, 23);
            sortButton.TabIndex = 1;
            sortButton.Text = "Sort";
            sortButton.UseVisualStyleBackColor = true;
            sortButton.Click += sortButton_Click;
            // 
            // ascRButton
            // 
            ascRButton.AutoSize = true;
            ascRButton.Checked = true;
            ascRButton.Location = new Point(799, 39);
            ascRButton.Name = "ascRButton";
            ascRButton.Size = new Size(81, 19);
            ascRButton.TabIndex = 2;
            ascRButton.TabStop = true;
            ascRButton.Text = "Ascending";
            ascRButton.UseVisualStyleBackColor = true;
            // 
            // desRButton
            // 
            desRButton.AutoSize = true;
            desRButton.Location = new Point(799, 64);
            desRButton.Name = "desRButton";
            desRButton.Size = new Size(87, 19);
            desRButton.TabIndex = 3;
            desRButton.Text = "Descending";
            desRButton.UseVisualStyleBackColor = true;
            // 
            // sortCBox
            // 
            sortCBox.FormattingEnabled = true;
            sortCBox.Items.AddRange(new object[] { "Album", "Author", "Genre", "Name" });
            sortCBox.Location = new Point(799, 10);
            sortCBox.Name = "sortCBox";
            sortCBox.Size = new Size(169, 23);
            sortCBox.Sorted = true;
            sortCBox.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(746, 15);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 5;
            label1.Text = "Sort by:";
            // 
            // EditTracksButton
            // 
            EditTracksButton.Location = new Point(746, 228);
            EditTracksButton.Name = "EditTracksButton";
            EditTracksButton.Size = new Size(82, 23);
            EditTracksButton.TabIndex = 7;
            EditTracksButton.Text = "Edit Tracks";
            EditTracksButton.UseVisualStyleBackColor = true;
            EditTracksButton.Click += EditTracksButton_Click;
            // 
            // loadButton
            // 
            loadButton.Location = new Point(799, 417);
            loadButton.Name = "loadButton";
            loadButton.Size = new Size(75, 23);
            loadButton.TabIndex = 9;
            loadButton.Text = "Load";
            loadButton.UseVisualStyleBackColor = true;
            loadButton.Click += loadButton_Click;
            // 
            // resetFiltersButton
            // 
            resetFiltersButton.Location = new Point(915, 152);
            resetFiltersButton.Name = "resetFiltersButton";
            resetFiltersButton.Size = new Size(75, 23);
            resetFiltersButton.TabIndex = 16;
            resetFiltersButton.Text = "Reset filters";
            resetFiltersButton.UseVisualStyleBackColor = true;
            resetFiltersButton.Click += resetFiltersButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(744, 123);
            label3.Name = "label3";
            label3.Size = new Size(67, 15);
            label3.TabIndex = 15;
            label3.Text = "Filter value:";
            // 
            // filterValueCB
            // 
            filterValueCB.FormattingEnabled = true;
            filterValueCB.Location = new Point(817, 123);
            filterValueCB.Name = "filterValueCB";
            filterValueCB.Size = new Size(173, 23);
            filterValueCB.TabIndex = 14;
            filterValueCB.SelectedIndexChanged += filterValueCB_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(744, 94);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 13;
            label2.Text = "Filter by:";
            // 
            // filterTypeCB
            // 
            filterTypeCB.FormattingEnabled = true;
            filterTypeCB.Items.AddRange(new object[] { "Author", "Album", "Genre" });
            filterTypeCB.Location = new Point(817, 94);
            filterTypeCB.Name = "filterTypeCB";
            filterTypeCB.Size = new Size(173, 23);
            filterTypeCB.TabIndex = 12;
            filterTypeCB.SelectedIndexChanged += filterTypeCB_SelectedIndexChanged;
            // 
            // editAuthorsButton
            // 
            editAuthorsButton.Location = new Point(834, 228);
            editAuthorsButton.Name = "editAuthorsButton";
            editAuthorsButton.Size = new Size(82, 23);
            editAuthorsButton.TabIndex = 17;
            editAuthorsButton.Text = "Edit authors";
            editAuthorsButton.UseVisualStyleBackColor = true;
            editAuthorsButton.Click += editAuthorsButton_Click;
            // 
            // editAlbumsButton
            // 
            editAlbumsButton.Location = new Point(746, 257);
            editAlbumsButton.Name = "editAlbumsButton";
            editAlbumsButton.Size = new Size(82, 23);
            editAlbumsButton.TabIndex = 18;
            editAlbumsButton.Text = "Edit albums";
            editAlbumsButton.UseVisualStyleBackColor = true;
            editAlbumsButton.Click += editAlbumsButton_Click;
            // 
            // editGenresButton
            // 
            editGenresButton.Location = new Point(834, 257);
            editGenresButton.Name = "editGenresButton";
            editGenresButton.Size = new Size(82, 23);
            editGenresButton.TabIndex = 19;
            editGenresButton.Text = "Edit genres";
            editGenresButton.UseVisualStyleBackColor = true;
            editGenresButton.Click += editGenresButton_Click;
            // 
            // linksButton
            // 
            linksButton.Location = new Point(746, 286);
            linksButton.Name = "linksButton";
            linksButton.Size = new Size(82, 23);
            linksButton.TabIndex = 20;
            linksButton.Text = "Links";
            linksButton.UseVisualStyleBackColor = true;
            linksButton.Click += linksButton_Click_1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gold;
            ClientSize = new Size(1002, 450);
            Controls.Add(linksButton);
            Controls.Add(editGenresButton);
            Controls.Add(editAlbumsButton);
            Controls.Add(editAuthorsButton);
            Controls.Add(resetFiltersButton);
            Controls.Add(label3);
            Controls.Add(filterValueCB);
            Controls.Add(label2);
            Controls.Add(filterTypeCB);
            Controls.Add(loadButton);
            Controls.Add(EditTracksButton);
            Controls.Add(label1);
            Controls.Add(sortCBox);
            Controls.Add(desRButton);
            Controls.Add(ascRButton);
            Controls.Add(sortButton);
            Controls.Add(tracksGrid);
            Name = "MainForm";
            Text = "Audio Library";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)tracksGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView tracksGrid;
        private Button sortButton;
        private RadioButton ascRButton;
        private RadioButton desRButton;
        private ComboBox sortCBox;
        private Label label1;
        private Button EditTracksButton;
        private Button loadButton;
        private BindingSource bindingSource1;
        private Button resetFiltersButton;
        private Label label3;
        private ComboBox filterValueCB;
        private Label label2;
        private ComboBox filterTypeCB;
        private Button editAuthorsButton;
        private Button editAlbumsButton;
        private Button editGenresButton;
        private Button linksButton;
    }
}