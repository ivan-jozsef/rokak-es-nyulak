using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RokakNyulak
{
    public class Table
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
        public Fields TableFields { get; set; }

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
            Console.Clear();
            foreach (var field in TableFields.GetFields)
            {
                Console.SetCursorPosition(field.Pos[0], field.Pos[1]);
                SetCellColor(field.Color);
                Console.Write(" ");
                Console.ResetColor();
            }
            Console.WriteLine($"\nAktuális állapot: \n" +
                    $"\tFű mezők száma: {TableFields.GetEntityCount("grass")}\n" +
                    $"\tNyúl mezők száma: {TableFields.GetEntityCount("rabbit")}\n" +
                    $"\tRóka mezők száma: {TableFields.GetEntityCount("fox")}\n"+
                    $"\tMezők száma: {TableFields.GetFields.Count}");

            
            NextRound();
        }

        /// <summary>
        /// Nexts the round.
        /// </summary>
        public void NextRound()
        {
            foreach(var actField in TableFields.GetFields)
            {
                if (actField.Entity == "grass") {
                    Grass useField = (Grass) actField;
                    useField.Action(); 
                }
            }
            System.Threading.Thread.Sleep(5000);
            Console.Clear();
            DrawFields();
        }

        /// <summary>
        /// Starts the game.
        /// </summary>
        public void StartGame()
        { 
            DrawFields();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Table"/> class.
        /// </summary>
        /// <param name="fields">The list of fields.</param>
        /// <param name="size">The size of Table [y - rows,x - cols].</param>
        //Table konstruktor, két paramétere van: A Field-ek listája, a maximális méret egy 2 elemű int tömbben. [y - sorok, x - oszlopok]
        public Table(Fields fields) 
        {
            this.Size = fields.Size;
            this.TableFields = fields;
        }
    }
}
