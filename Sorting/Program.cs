using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            var person1 = new Person()
            {
                LastName = "Smith",
                FirstName = "John",
                Age = 36
            };

            var person2 = new Person()
            {
                LastName = "Jones",
                FirstName = "John",
                Age = 46
            };

            var person3 = new Person()
            {
                LastName = "Smith",
                FirstName = "John",
                Age = 26
            };

            Console.WriteLine(Person.Compare(person1, person3));
            Console.ReadLine();
        }
    }
}
