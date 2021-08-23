using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee veli = new Employee {Name = "Veli Görgülü"};

            Employee burak = new Employee { Name = "Burak Yavaş" };

            veli.AddSubordinate(burak);

            Employee sukru = new Employee { Name = "Şükrü Sonar" };
            veli.AddSubordinate(sukru);

            Contractor ercan = new Contractor {Name = "Ercan"};
            sukru.AddSubordinate(ercan);

            Employee ahmet = new Employee { Name = "Ahmet" };
            burak.AddSubordinate(ahmet);

            Console.WriteLine(veli.Name);
            foreach (Employee manager in veli)
            {
                Console.WriteLine("  {0}",manager.Name);
                foreach (IPerson employee in manager)
                {
                    Console.WriteLine("    {0}", employee.Name);
                }

            }

            Console.ReadLine();

        }
    }

    interface IPerson
    {
        string Name { get; set; }
    }

    class Contractor:IPerson
    {
        public string Name { get; set; }
    }

    class Employee:IPerson,IEnumerable<IPerson>
    {
        List<IPerson> _subordinates =new List<IPerson>();

        public void AddSubordinate(IPerson person)
        {
            _subordinates.Add(person);
        }

        public void RemoveSubordinate(IPerson person)
        {
            _subordinates.Remove(person);
        }

        public IPerson GetSubordinate(int index)
        {
            return _subordinates[index];
        }

        public string Name { get; set; }
        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subordinate in _subordinates)
            {
                yield return subordinate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
