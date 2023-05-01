using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;

namespace CS_Lab1_2
{
    public partial class ListsEditForm : Form
    {
        List<Models.Author> authorList = new List<Models.Author>();
        List<Models.Genre> genreList = new List<Models.Genre>();
        List<Models.Album> albumList = new List<Models.Album>();
        BindingSource bindingSource = new BindingSource();
        public ListsEditForm(ref List<Models.Author> authorList, ref List<Models.Genre> genreList, ref List<Models.Album> albumList)
        {
            this.authorList = authorList;
            this.genreList = genreList;
            this.albumList = albumList;
            InitializeComponent();
        }
        public ListsEditForm()
        {

            InitializeComponent();
        }

        private void ListsEditForm_Load(object sender, EventArgs e)
        {

            bindingSource.DataSource = authorList;

            dataGridView1.DataSource = bindingSource;
            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoResizeRows();
        }

        private void genreRButton_CheckedChanged(object sender, EventArgs e)
        {
            bindingSource.DataSource = genreList;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bindingSource;
            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoResizeRows();
        }

        private void authorRButton_CheckedChanged(object sender, EventArgs e)
        {
            bindingSource.DataSource = authorList;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bindingSource;
            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoResizeRows();
        }

        private void addItemButton_Click(object sender, EventArgs e)
        {
            if (addItemText.Text != "")
            {
                if (authorRButton.Checked)
                {
                    authorList.Add(new Author(addItemText.Text));
                }
                else
                {
                    genreList.Add(new Genre(addItemText.Text));
                }
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = bindingSource;
                dataGridView1.AutoResizeColumns();
                dataGridView1.AutoResizeRows();
            }
        }

        private void DeteleItemButton_Click(object sender, EventArgs e)
        {
            var selectedCells = dataGridView1.SelectedCells;
            foreach (DataGridViewCell cell in selectedCells)
            {
                if (authorRButton.Checked)
                {
                    authorList.RemoveAt(cell.RowIndex);
                }
                else
                {
                    genreList.RemoveAt(cell.RowIndex);
                }

            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bindingSource;
            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoResizeRows();
        }

        private void albumRButton_CheckedChanged(object sender, EventArgs e)
        {
            bindingSource.DataSource = albumList;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bindingSource;
            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoResizeRows();
        }
    }
}
