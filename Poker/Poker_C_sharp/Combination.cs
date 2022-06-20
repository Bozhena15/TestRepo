using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_C_sharp
{
    internal class Combination
    {
        private int combolvl;
        public int ComboLvl { get { return combolvl; } set { combolvl = value; } }
        public int[] combohighcard = new int[5];
        private string comboname;
        public string ComboName { get { return comboname; } set { comboname = value; } }
        public Combination()
        {
            ComboLvl = 0;
            comboname = "";

        }

    }
}
