using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartProject
{
    internal class Mas
    {
        const int size = 10;
        public static int[] First { get; private set; }

        public Mas()
        {
            First = new int[size];
            Console.WriteLine("Об'єкт успішно створено");
        }

        ~Mas() { }

        public void AddMas()
        {
            for(int i = 0; i < size; i++)
                First[i] = Convert.ToInt32(Console.ReadLine());
        }

        public void ChangeMinAndMax()
        {
            int min = First.Min();
            int max = First.Max();

            First[0] = min;
            First[size - 1] = max;
        }

        public void Print()
        {
            foreach(int i in First) 
                Console.WriteLine(i);
        }
    }
}
