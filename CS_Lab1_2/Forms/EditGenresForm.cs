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
    public partial class EditGenresForm : Form
    {
        
        List<Models.Genre> genres = new List<Models.Genre>();
        BindingSource source = new BindingSource();
        string selectedGenre = string.Empty;

        public EditGenresForm()
        {
            InitializeComponent();
        }

        public EditGenresForm(ref List<Models.Genre> genres)
        {
            this.genres = genres;
            InitializeComponent();
        }

        private void EditGenresForm_Load(object sender, EventArgs e)
        {
            source.DataSource = genres;
            genresGrid.DataSource = source;
            genresGrid.AutoResizeColumns();
            genresGrid.AutoResizeRows();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(db.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = $"DECLARE @GenreName VARCHAR(50) = '{genreNameTB.Text}'" +
                    $"\r\nINSERT INTO Genres (GenreName)" +
                    $"\r\nVALUES (@GenreName)";
                command.Connection = connection;
                var result = command.ExecuteReader();
            }
            genres.Add(new Models.Genre(genreNameTB.Text));
            genresGrid.DataSource = null;
            genresGrid.DataSource = source;
            genresGrid.AutoResizeColumns();
            genresGrid.AutoResizeRows();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            var selectedCells = genresGrid.SelectedCells;
            foreach (DataGridViewCell cell in selectedCells)
            {

                using (SqlConnection connection = new SqlConnection(db.connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandText = $"DECLARE @GenreName VARCHAR(50) = '{cell.Value.ToString()}' -- название жанра" +
                        $"\r\n" +
                        $"\r\n-- выбираем id жанра по его названию" +
                        $"\r\nDECLARE @GenreId INT" +
                        $"\r\nSELECT @GenreId = GenreId FROM Genres WHERE GenreName = @GenreName" +
                        $"\r\n" +
                        $"\r\n-- удаляем все треки из жанра" +
                        $"\r\nDELETE FROM Tracks WHERE GenreId = @GenreId" +
                        $"\r\n" +
                        $"\r\n-- удаляем сам жанр" +
                        $"\r\nDELETE FROM Genres WHERE GenreId = @GenreId";
                    command.Connection = connection;
                    var result = command.ExecuteReader();
                }
                genres.RemoveAt(cell.RowIndex);
            }
            genresGrid.DataSource = null;
            genresGrid.DataSource = source;
            genresGrid.AutoResizeColumns();
            genresGrid.AutoResizeRows();
        }

        private void genresGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            selectedGenre = genresGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
        }

        private void genresGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(db.connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandText = $"DECLARE @GenreName VARCHAR(50) = '{selectedGenre}'" +
                        $"\r\nDECLARE @NewGenreName VARCHAR(50) = '{genres[e.RowIndex].value}'" +
                        $"\r\n" +
                        $"\r\nUPDATE Genres SET GenreName = @NewGenreName WHERE GenreName = @GenreName";
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
                genres[e.RowIndex].value= genresGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                MessageBox.Show($"Changed succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}
