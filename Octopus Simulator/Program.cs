namespace OctopusSimulator
{
    public class Program
    {
        public static void Main()
        {
            Sandbox sandbox = new Sandbox();

            TryAction(sandbox, OctopusActions.MoveUp);
            TryAction(sandbox, OctopusActions.MoveLeft);
            TryAction(sandbox, OctopusActions.MoveRight);
            TryAction(sandbox, OctopusActions.MoveDown);
        }

        private static void TryAction(Sandbox sandbox, OctopusActions action)
        {
            
        }
    }
}