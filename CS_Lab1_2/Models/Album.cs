using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Album
    {
        public string value { get; set; } = "Unknown";
        public Album(string album)
        {
            value = album;
        }
        public static List<Album> synchronizeWithDB()
        {

            var list = new List<Album>();
            using (SqlConnection connection = new SqlConnection(db.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = "Select AlbumName from Albums";
                command.Connection = connection;
                var result = command.ExecuteReader();

                while (result.Read())
                {
                    list.Add(new Album(result.GetString(0)));
                }
            }

            return list;
        }
    }
}
