using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Author
    {
        public string value { get; set; } = "Unknown";

        public Author(string author)
        {
            value = author;
        }
        public static List<Author> synchronizeWithDB()
        {

            var list = new List<Author>();
            using (SqlConnection connection = new SqlConnection(db.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = "Select AuthorName from Authors";
                command.Connection = connection;
                var result = command.ExecuteReader();

                while (result.Read())
                {
                    list.Add(new Author(result.GetString(0)));
                }
            }

            return list;
        }
    }
}
