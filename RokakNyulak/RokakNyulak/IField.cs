using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RokakNyulak
{
    public interface IField
    {
        /// <summary>
        /// The entity
        /// </summary>
        //Entitás neve (fajtája?!)
        string Entity { get; set; }

        /// <summary>
        /// The position of entity
        /// </summary>
        //A Field (entitás) pozíciója mely 2 elemű int tömb [y - sor, x - oszlop].
        int[] Pos { get; set; }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>
        /// The color.
        /// </value>
        //A Field (entitás?!) színe. ConsoleColor a típusa.
        ConsoleColor Color { get; set; }
    }
}
