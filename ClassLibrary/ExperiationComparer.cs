using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    public class ExperiationComparer : IComparer<BankCard>
    {
        public int Compare(BankCard x, BankCard y)
        {
            if (x == null || y == null) return 0;


            DateTime dateX = DateTime.ParseExact(x.ExpirationDate, "dd.M.yyyy", CultureInfo.InvariantCulture);
            DateTime dateY = DateTime.ParseExact(y.ExpirationDate, "dd.M.yyyy", CultureInfo.InvariantCulture);

            return dateX.CompareTo(dateY);
        }
    }
}
