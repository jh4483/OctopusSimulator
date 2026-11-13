namespace OctopusSimulator
{
    public class Program
    {
        public static void Main()
        {
            Sandbox sandbox = new Sandbox();

            for (int i = 0; i < 3; i++) Try(sandbox, OctopusActions.MoveDown);
            for (int i = 0; i < 9; i++) Try(sandbox, OctopusActions.MoveRight);

            Try(sandbox, OctopusActions.MoveRight);
            for (int i = 0; i < 3; i++) Try(sandbox, OctopusActions.SpeedUp);
            Try(sandbox, OctopusActions.MoveRight);
            Try(sandbox, OctopusActions.MoveRight);
        }

        private static void Try(Sandbox sandbox, OctopusActions action)
        {
            StepOutcome outcome = sandbox.TakeStep(action);
            Console.WriteLine($"{action}: {Describe(outcome)}");
            Console.WriteLine($"  Row: {sandbox.OctopusRow}, Column: {sandbox.OctopusColumn}, Speed: {sandbox.OctopusSpeed}, Turn: {sandbox.TurnCount}, Over: {sandbox.IsRunOver}");
        }

        private static string Describe(StepOutcome outcome) => outcome switch
        {
            StepOutcome.Moved => "The octopus moved.",
            StepOutcome.BlockedByWall => "The octopus hit a wall.",
            StepOutcome.SpeedIsZero => "The octopus is at speed 0 and can't move.",
            StepOutcome.SpeedChanged => "The octopus changed speed.",
            StepOutcome.SpeedLimitReached => "The speed limit has been reached.",
            StepOutcome.DrawerHitTooSoftly => "The octopus hit the drawer too softly.",
            StepOutcome.DrawerBroken => "The octopus broke the drawer!",
            StepOutcome.RunAlreadyOver => "The run is already over.",
            StepOutcome.ActionNotSupported => "That action isn't supported yet.",
            _ => "Unknown outcome."
        };
    }
}