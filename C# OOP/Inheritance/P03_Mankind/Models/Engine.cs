namespace P03_Mankind.Models
{
    using System;

    public class Engine
    {
        public void Run()
        {
            try
            {
                string[] studentArguments = Console.ReadLine().Split();

                string studentFirstName = studentArguments[0];
                string studentLastName = studentArguments[1];
                string facultyNumber = studentArguments[2];

                Student student = new Student(studentFirstName, studentLastName, facultyNumber);

                string[] workerArguments = Console.ReadLine().Split();

                string workerFirstName = workerArguments[0];
                string workerLastName = workerArguments[1];
                double weekSalary = double.Parse(workerArguments[2]);
                double workingHoursPerDay = double.Parse(workerArguments[3]);

                Worker worker = new Worker(workerFirstName, workerLastName, weekSalary, workingHoursPerDay);

                ConsoleWriter.Write(student);
                ConsoleWriter.Write(worker);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
