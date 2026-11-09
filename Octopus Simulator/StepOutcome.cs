namespace OctopusSimulator
{
    public enum StepOutcome
    {
        Moved,
        BlockedByWall,
        SpeedIsZero,
        SpeedChanged,
        SpeedLimitReached,
        ActionNotSupported
    }
}