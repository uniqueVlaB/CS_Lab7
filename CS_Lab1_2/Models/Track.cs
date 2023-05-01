using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Track
    {
        public string time { get; set; } = "Unknown";
        public string author { get; set; } = "Unknown";
        public string name { get; set; } = "Unknown";
        public string album { get; set; } = "Unknown";
        public string genre { get; set; } = "Unknown";

        public Track(string time, string author, string name, string album, string genre)
        {
            this.time = time;
            this.author = author;
            this.name = name;
            this.album = album;
            this.genre = genre;
        }

        public static List<Track> getFromDB()
        {
            List<Track> list = new List<Track>();
            using (SqlConnection connection = new SqlConnection(db.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = "SELECT Tracks.TrackName, Genres.GenreName, Authors.AuthorName, Albums.AlbumName, Tracks.Time" +
                    "\r\nFROM Tracks" +
                    "\r\nJOIN Genres ON Tracks.GenreId = Genres.GenreId" +
                    "\r\nJOIN Authors ON Tracks.AuthorId = Authors.AuthorId" +
                    "\r\nJOIN Albums ON Tracks.AlbumId = Albums.AlbumId;";
                command.Connection = connection;
                var result = command.ExecuteReader();

                while (result.Read())
                {
                    list.Add(new Track(result.GetString(4), result.GetString(2), result.GetString(0), result.GetString(3), result.GetString(1)));
                }
            }
            return list;
        }

        public static List<Track> getFromDB(Author item)
        {
            List<Track> list = new List<Track>();
            using (SqlConnection connection = new SqlConnection(db.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = $"SELECT Tracks.TrackName, Genres.GenreName, Authors.AuthorName, Albums.AlbumName, Tracks.Time\r\nFROM Tracks\r\nJOIN Genres ON Tracks.GenreId = Genres.GenreId\r\nJOIN Authors ON Tracks.AuthorId = Authors.AuthorId\r\nJOIN Albums ON Tracks.AlbumId = Albums.AlbumId WHERE AuthorName = '{item.value}';";
                command.Connection = connection;
                var result = command.ExecuteReader();

                while (result.Read())
                {
                    list.Add(new Track(result.GetString(4), result.GetString(2), result.GetString(0), result.GetString(3), result.GetString(1)));
                }
            }
            return list;
        }
        public static List<Track> getFromDB(Genre item)
        {
            List<Track> list = new List<Track>();
            using (SqlConnection connection = new SqlConnection(db.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = $"SELECT Tracks.TrackName, Genres.GenreName, Authors.AuthorName, Albums.AlbumName, Tracks.Time\r\nFROM Tracks\r\nJOIN Genres ON Tracks.GenreId = Genres.GenreId\r\nJOIN Authors ON Tracks.AuthorId = Authors.AuthorId\r\nJOIN Albums ON Tracks.AlbumId = Albums.AlbumId WHERE GenreName = '{item.value}';";
                command.Connection = connection;
                var result = command.ExecuteReader();

                while (result.Read())
                {
                    list.Add(new Track(result.GetString(4), result.GetString(2), result.GetString(0), result.GetString(3), result.GetString(1)));
                }
            }
            return list;
        }
        public static List<Track> getFromDB(Album item)
        {
            List<Track> list = new List<Track>();
            using (SqlConnection connection = new SqlConnection(db.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = $"SELECT Tracks.TrackName, Genres.GenreName, Authors.AuthorName, Albums.AlbumName, Tracks.Time\r\nFROM Tracks\r\nJOIN Genres ON Tracks.GenreId = Genres.GenreId\r\nJOIN Authors ON Tracks.AuthorId = Authors.AuthorId\r\nJOIN Albums ON Tracks.AlbumId = Albums.AlbumId WHERE AlbumName = '{item.value}';";
                command.Connection = connection;
                var result = command.ExecuteReader();

                while (result.Read())
                {
                    list.Add(new Track(result.GetString(4), result.GetString(2), result.GetString(0), result.GetString(3), result.GetString(1)));
                }
            }
            return list;
        }
    }

}
