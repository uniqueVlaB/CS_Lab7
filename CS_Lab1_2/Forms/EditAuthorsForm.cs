using Microsoft.Data.SqlClient;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_Lab1_2
{
    public partial class EditAuthorsForm : Form
    {
        List<Models.Author> authors = new List<Models.Author>();
        BindingSource source = new BindingSource();
        string selectedAuthor = string.Empty;
        public EditAuthorsForm()
        {
            InitializeComponent();
        }

        public EditAuthorsForm(ref List<Models.Author> authors)
        {
            this.authors = authors;
            InitializeComponent();
        }

        private void EditAuthorsForm_Load(object sender, EventArgs e)
        {
            source.DataSource = authors;
            authorsGrid.DataSource = source;
            authorsGrid.AutoResizeColumns();
            authorsGrid.AutoResizeRows();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(db.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = $"DECLARE @AuthorName VARCHAR(50) = '{authorNameTB.Text}'" +
                    $"\r\nINSERT INTO Authors (AuthorName)" +
                    $"\r\nVALUES (@AuthorName)";
                command.Connection = connection;
                var result = command.ExecuteReader();
            }
            authors.Add(new Models.Author(authorNameTB.Text));
            authorsGrid.DataSource = null;
            authorsGrid.DataSource = source;
            authorsGrid.AutoResizeColumns();
            authorsGrid.AutoResizeRows();
        }

        private void authorsGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            selectedAuthor = authorsGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
        }

        private void authorsGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(db.connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandText = $"DECLARE @AuthorName VARCHAR(50) = '{selectedAuthor}'" +
                        $"\r\nDECLARE @NewAuthorName VARCHAR(50) = '{authors[e.RowIndex].value}'" +
                        $"\r\n" +
                        $"\r\nUPDATE Authors SET AuthorName = @NewAuthorName WHERE AuthorName = @AuthorName";
                    command.Connection = connection;
                    var result = command.ExecuteReader();

                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                authors[e.RowIndex].value = authorsGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                MessageBox.Show($"Changed succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            var selectedCells = authorsGrid.SelectedCells;
            foreach (DataGridViewCell cell in selectedCells)
            {

                using (SqlConnection connection = new SqlConnection(db.connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandText = $"DECLARE @AuthorName VARCHAR(50) = '{cell.Value.ToString()}'" +
                        $"\r\nDECLARE @AuthorId INT" +
                        $"\r\nSELECT @AuthorId = AuthorId FROM Authors WHERE AuthorName = @AuthorName" +
                        $"\r\n-- удаляем все треки, принадлежащие альбомам удаляемого автора" +
                        $"\r\nDELETE FROM Tracks\r\nWHERE AlbumId IN (" +
                        $"\r\n    SELECT AlbumId FROM Albums WHERE AuthorId = @AuthorId" +
                        $"\r\n)" +
                        $"\r\n" +
                        $"\r\n-- удаляем все альбомы, принадлежащие удаляемому автору" +
                        $"\r\nDELETE FROM Albums WHERE AuthorId = @AuthorId" +
                        $"\r\n" +
                        $"\r\n-- удаляем самого автора" +
                        $"\r\nDELETE FROM Authors WHERE AuthorId = @AuthorId";
                    command.Connection = connection;
                    var result = command.ExecuteReader();
                }
                authors.RemoveAt(cell.RowIndex);
            }
            authorsGrid.DataSource = null;
            authorsGrid.DataSource = source;
            authorsGrid.AutoResizeColumns();
            authorsGrid.AutoResizeRows();
        }
    }
}
