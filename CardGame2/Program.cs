using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "CARD GAME by nFs";

            Cards c = new Cards();
            c.Execute();

            Console.Read();
            Console.WriteLine();

        }
    }
}
