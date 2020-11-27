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
            CustomList<string> customStrings = new CustomList<string> { };
            customStrings.Add("ass");
            customStrings.Add("butt");
            customStrings.Add("cock");
            Console.WriteLine(customStrings[0].ToString());
            Console.ReadLine();
        }
    }
}
