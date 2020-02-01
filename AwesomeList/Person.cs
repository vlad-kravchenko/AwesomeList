using System;

namespace AwesomeListNamespace
{
    public class Person : IComparable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public int CompareTo(object o)
        {
            Person p = o as Person;
            if (p != null)
                return LastName.CompareTo(p.LastName);
            else
                throw new Exception("Невозможно сравнить два объекта");
        }

        public override string ToString()
        {
            return $"{LastName} {FirstName}: {Age}";
        }
    }
}