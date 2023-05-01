using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Genre
    {
        public string value { get; set; } = "Unknown";

        public Genre(string genre)
        {
            value = genre;
        }

        public static List<Genre> synchronizeWithDB()
        {

            var list = new List<Genre>();
            using (SqlConnection connection = new SqlConnection(db.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = "Select GenreName from Genres";
                command.Connection = connection;
                var result = command.ExecuteReader();

                while (result.Read())
                {
                    list.Add(new Genre(result.GetString(0)));
                }
            }

            return list;
        }

    }
}
