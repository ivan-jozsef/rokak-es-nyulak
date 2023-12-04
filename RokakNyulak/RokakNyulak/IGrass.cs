using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RokakNyulak
{
    public interface IGrass : IField
    {
        /// <summary>
        /// Gets or sets the food value.
        /// </summary>
        /// <value>
        /// The food value.
        /// </value>
        //Tápértéke a Grass Field -nek.
        int Food_value {  get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        //Grass Field állapota
        int State { get; set; }

    }
}
