namespace P02_VillainNames
{
    using System;

    using Microsoft.Data.SqlClient;

    public class StartUp
    {
        private static string connectionString = "Server=DESKTOP-GPNJISJ\\SQLEXPRESS;Database=MinionsDB;Integrated Security=true;";

        public static void Main()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            using (connection)
            {
                string sqlQueryText = @"SELECT * 
                                        FROM (
                                   	            SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                                   	                FROM Villains AS v 
                                   	                JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                                   	            GROUP BY v.Id, v.Name
                                             ) AS [GroupingQuery]
                                        WHERE MinionsCount > 3
                                        ORDER BY MinionsCount";

                SqlCommand command = new SqlCommand(sqlQueryText, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string villainName = (string)reader["Name"];
                        int minionsCount = (int)reader["MinionsCount"];

                        Console.WriteLine($"{villainName} - {minionsCount}");
                    }
                }
            }
        }
    }
}
