using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace progg
{
    internal class AppVariables
    {
        public static int GlobalValue { get; set; }
        public static int GlobalIndex { get; set; }//переход на другой вид уровня
        public static int[] IsRight { get; set; } = new int[10];


    }
}
     