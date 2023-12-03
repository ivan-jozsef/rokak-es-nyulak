using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RokakNyulak
{
    public class Table : ITable
    {
        public int[] Size { get; set; }
        public List<Field> Fields { get; set; }

        private void SetCellColor(ConsoleColor color) => Console.BackgroundColor = color;

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

        public Table(List<Field> fields, int[] size) 
        {
            this.Size = size;
            this.Fields = fields;
        }
    }
}
