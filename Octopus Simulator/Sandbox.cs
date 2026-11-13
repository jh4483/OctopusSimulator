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

        private const int DrawerBreakSpeed = 20;
        private const int MaxTurns = 100;

        private (int Row, int Column) _drawerPosition = (3, 10);
        private int _turnCounter = 0;
        private bool _isDrawerBroken = false;
        private Octopus _octopus = null!;

        public int OctopusRow => _octopus.Row;
        public int OctopusColumn => _octopus.Column;
        public int OctopusSpeed => _octopus.Speed;
        public int TurnCount => _turnCounter;
        public bool IsDrawerBroken => _isDrawerBroken;
        public bool IsRunOver => _isDrawerBroken || _turnCounter >= MaxTurns;

        public Sandbox()
        {
            StartNewRun();
        }

        public void StartNewRun()
        {
            _octopus = new Octopus(StartRow, StartColumn, StartSpeed);
            _turnCounter = 0;
            _isDrawerBroken = false;
        }

        public StepOutcome TakeStep(OctopusActions action)
        {
            if (IsRunOver)
            {
                return StepOutcome.RunAlreadyOver;
            }

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

        private StepOutcome TryMove(int rowChange, int columnChange)
        {
            if (_octopus.Speed == 0)
            {
                return StepOutcome.SpeedIsZero;
            }

            int newRow = _octopus.Row + rowChange;
            int newColumn = _octopus.Column + columnChange;

            if (!IsInsideRoom(newRow, newColumn))
            {
                _octopus.SetSpeed(StartSpeed);
                return StepOutcome.BlockedByWall;
            }

            bool isDrawerCell = newRow == _drawerPosition.Row
                && newColumn == _drawerPosition.Column;

            if (isDrawerCell)
            {
                if (_octopus.Speed >= DrawerBreakSpeed)
                {
                    _isDrawerBroken = true;
                    return StepOutcome.DrawerBroken;
                }

                _octopus.SetSpeed(StartSpeed);
                return StepOutcome.DrawerHitTooSoftly;
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

        private static bool IsInsideRoom(int row, int column)
        {
            return row >= 0 && row < NumberOfRows
                && column >= 0 && column < NumberOfColumns;
        }
    }
}