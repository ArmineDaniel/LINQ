using System;
using System.Collections.Generic;
using System.Linq;

namespace Grouping
{
    class Program
    {
        class Phone
        {
            public string Name { get; set; }
            public string Company { get; set; }
        }
        static void Main(string[] args)
        {
            List<Phone> phones = new List<Phone>
{
    new Phone {Name="Lumia 430", Company="Microsoft" },
    new Phone {Name="Mi 5", Company="Xiaomi" },
    new Phone {Name="LG G 3", Company="LG" },
    new Phone {Name="iPhone 5", Company="Apple" },
    new Phone {Name="Lumia 930", Company="Microsoft" },
    new Phone {Name="iPhone 6", Company="Apple" },
    new Phone {Name="Lumia 630", Company="Microsoft" },
    new Phone {Name="LG G 4", Company="LG" }
};
            var phoneGroups = phones.GroupBy(p => p.Company);
            foreach (IGrouping<string, Phone> g in phoneGroups)
            {
                Console.WriteLine(g.Key);
                foreach (var t in g)
                    Console.WriteLine(t.Name);
                Console.WriteLine();             
            }
            var phoneGroups1 = phones.GroupBy(p => p.Company)
                        .Select(g => new
                        {
                            Name = g.Key,
                            Count = g.Count(),
                            Phones = g.Select(p => p)
                        });
            foreach (var group in phoneGroups1)
            {
                Console.WriteLine($"{group.Name} : {group.Count}");
                foreach (Phone phone in group.Phones)
                    Console.WriteLine(phone.Name);
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
