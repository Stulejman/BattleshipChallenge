using BattleshipChallenge.Model.Interfaces;

namespace BattleshipChallenge.Model
{
    public class ConsoleBoardPrinter : IBoardPrinter
    {
        public void Print(IBoard board)
        {
            Console.Clear();
            char CurrentRow = 'A';
            Console.Write(" ");
            for (int i = 1; i <= board.XSize; i++)
            {
                Console.Write("|" + i);
            }

            Console.WriteLine();
            for (int y = 0; y < board.YSize; y++)
            {

                Console.Write(CurrentRow + "|");
                for (int x = 0; x < board.XSize; x++)
                {
                    Cell currentCell = board.Cells.Where(c => c.XCoordinate == x && c.YCoordinate == y).First();
                    char currentCellLabel;
#if DEBUG
                    if (currentCell.HasShip)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        currentCellLabel = currentCell.IsHit ? 'X' : 'O';
                    }
                    else
                    {
                        currentCellLabel = ' ';
                    }
#else
                    if (currentCell.IsHit)
                    {
                        if (currentCell.HasShip)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            currentCellLabel = currentCell.IsHit ? 'X' : 'O';
                        }
                        else
                        {
                            currentCellLabel = ' ';
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        currentCellLabel = '~';
                    }
#endif
                    Console.Write($"{currentCellLabel}");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"|");
                }
                Console.WriteLine("");
                CurrentRow++;
            }
        }
    }
}
