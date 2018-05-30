using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Cennik
{
    public class Prise
    {
        public int IsPrise(decimal? cena)
        {
            if (cena == 0)
            {
                return 0;
            }           
            else
            return 1;
        }
    }
}
