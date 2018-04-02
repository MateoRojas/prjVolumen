using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjVolumen.Utils
{
    class Utils
    {

        public static Double getDoubleValue(String text)
        {
            try
            {
                return Double.Parse(text);
            }
            catch (Exception exception)
            {
                return 0;
            }

        }

    }
}
