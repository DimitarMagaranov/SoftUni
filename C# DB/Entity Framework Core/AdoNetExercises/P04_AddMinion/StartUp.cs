namespace P04_AddMinion
{
    using Microsoft.Data.SqlClient;
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        private const string connectionString = "Server=DESKTOP-GPNJISJ\\SQLEXPRESS;Database=MinionsDB;Integrated Security=true;";

        public static void Main()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            sqlConnection.Open();

            string[] minionsInput = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            string[] minionsInfo = minionsInput[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            string[] villainInfo = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            string result = AddMinionToDatabase(sqlConnection, minionsInfo, villainInfo);

            Console.WriteLine(result);
        }

        private static string AddMinionToDatabase(SqlConnection sqlConnection, string[] minionsInfo, string[] villainInfo)
        {
            StringBuilder output = new StringBuilder();

            string minionName = minionsInfo[0];
            string minionAge = minionsInfo[1];
            string minionTownName = minionsInfo[2];

            string villainName = villainInfo[1];

            string townId = EnsureTownExists(sqlConnection, minionTownName, output);

            string villainId = EnsureVillainExists(sqlConnection, villainName, output);

            string insertMinionQueryText = @"INSERT INTO Minions([Name], Age, TownId)
                                             VALUES(@minionName, @minionAge, @townId)";

            SqlCommand insertMinionCommand = new SqlCommand(insertMinionQueryText, sqlConnection);

            insertMinionCommand.Parameters.AddWithValue("@minionName", minionName);
            insertMinionCommand.Parameters.AddWithValue("@minionAge", minionAge);
            insertMinionCommand.Parameters.AddWithValue("@townId", townId);

            insertMinionCommand.ExecuteNonQuery();

            string getMinionIdQueryText = @"SELECT Id FROM Minions
                                            WHERE [Name] = @minionName";

            SqlCommand getMinionIdCommand = new SqlCommand(getMinionIdQueryText, sqlConnection);

            getMinionIdCommand.Parameters.AddWithValue("@minionName", minionName);

            string minionId = getMinionIdCommand.ExecuteScalar().ToString();

            string insertIntoMappingQueryText = @"INSERT INTO MinionsVillains(MinionId, VillainId)
                                                  VALUES (@minionId, @villainId)";

            SqlCommand insertIntoMappingCommand = new SqlCommand(insertIntoMappingQueryText, sqlConnection);

            insertIntoMappingCommand.Parameters.AddWithValue("@minionId", minionId);
            insertIntoMappingCommand.Parameters.AddWithValue("@villainId", villainId);

            insertIntoMappingCommand.ExecuteNonQuery();

            output.AppendLine($"Successfully added {minionName} to be minion of {villainName}.");

            return output.ToString().TrimEnd();
        }

        private static string EnsureVillainExists(SqlConnection sqlConnection, string villainName, StringBuilder output)
        {
            string getVillainIdQueryText = @"SELECT Id FROM Villains
                                             WHERE [Name] = @villainName";

            SqlCommand getVillainIdCommand = new SqlCommand(getVillainIdQueryText, sqlConnection);

            getVillainIdCommand.Parameters.AddWithValue("@villainName", villainName);

            string villainId = getVillainIdCommand.ExecuteScalar()?.ToString();

            if (villainId == null)
            {
                string getDefaultEvilnessFactorIdQueryText = @"SELECT Id FROM EvilnessFactors
                                                               WHERE [Name] = 'Evil'";

                SqlCommand getFactorIdCommand = new SqlCommand(getDefaultEvilnessFactorIdQueryText, sqlConnection);

                string factorId = getFactorIdCommand.ExecuteScalar()?.ToString();

                string insertVillaindQueryText = @"INSERT INTO Villains ([Name], EvilnessFactorId)
                                                   VALUES (@villainName, @factorId)";

                SqlCommand insertVIllainCommand = new SqlCommand(insertVillaindQueryText, sqlConnection);

                insertVIllainCommand.Parameters.AddWithValue("@villainName", villainName);
                insertVIllainCommand.Parameters.AddWithValue("@factorId", factorId);

                insertVIllainCommand.ExecuteNonQuery();

                villainId = getVillainIdCommand.ExecuteScalar().ToString();

                output.AppendLine($"Villain {villainName} was added to the database.");
            }

            return villainId;
        }

        private static string EnsureTownExists(SqlConnection sqlConnection, string minionTownName, StringBuilder output)
        {
            string getTownIdQueryText = @"SELECT Id FROM Towns
                                          WHERE [Name] = @townName";

            SqlCommand getTownIdCommand = new SqlCommand(getTownIdQueryText, sqlConnection);

            getTownIdCommand.Parameters.AddWithValue("@townName", minionTownName);

            string townId = getTownIdCommand.ExecuteScalar()?.ToString();

            if (townId == null)
            {
                string insertTownQueryText = @"INSERT INTO Towns ([Name], CountryCode)
                                               VALUES (@townName, 1)";

                SqlCommand insertTownCommand = new SqlCommand(insertTownQueryText, sqlConnection);

                insertTownCommand.Parameters.AddWithValue("@townName", minionTownName);

                insertTownCommand.ExecuteNonQuery();

                townId = getTownIdCommand.ExecuteScalar().ToString();

                output.AppendLine($"Town {minionTownName} was added to the database.");
            }

            return townId;
        }
    }
}
