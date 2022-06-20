using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartProject
{
    internal class StudentCard
    {
        public int Number { get; set; }
        public string Series { get; set; }

        public StudentCard(int number, string series)
        {
            Number = number;
            Series = series;
        }

        public override string ToString()
        {
            return $"Student card: {Number}, {Series}";
        }
    }
}
