using System.Data.SqlClient;

namespace SQLInjection;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Server=localhost;Database=test;User Id=user;Password=password;";
        string userInput = Console.ReadLine();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM users WHERE username='" + userInput + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader["username"] + " - " + reader["email"]);
            }

            connection.Close();
        }
    }
}