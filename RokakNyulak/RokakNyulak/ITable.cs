using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RokakNyulak
{
    public interface ITable
    {
        //Size [X,Y]
        int[] Size { get; set; }
        //Fields
        List<Field> Fields { get; set; }

        //SetCellColor
        //bool SetCellColor(int[] pos);

        //DrawFields
        void DrawFields();
    }
}
