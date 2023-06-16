using BattleshipChallenge.Model.Abstract;
using BattleshipChallenge.Model.Interfaces;
using BattleshipChallenge.Model.Ships;

namespace BattleshipChallenge.Model
{
    public class BoardFactory : IBoardFactory
    {
        private const ushort XSize = 10, YSize = 10;
        readonly List<Ship> ships = new() { new Destroyer(), new Destroyer(), new Battleship() };
        public IBoard CreateBoard()
        {
            List<Cell> cells = new();
            for (ushort x = 0; x <= XSize; x++)
            {
                for (ushort y = 0; y <= YSize; y++)
                {
                    cells.Add(new Cell(x, y));
                }
            }
            PlaceShips(cells);
            var board = new Board(XSize, YSize) { Cells = cells};
            return board;
        }

        private void PlaceShips(List<Cell> cells)
        {
            var random = new Random();
            foreach(var ship in ships)
            {
                var cellsForShip = new List<Cell>();
                var direction = GetRandomDirections();
                bool isShipPlaced = false;

                do
                {
                    List<Cell> proposedCells = new();
                    if (direction == Direction.Horizontal)
                    {
                        //Ycoord can be any between 0 and ysize
                        //xcoord must be any between 0 and xsize - ship.size
                        var xCoord = random.Next(0, XSize - ship.Size);
                        var yCoord = random.Next(0, YSize);
                        proposedCells = cells.Where(c=>c.YCoordinate == yCoord && c.XCoordinate > xCoord && c.XCoordinate <= xCoord + ship.Size && !c.HasShip).ToList();
                    }
                    else if(direction == Direction.Vertical)
                    {
                        //Xcoord can be any between 0 and Xsize
                        //Ycoord must be any between 0 and Ysize - ship.size
                        var xCoord = random.Next(0, XSize);
                        var yCoord = random.Next(0, YSize - ship.Size);
                        proposedCells = cells.Where(c => c.XCoordinate == xCoord && c.YCoordinate > yCoord && c.YCoordinate <= yCoord + ship.Size && !c.HasShip).ToList();
                    }

                    //if proposed cells collection size equals ship size we can place ship,
                    //otherwise we`ve picked up cells that already has a ship, and we need to repeat
                    if (proposedCells.Count == ship.Size)
                    {
                        foreach (var cell in proposedCells)
                        {
                            cell.AddShip(ship);
                        }
                        isShipPlaced = true;
                    }
                } while (!isShipPlaced);
            }
        }

        private static Direction GetRandomDirections()
        {
            var random = new Random();
            var direction = Enum.GetValues(typeof(Direction)).OfType<Direction>().OrderBy(x => random.Next());
            return direction.First();
        }

        private enum Direction
        {
            Horizontal,
            Vertical
        }
    }
}
