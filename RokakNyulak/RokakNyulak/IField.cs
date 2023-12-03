using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RokakNyulak
{
    public interface IField
    {
        //entity = "grass,fox,rabbit"
        string Entity { get; set; }

        //pos = int[2] -> row,col
        int[] Pos { get; set; }

        //Color
        ConsoleColor Color { get; set; }
    }
}
