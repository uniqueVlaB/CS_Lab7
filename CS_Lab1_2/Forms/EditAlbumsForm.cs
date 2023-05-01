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
    public partial class EditAlbumsForm : Form
    {
        List<Models.Album> albums = new List<Models.Album>();
        List<Models.Author> authors = new List<Models.Author>();
        BindingSource source = new BindingSource();
        string selectedAlbum = string.Empty;

        public EditAlbumsForm()
        {
            InitializeComponent();
        }
        public EditAlbumsForm(ref List<Models.Album> albums, ref List<Models.Author> authors)
        {
            this.albums = albums;
            this.authors = authors;
            InitializeComponent();
        }

        private void authorCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            albums.Clear();
            using (SqlConnection connection = new SqlConnection(db.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                string author = authorCB.Text;
                command.CommandText = $"SELECT Albums.AlbumName" +
                    $"\r\nFROM Albums" +
                    $"\r\nJOIN Authors ON Authors.AuthorId = Albums.AuthorId" +
                    $"\r\nWHERE Authors.AuthorName = '{author}'";
                command.Connection = connection;
                var result = command.ExecuteReader();

                while (result.Read())
                {
                    albums.Add(new Models.Album(result.GetValue(0).ToString()));
                }
            }
            source.DataSource = albums;
            albumsGrid.DataSource = null;
            albumsGrid.DataSource = source;
            albumsGrid.AutoResizeColumns();
            albumsGrid.AutoResizeRows();
        }

        private void EditAlbumsForm_Load(object sender, EventArgs e)
        {
            authorCB.Items.AddRange((from author in authors select author.value).ToArray());
            source.DataSource = albums;
            albumsGrid.DataSource = source;
            albumsGrid.AutoResizeColumns();
            albumsGrid.AutoResizeRows();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(db.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                string author = authorCB.Text;
                command.CommandText = $"DECLARE @AlbumName VARCHAR(50) = '{albumNameTB.Text}'" +
                    $"\r\nDECLARE @AuthorName VARCHAR(50) = '{authorCB.Text}'" +
                    $"\r\n" +
                    $"\r\nDECLARE @AuthorId INT" +
                    $"\r\nSELECT @AuthorId = AuthorId FROM Authors WHERE AuthorName = @AuthorName" +
                    $"\r\n" +
                    $"\r\nINSERT INTO Albums (AlbumName, AuthorId)" +
                    $"\r\nVALUES (@AlbumName, @AuthorId)" +
                    $"\r\n" +
                    $"\r\nDECLARE @AlbumId INT" +
                    $"\r\nSELECT @AlbumId = AlbumId FROM Albums WHERE AlbumName = @AlbumName" +
                    $"\r\n" +
                    $"\r\nINSERT INTO AuthorAlbums (AlbumId, AuthorId)" +
                    $"\r\nVALUES (@AlbumId, @AuthorId)";
                command.Connection = connection;
                var result = command.ExecuteReader();
            }
            albums.Add(new Models.Album(albumNameTB.Text));
            albumsGrid.DataSource = null;
            albumsGrid.DataSource = source;
            albumsGrid.AutoResizeColumns();
            albumsGrid.AutoResizeRows();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            albums.Clear();
            albumNameTB.Clear();
            authorCB.Text = "";
            using (SqlConnection connection = new SqlConnection(db.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                string author = authorCB.Text;
                command.CommandText = $"SELECT AlbumName FROM Albums";
                command.Connection = connection;
                var result = command.ExecuteReader();

                while (result.Read())
                {
                    albums.Add(new Models.Album(result.GetValue(0).ToString()));
                }
            }
            albumsGrid.DataSource = null;
            albumsGrid.DataSource = source;
            albumsGrid.AutoResizeColumns();
            albumsGrid.AutoResizeRows();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            var selectedCells = albumsGrid.SelectedCells;
            foreach (DataGridViewCell cell in selectedCells)
            {

                using (SqlConnection connection = new SqlConnection(db.connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    string author = authorCB.Text;
                    command.CommandText = $"DECLARE @AlbumName VARCHAR(50) = '{cell.Value.ToString()}' -- название альбома" +
                        $"\r\n" +
                        $"\r\n-- выбираем id альбома по его названию" +
                        $"\r\nDECLARE @AlbumId INT" +
                        $"\r\nSELECT @AlbumId = AlbumId FROM Albums WHERE AlbumName = @AlbumName" +
                        $"\r\n" +
                        $"\r\n-- удаляем все треки из альбома" +
                        $"\r\nDELETE FROM Tracks WHERE AlbumId = @AlbumId" +
                        $"\r\n" +
                        $"\r\n-- удаляем сам альбом" +
                        $"\r\nDELETE FROM Albums WHERE AlbumId = @AlbumId";
                    command.Connection = connection;
                    var result = command.ExecuteReader();
                }
                albums.RemoveAt(cell.RowIndex);
            }
            albumsGrid.DataSource = null;
            albumsGrid.DataSource = source;
            albumsGrid.AutoResizeColumns();
            albumsGrid.AutoResizeRows();
        }

        private void albumsGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(db.connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandText = $"DECLARE @AlbumName VARCHAR(50) = '{selectedAlbum}' -- название альбома" +
                        $"\r\nDECLARE @NewAlbumName VARCHAR(50) = '{albums[e.RowIndex].value}' -- новое название альбома" +
                        $"\r\n" +
                        $"\r\nUPDATE Albums SET AlbumName = @NewAlbumName WHERE AlbumName = @AlbumName";
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
                albums[e.RowIndex].value = albumsGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                MessageBox.Show($"Changed succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void albumsGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            selectedAlbum = albumsGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
        }
    }
}
