using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Xml.Linq;
using Microsoft.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Models;

namespace CS_Lab1_2
{
    public partial class AddTrackForm : Form
    {

        List<Author> authorList = new List<Author>();
        List<Genre> genreList = new List<Genre>();
        List<Track> tracks = new List<Track>();
        List<Album> albumList = new List<Album>();

        public AddTrackForm()
        {
            InitializeComponent();
        }

        public AddTrackForm(ref List<Track> tracks, ref List<Author> authorList, ref List<Genre> genreList, ref List<Album> albumList)
        {
            this.tracks = tracks;
            this.authorList = authorList;
            this.genreList = genreList;
            this.albumList = albumList;
            InitializeComponent();
        }

        private void AddTrackForm_Load_1(object sender, EventArgs e)
        {
            foreach (Models.Author item in authorList)
            {
                authorCB.Items.Add(item.value);
            }
            genreCB.Items.AddRange((from Genre in genreList select Genre.value).ToArray());
        }

        private void addButton_Click(object sender, EventArgs e)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(db.connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                   
                    command.CommandText = $"DECLARE @TrackName VARCHAR(50) = '{nameTextBox.Text}'" +
                    $"\r\nDECLARE @GenreName VARCHAR(50) = '{genreCB.Text}'" +
                    $"\r\nDECLARE @AuthorName VARCHAR(50) = '{authorCB.Text}'" +
                    $"\r\nDECLARE @AlbumName VARCHAR(50) = '{albumCB.Text}'" +
                    $"\r\n" +
                    $"\r\nDECLARE @GenreId INT, @AuthorId INT, @AlbumId INT" +
                    $"\r\nSELECT @GenreId = GenreId FROM Genres WHERE GenreName = @GenreName" +
                    $"\r\nSELECT @AuthorId = AuthorId FROM Authors WHERE AuthorName = @AuthorName" +
                    $"\r\nSELECT @AlbumId = AlbumId FROM Albums WHERE AlbumName = @AlbumName" +
                    $"\r\n" +
                    $"\r\nINSERT INTO Tracks (TrackName, GenreId, AuthorId, AlbumId, Time)" +
                    $"\r\nVALUES (@TrackName, @GenreId, @AuthorId, @AlbumId, '{timeTextBox.Text}')" +
                    $"\r\n" +
                    $"\r\nDECLARE @TrackId INT" +
                    $"\r\nSELECT @TrackId = TrackId FROM Tracks WHERE TrackName = @TrackName" +
                    $"\r\n" +
                    $"\r\nINSERT INTO AuthorGenres (GenreId, AuthorId)" +
                    $"\r\nVALUES (@GenreId, @AuthorId)" +
                    $"\r\n" +
                    $"\r\nINSERT INTO AuthorTracks (TrackId, AuthorId)" +
                    $"\r\nVALUES (@TrackId, @AuthorId)" +
                    $"\r\n" +
                    $"\r\nINSERT INTO AlbumTracks (TrackId, AlbumId)" +
                    $"\r\nVALUES (@TrackId, @AlbumId)" +
                    $"\r\n" +
                    $"\r\nINSERT INTO GenreTracks (TrackId, GenreId)" +
                    $"\r\nVALUES (@TrackId, @GenreId)";
                    command.Connection = connection;
                    var result = command.ExecuteNonQuery();
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
                tracks.Add(new Track(timeTextBox.Text, authorCB.Text, nameTextBox.Text, albumCB.Text, genreCB.Text));
                MessageBox.Show($"Added succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void authorCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            albumCB.Items.Clear();
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
                    albumCB.Items.Add(result.GetValue(0));
                }
            }
        }
    }
}
