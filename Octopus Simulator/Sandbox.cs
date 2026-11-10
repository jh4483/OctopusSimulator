namespace OctopusSimulator
{
    public class Sandbox
    {
        private const int NumberOfRows = 10;
        private const int NumberOfColumns = 20;
        private const int StartRow = 0;
        private const int StartColumn = 0;
        private const int StartSpeed = 5;

        private const int MinSpeed = 0;
        private const int MaxSpeed = 30;
        private const int StepSpeed = 5;

        private (int Row, int Column) _drawerPosition = (3, 10);
        private int _turnCounter = 0;
        private Octopus _octopus = null!;

        public int OctopusRow => _octopus.Row;
        public int OctopusColumn => _octopus.Column;
        public int OctopusSpeed => _octopus.Speed;
        public int TurnCount => _turnCounter;

        public bool HasDrawerBroken = false;

        public Sandbox()
        {
            StartNewRun();
        }

        private void StartNewRun()
        {
            _octopus = new Octopus(StartRow, StartColumn, StartSpeed);
            _turnCounter = 0;
            HasDrawerBroken = false;
        }

        public StepOutcome TakeStep(OctopusActions action)
        {
            if(_turnCounter < 100 && !HasDrawerBroken)
            {
                _turnCounter++;

                switch (action)
                {
                    case OctopusActions.MoveUp:
                        return TryMove(-1, 0);
                    case OctopusActions.MoveDown:
                        return TryMove(1, 0);
                    case OctopusActions.MoveLeft:
                        return TryMove(0, -1);
                    case OctopusActions.MoveRight:
                        return TryMove(0, 1);
                    case OctopusActions.SpeedUp:
                        return ChangeSpeed(StepSpeed);
                    case OctopusActions.SpeedDown:
                        return ChangeSpeed(-StepSpeed);
                    default:
                        return StepOutcome.ActionNotSupported;
                }
            }
            else return StepOutcome.OutOfTurns;
        }

        private StepOutcome TryMove(int rowChange, int columnChange)
        {
            if (_octopus.Speed == 0)
            {
                return StepOutcome.SpeedIsZero;
                Console.WriteLine("Octopus is at 0 speed.")
            }

            int newRow = _octopus.Row + rowChange;
            int newColumn = _octopus.Column + columnChange;

            if (!IsInsideRoom(newRow, newColumn))
            {
                return StepOutcome.BlockedByWall;
                Console.WriteLine("Octopus has been hit by a wall")
            }

            if(_octopus.Speed >= 20 && newRow == _drawerPosition.Row && newColumn == _drawerPosition.Column)
            {
                HasDrawerBroken = true;
                return StepOutcome.DrawerBroken;
                Console.WriteLine("Octopus has broken the drawer")
            }

            if(_octopus.Speed < 20 && newRow == _drawerPosition.Row && newColumn == _drawerPosition.Column)
            {
                return StepOutcome.DrawerHitTooSoftly;
                Console.WriteLine("Octopus hit the drawer too softly")
            }

            _octopus.MoveTo(newRow, newColumn);
            return StepOutcome.Moved;
        }

        private StepOutcome ChangeSpeed(int change)
        {
            int newSpeed = _octopus.Speed + change;

            if (newSpeed < MinSpeed || newSpeed > MaxSpeed)
            {
                return StepOutcome.SpeedLimitReached;
            }

            _octopus.SetSpeed(newSpeed);
            return StepOutcome.SpeedChanged;
        }

        private bool IsInsideRoom(int row, int column)
        {
            if(row >=0 && row <=9 && column >= 0 && column <= 19)
            {
                return true;
            }

            return false;
        }
    }
}