using System;
using System.Collections.Generic;
using System.Linq;

namespace Filter

{
    class Program
    {
        class User
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public List<string> Languages { get; set; }
            public User()
            {
                Languages = new List<string>();
            }
        }
        static void Main(string[] args)
        {
            List<User> users = new List<User>
            {
                new User {Name="Tom", Age=25, Languages=new List<string>{"English","Armenian"} },
                new User {Name="Artur", Age=27,Languages=new List<string>{"English","Russian"}},
                new User {Name="Alen",Age=29,Languages=new List<string>{"Spanish", "Russian"} },
                new User {Name="Bill", Age=34,Languages=new List<string>{"Armenian","Spanish","English"}}
            };
            var selectedUsers = from user in users
                                from lang in user.Languages
                                where user.Age > 25
                                where lang == "English"
                                select user;
            foreach (User u in selectedUsers)
                Console.WriteLine($"name-{u.Name} Age-{u.Age}");
            
            var items = users.Select(u => new
            {
                FirstName = u.Name,
                DateOfBirth=DateTime.Now.Year-u.Age
            });
            foreach(var t in items)
                Console.WriteLine($"FirstName-{t.FirstName} Date of brith-{t.DateOfBirth}");
            var people = from u in users
                         let name = "Mr. " + u.Name
                         select new
                         {
                             Name = name,
                             Age = u.Age
                         };
            foreach(var p in people)
                Console.WriteLine($"name-{p.Name} age-{p.Age}");
            Console.ReadLine();
        }
    }
}
