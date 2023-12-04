using System;

namespace Consola1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            String searchString = "a";
            string search = "c";
            string s1 = "barcos";
            string s2 = "los animales";

            Console.WriteLine(s1.IndexOf(searchString, 0));
            Console.WriteLine(s2.IndexOf(search, 12));
            Console.ReadLine();

        }
    }
}
