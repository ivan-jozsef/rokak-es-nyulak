using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RokakNyulak
{
    public class Table : ITable
    {
        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        //Táblaméret mely 2 elemű int tömb [y - sor, x - oszlop].
        public int[] Size { get; set; }

        /// <summary>
        /// The fields
        /// </summary>
        //A mezők listája
        public List<Field> Fields { get; set; }

        /// <summary>
        /// Sets the color of the cell.
        /// </summary>
        /// <param name="color">The background color.</param>
        //Beállítja a konzol háttérszínét a megadott színre.
        private void SetCellColor(ConsoleColor color) => Console.BackgroundColor = color;

        /// <summary>
        /// Draws the fields.
        /// </summary>
        //Kiírja a Field-eket.
        public void DrawFields()
        {
            foreach (var field in Fields)
            {
                Console.SetCursorPosition(field.Pos[0], field.Pos[1]);
                SetCellColor(field.Color);
                Console.Write(" ");
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Table"/> class.
        /// </summary>
        /// <param name="fields">The list of fields.</param>
        /// <param name="size">The size of Table [y - rows,x - cols].</param>
        //Table konstruktor, két paramétere van: A Field-ek listája, a maximális méret egy 2 elemű int tömbben. [y - sorok, x - oszlopok]
        public Table(List<Field> fields, int[] size) 
        {
            this.Size = size;
            this.Fields = fields;
        }
    }
}
