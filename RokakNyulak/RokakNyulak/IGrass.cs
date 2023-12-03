using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RokakNyulak
{
    public interface IGrass : IField
    {
       //food_value (tápérték)
       int Food_value {  get; set; }

       //state
       int State { get; set; }

    }
}
