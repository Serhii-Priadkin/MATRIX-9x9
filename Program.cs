using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sololearn
{
    class Program
    {
        static void Main(string[] args)
        {

            int[,] matrix = new int[9, 9];
            Random random = new Random();
            int column = 0;
            int row = 0;
            int removedInRows = 0;
            int removedInColumns = 0;

            Console.WriteLine("The matrix is created from random numbers(from 0 to 3 inclusive): \n");
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    matrix[i, j] = random.Next(0, 4);
                    Console.Write(matrix[i, j] + " ");

                    if (i != 0 && i != 1 && (matrix[i, j] == matrix[i - 1, j] && matrix[i, j] == matrix[i - 2, j]))
                    {
                        column++;
                    }

                    if (j != 0 && j != 1 && (matrix[i, j] == matrix[i, j - 1] && matrix[i, j] == matrix[i, j - 2]))
                    {
                        row++;
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nThe same trinities of numbers in row: " + row);
            Console.WriteLine("The same trinities of numbers in column: " + column+"\n\n");
            Console.WriteLine("The matrix after removing all same trinities of numbers: \n");



            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    do
                    {
                        if (j != 0 && j != 1 && matrix[i, j] == matrix[i, j - 1] && matrix[i, j] == matrix[i, j - 2])
                        {

                            for (int x = i; x > 0; x--)
                            {
                                matrix[x, j] = matrix[x - 1, j];
                                matrix[x, j - 1] = matrix[x - 1, j - 1];
                                matrix[x, j - 2] = matrix[x - 1, j - 2];
                            }
                            for (int x = j; x > j - 3; x--)
                            {
                                matrix[0, x] = random.Next(0, 4);
                            }
                            i = 0;
                            j = 0;
                            removedInColumns++;
                        }
                        if (i != 0 && i != 1 && matrix[i, j] == matrix[i - 1, j] && matrix[i, j] == matrix[i - 2, j])
                        {
                            for (int x = i; x > 2; x--)
                            {
                                matrix[x, j] = matrix[x - 3, j];
                            }
                            for (int x = 0; x < 3; x++)
                            {
                                matrix[x, j] = random.Next(0, 4);
                            }
                            i = 0;
                            j = 0;
                            removedInRows++;
                        }


                    }
                    while ((i != 0 && i != 1 && matrix[i, j] == matrix[i - 1, j] && matrix[i, j] == matrix[i - 2, j]) &&
               (j != 0 && j != 1 && matrix[i, j] == matrix[i, j - 1] && matrix[i, j] == matrix[i, j - 2]));

                }
            }
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\nNumber of same trinities that had removed in rows: " + removedInRows);
            Console.WriteLine("Number of same trinities that had removed in columns: " + removedInColumns);

        }
    }
}