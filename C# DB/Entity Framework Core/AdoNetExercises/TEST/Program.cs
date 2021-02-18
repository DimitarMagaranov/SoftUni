using Microsoft.Data.SqlClient;
using System;

namespace AdoNetExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=DESKTOP-GPNJISJ\\SQLEXPRESS;Database=SoftUni;Integrated Security=true;";

            using (SqlConnection sqlConnection = new SqlConnection(
                "Server=DESKTOP-GPNJISJ\\SQLEXPRESS;Database=SoftUni;Integrated Security=true;"))
            {
                sqlConnection.Open();

                //извличане на един единствен резултат
                SqlCommand sqlScalarCommand = new SqlCommand("SELECT COUNT(*) FROM [Employees]", sqlConnection);

                object result = sqlScalarCommand.ExecuteScalar();

                Console.WriteLine(result);


                //извличане на таблица
                SqlCommand sqlTableCommand = new SqlCommand("SELECT * FROM [Employees]", sqlConnection);

                using (SqlDataReader reader = sqlTableCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string firstName = (string)reader["FirstName"];
                        string lastName = (string)reader["LastName"];
                        decimal salary = (decimal)reader["Salary"];

                        Console.WriteLine(firstName + " " + lastName + " -> " + salary);
                    }
                }
                    

                //заявка за update, delete, insert и други команди които не показват резултат
                SqlCommand updateSalaryCommand = new SqlCommand("UPDATE Employees SET Salary += Salary * 0.1", sqlConnection);

                int updatedRows = updateSalaryCommand.ExecuteNonQuery();

                Console.WriteLine($"Salary updated for {updatedRows} employees!");
            }
        }
    }
}
