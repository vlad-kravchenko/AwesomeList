using System;

namespace AwesomeListNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            var list = new AwesomeList<Person>();
            for(int i = 0; i < 44; i++)
            {
                Person p = new Person
                {
                    Age = random.Next(100),
                    FirstName = random.Next(200).ToString(),
                    LastName = random.Next(500).ToString()
                };
                list.Add(p);
            }

            list.RemoveAt(12);
            list.Add(new Person
            {
                Age = random.Next(100),
                FirstName = random.Next(200).ToString(),
                LastName = random.Next(500).ToString()
            });

            list.Sort();
            list.Reverse();

            list.Insert(new Person
            {
                Age = 25,
                FirstName = "Alex",
                LastName = "Keller"
            }, 12);

            foreach(var item in list)
            {
                Console.WriteLine(item.ToString());
            }

            var a = list.ToList();
            list.Clear();

            Console.ReadKey();
        }
    }
}