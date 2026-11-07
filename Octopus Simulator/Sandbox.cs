namespace OctopusSimulator
{
    public class Sandbox
    {
        private const int NumberOfRows = 10;
        private const int NumberOfColumns = 20;
        private const int StartRow = 0;
        private const int StartColumn = 0;
        private const int StartSpeed = 5;

        private (int Row, int Column) _drawerPosition = (3, 10);
        private int _turnCounter = 0;
        private Octopus _octopus = null!;

        public int OctopusRow => _octopus.Row;
        public int OctopusColumn => _octopus.Column;
        public int OctopusSpeed => _octopus.Speed;
        public int TurnCount => _turnCounter;

        public Sandbox()
        {
            StartNewRun();
        }

        private void StartNewRun()
        {
            _octopus = new Octopus(StartRow, StartColumn, StartSpeed);
            _turnCounter = 0;
        }

        public bool TakeStep(OctopusActions action)
        {
            _turnCounter++;

            int newRow = _octopus.Row;
            int newColumn = _octopus.Column;

            switch (action)
            {
                case OctopusActions.MoveUp:
                    newRow--;
                    break;
                case OctopusActions.MoveDown:
                    newRow++;
                    break;
                case OctopusActions.MoveLeft:
                    newColumn--;
                    break;
                case OctopusActions.MoveRight:
                    newColumn++;
                    break;
                default:
                    return false;
            }

            if (!IsInsideRoom(newRow, newColumn))
            {
                return false;
            }

            _octopus.MoveTo(newRow, newColumn);
            return true;
        }

        private static bool IsInsideRoom(int row, int column)
        {
            return row >= 0 && row < NumberOfRows
                && column >= 0 && column < NumberOfColumns;
        }
    }
}