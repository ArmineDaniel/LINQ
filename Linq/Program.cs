using System;
using System.Linq;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] teams = { "Bavaria", "Borusia", "Real Madrid", "Manchester City", "PSG", "Barcelona" };
            var selectedTeams = from t in teams
                                where t.ToUpper().StartsWith("B")
                                orderby t
                                select t;
            foreach (string s in selectedTeams)
                Console.WriteLine(s);
            int number = (from t in teams where t.ToUpper().StartsWith("B") select t).Count();
            Console.WriteLine(number);
            Console.ReadLine();
        }
    }
}
