using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RokakNyulak
{
    public class Fox : Field
    {
        Random rnd = new Random();


        public Fox(string entity, int[] pos, ConsoleColor color) : base("fox", pos, color)
        {

        }

        public void Move(List<Field> GetFields)
        {
            int currentCol = Pos[0];
            int currentRow = Pos[1];
            //Console.WriteLine($"Current Position: {Pos[0]}, {Pos[1]}");
            //foreach (var field in GetFields.Take(1))
            //{
            //    Console.WriteLine(field);
            //}

            int maxCol = GetFields.Max(field => field.Pos[0]);
            int maxRow = GetFields.Max(field => field.Pos[1]);

            int directionAttempts = 0;
            bool IsGrassOnField(int col, int row)
            {
                return GetFields.Any(field => field.Pos[0] == col && field.Pos[1] == row && field.Entity == "grass");
            }
            int direction = rnd.Next(8);

            Console.WriteLine($"Current Position: {currentCol}, {currentRow}");
            Console.WriteLine($"IsGrassOnField: {IsGrassOnField(currentCol, currentRow)}");

            while (directionAttempts < 8)
            {

                switch (direction)
                {
                    case 0: // Fel
                        if (currentRow > 0 && GetFields.Any(field => field.Pos[1] == currentRow - 1 && field.Pos[0] == currentCol && field.Entity == "grass"))
                        {
                            Pos[1]--;
                            return;
                        }
                        break;
                    case 1: // Jobbra felfelé
                        if (currentRow > 0 && currentCol < maxCol && GetFields.Any(field => field.Pos[1] == currentRow - 1 && field.Pos[0] == currentCol + 1 && field.Entity == "grass"))
                        {
                            Pos[1]--;
                            Pos[0]++;
                            return;                            
                        }
                        break;
                    case 2: // Jobbra
                        if (currentCol < maxCol - 1 && GetFields.Any(f => f.Pos[1] == currentRow && f.Pos[0] == currentCol + 1 && f.Entity == "grass"))
                        {
                            Pos[0]++;
                            return;
                        }
                        break;
                    case 3: // Jobbra lefelé
                        if (currentRow < maxRow - 1 && currentCol < maxCol - 1 && GetFields.Any(f => f.Pos[1] == currentRow + 1 && f.Pos[0] == currentCol + 1 && f.Entity == "grass"))
                        {
                            Pos[1]++;
                            Pos[0]++;
                            return;
                        }
                        break;
                    case 4: // Le
                        if (currentRow < maxRow - 1 && GetFields.Any(f => f.Pos[1] == currentRow + 1 && f.Pos[0] == currentCol && f.Entity == "grass"))
                        {
                            Pos[1]++;
                            return;
                        }
                        break;
                    case 5: // Balra lefelé
                        if (currentRow < maxRow - 1 && currentCol > 0 && GetFields.Any(f => f.Pos[1] == currentRow + 1 && f.Pos[0] == currentCol - 1 && f.Entity == "grass"))
                        {
                            Pos[1]++;
                            Pos[0]--;
                            return;
                        }
                        break;
                    case 6: // Balra
                        if (currentCol > 0 && GetFields.Any(f => f.Pos[1] == currentRow && f.Pos[0] == currentCol - 1 && f.Entity == "grass"))
                        {
                            Pos[0]--;
                            return;
                        }
                        break;
                    case 7: // Balra felfelé
                        if (currentRow > 0 && currentCol > 0 && GetFields.Any(f => f.Pos[1] == currentRow - 1 && f.Pos[0] == currentCol - 1 && f.Entity == "grass"))
                        {
                            Pos[1]--;
                            Pos[0]--;
                            return;
                        }
                        break;
                }

                    // Itt hozzáadunk egy új "Grass" példányt, csak ha a róka ténylegesen lépett rá az adott mezőre
                    if (!IsGrassOnField(currentCol, currentRow))
                    {
                        GetFields.Add(new Grass(new int[] { currentCol, currentRow }, rnd.Next(0, 2 + 1), rnd.Next(0, 3 + 1), ConsoleColor.Green));
                    }

                    return;
                }

                directionAttempts++;
            }
            //Console.WriteLine($"New Position: {Pos[0]}, {Pos[1]}");
        }



    }

