using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RokakNyulak
{
    public interface ITable
    {
        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        //Táblaméret mely 2 elemű [y - sor, x - oszlop].
        int[] Size { get; set; }

        /// <summary>
        /// The fields
        /// </summary>
        //A mezők listája
        List<Field> Fields { get; set; }

        /// <summary>
        /// Draws the fields.
        /// </summary>
        //Kiírja a Field-eket.
        void DrawFields();
    }
}
