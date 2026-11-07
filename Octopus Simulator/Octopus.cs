namespace OctopusSimulator
{
    public class Octopus
    {
        public int Row {get; private set;}
        public int Column {get; private set;}
        public int Speed {get; private set;}

        public Octopus(int row, int column, int speed)
        {
            Row = row;
            Column = column;
            Speed = speed;
        }

        public void MoveTo(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public void SetSpeed(int speed)
        {
            Speed = speed;
        }
    }
}