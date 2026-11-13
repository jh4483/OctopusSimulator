namespace OctopusSimulator
{
    public enum StepOutcome
    {
        Moved,
        BlockedByWall,
        SpeedIsZero,
        SpeedChanged,
        SpeedLimitReached,
        DrawerHitTooSoftly,
        DrawerBroken,
        OutOfTurns,
        RunAlreadyOver,
        ActionNotSupported
    }
}