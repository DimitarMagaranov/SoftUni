using System;
using System.Linq;
using System.Reflection;
using test.People;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            var personType = typeof(Program)
                .Assembly
                .GetTypes()
                .FirstOrDefault(x => x.Name == "Person");

            var firstInstance = Activator.CreateInstance(personType, BindingFlags.Instance
                | BindingFlags.NonPublic, null, new object[] { "Gosho", 15 }, null);

            var constructor = personType
                .GetConstructor(new Type[] { typeof(string) });

            var secondInstance = (Person)constructor.Invoke(new object[] { "Gosho" });
            

            Console.WriteLine();
        }
    }
}
