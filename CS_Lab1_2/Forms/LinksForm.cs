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
    public partial class LinksForm : Form
    {
        BindingSource source = new BindingSource();
        List<Genre> genres = new List<Genre>();
        List<Album> albums = new List<Album>();
        List<Track> tracks = new List<Track>();
        public LinksForm()
        {
            InitializeComponent();
        }
        public LinksForm(ref List<Album> albums)
        {
            this.albums = albums;
            InitializeComponent();
        }

        private void linksCB_SelectedIndexChanged(object sender, EventArgs e)
        {

            valueCB.Items.Clear();

            switch (linksCB.SelectedIndex)
            {
                case 0:
                    valueCB.Items.AddRange((from item in Author.synchronizeWithDB() select item.value).ToArray());
                    break;
                case 1:
                    valueCB.Items.AddRange((from item in Author.synchronizeWithDB() select item.value).ToArray());
                    break;
                case 2:
                    valueCB.Items.AddRange((from item in Genre.synchronizeWithDB() select item.value).ToArray());
                    break;


            }

        }

        private void valueCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (linksCB.SelectedIndex)
            {
                case 0:
                    using (SqlConnection connection = new SqlConnection(db.connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand();
                        command.CommandText = $"DECLARE @AuthorName VARCHAR(50) = '{valueCB.SelectedItem.ToString()}'" +
                            $"\r\nDECLARE @AuthorId INT" +
                            $"\r\nSELECT @AuthorId = AuthorId FROM Authors WHERE AuthorName = @AuthorName" +
                            $"\r\n" +
                            $"\r\nSELECT Genres.GenreName" +
                            $"\r\nFROM Genres" +
                            $"\r\nJOIN AuthorGenres ON Genres.GenreId = AuthorGenres.GenreId" +
                            $"\r\nWHERE AuthorGenres.AuthorId = @AuthorId";
                        command.Connection = connection;
                        var result = command.ExecuteReader();
                        genres.Clear();
                        while (result.Read())
                        {
                            genres.Add(new Genre(result.GetString(0)));
                        }
                        source.DataSource = null;
                        source.DataSource = genres;
                        valuesGrid.DataSource = null;
                        valuesGrid.DataSource = source;
                    }
                    break;
                case 1:
                    using (SqlConnection connection = new SqlConnection(db.connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand();
                        command.CommandText = $"DECLARE @AuthorName VARCHAR(50) = '{valueCB.SelectedItem.ToString()}'" +
                            $"\r\nDECLARE @AuthorId INT" +
                            $"\r\nSELECT @AuthorId = AuthorId FROM Authors WHERE AuthorName = @AuthorName" +
                            $"\r\n" +
                            $"SELECT Tracks.TrackName, Genres.GenreName, Authors.AuthorName, Albums.AlbumName, Tracks.Time" +
                            $"\r\nFROM Tracks" +
                            $"\r\nJOIN Genres ON Tracks.GenreId = Genres.GenreId" +
                            $"\r\nJOIN Authors ON Tracks.AuthorId = Authors.AuthorId" +
                            $"\r\nJOIN Albums ON Tracks.AlbumId = Albums.AlbumId" +
                            $"\r\nJOIN AuthorTracks ON Tracks.AuthorId = AuthorTracks.AuthorId" +
                            $"\r\nWHERE AuthorTracks.AuthorId = @AuthorId";
                        command.Connection = connection;
                        var result = command.ExecuteReader();
                        tracks.Clear();
                        while (result.Read())
                        {
                            tracks.Add(new Track(result.GetString(4), result.GetString(2), result.GetString(0), result.GetString(3), result.GetString(1)));
                        }
                        source.DataSource = null;
                        source.DataSource = tracks;
                        valuesGrid.DataSource = null;
                        valuesGrid.DataSource = source;
                    }
                    break;
                case 2:
                    using (SqlConnection connection = new SqlConnection(db.connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand();
                        command.CommandText = $"SELECT Tracks.TrackName, Genres.GenreName, Authors.AuthorName, Albums.AlbumName, Tracks.Time" +
                            $"\r\nFROM Tracks" +
                            $"\r\nJOIN Authors ON Tracks.AuthorId = Authors.AuthorId" +
                            $"\r\nJOIN Albums ON Tracks.AlbumId = Albums.AlbumId" +
                            $"\r\nINNER JOIN GenreTracks ON Tracks.TrackId = GenreTracks.TrackId" +
                            $"\r\nINNER JOIN Genres ON GenreTracks.GenreId = Genres.GenreId" +
                            $"\r\nWHERE Genres.GenreName = '{valueCB.SelectedItem.ToString()}'";
                        command.Connection = connection;
                        var result = command.ExecuteReader();
                        tracks.Clear();
                        while (result.Read())
                        {
                            tracks.Add(new Track(result.GetString(4), result.GetString(2), result.GetString(0), result.GetString(3), result.GetString(1)));
                        }
                        source.DataSource = null;
                        source.DataSource = tracks;
                        valuesGrid.DataSource = null;
                        valuesGrid.DataSource = source;
                        break;
                    }
            }
        }

        private void LinksForm_Load(object sender, EventArgs e)
        {

        }
    }
}
