using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class Person: IComparable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public int CompareTo(Object obj)
        {
            var otherPerson = (Person) obj;
            return String.Compare(this.LastName, otherPerson.LastName);
        }

        public static int Compare(Person person1, Person person2)
        {
            return person1.CompareTo(person2);
        }
    }
}
