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
        public int IsPrise(TextBox cena)
        {
            if (cena.Text == "")
            {
                return 0;
            }
            else if (Convert.ToInt32(cena.Text) == 0)
            {
                return 0;
            }
            else
            return 1;
        }
    }
}
