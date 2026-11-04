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

        public Sandbox()
        {
            StartNewRun();
        }

        private void StartNewRun()
        {
            _octopus = new Octopus(StartRow, StartColumn, StartSpeed);
            Console.WriteLine(_octopus);
            _turnCounter = 0;
        }
    }
}