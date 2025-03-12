using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    public class IdNumber
    {
        public int Number { get; set; }

        public IdNumber(int number)
        {
           if(number < 0)
            {
                throw new ArgumentException("ID должно быть положительным числом");
            }
            Number = number;
        }

        public override string ToString()
        {
            return $"{Number}";
        }

        public override int GetHashCode()
        {
            return Number.GetHashCode();
        }

        public IdNumber Clone()
        {
            return new IdNumber(Number);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is IdNumber))
            {
                return false;
            }
            var other = (IdNumber)obj;
            return this.Number == other.Number;
        }
    }
}
