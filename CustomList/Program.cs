using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomList;


namespace CustomList
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 4;
            i.ToString();
            char e = 'e';
            e.ToString();
            Person person = new Person("Trey", 43);
            string personString = person.ToString();
            Console.WriteLine(person);
            Console.ReadLine();

        }
    }
}
