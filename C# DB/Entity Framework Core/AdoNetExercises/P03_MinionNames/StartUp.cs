namespace P03_MinionNames
{
    using System;

    using Microsoft.Data.SqlClient;

    public class StartUp
    {
        private const string connectionString = "Server=DESKTOP-GPNJISJ\\SQLEXPRESS;Database=MinionsDB;Integrated Security=true;";

        public static void Main()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            Console.WriteLine("Villain ID:");

            int id = int.Parse(Console.ReadLine());

            using (connection)
            {
                string queryText = "SELECT Name FROM Villains WHERE Id = @villainId";

                SqlCommand command = new SqlCommand(queryText, connection);

                command.Parameters.AddWithValue("@villainId", id);

                string name = command.ExecuteScalar()?.ToString();

                if (name == null)
                {
                    Console.WriteLine($"No villain with ID {id} exists in the database.");
                    return;
                }
                else
                {
                    Console.WriteLine($"Villain: {name}");
                }


                string queryText2 = @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                                                                                m.Name, 
                                                                                m.Age
                                     FROM MinionsVillains AS mv
                                     JOIN Minions As m ON mv.MinionId = m.Id
                                     WHERE mv.VillainId = @villainId
                                     ORDER BY m.Name";


                SqlCommand command2 = new SqlCommand(queryText2, connection);

                command2.Parameters.AddWithValue("@villainId", id);

                SqlDataReader reader = command2.ExecuteReader();

                using (reader)
                {
                    if (reader.HasRows)
                    {
                        int rowNumber = 1;

                        while (reader.Read())
                        {
                            string minionName = reader["Name"]?.ToString();
                            string age = reader["Age"]?.ToString();

                            Console.WriteLine($"{rowNumber}. {minionName} {age}");

                            rowNumber++;
                        }
                    }
                    else
                    {
                        Console.WriteLine("(no minions)");
                    }
                }
            }
        }
    }
}
