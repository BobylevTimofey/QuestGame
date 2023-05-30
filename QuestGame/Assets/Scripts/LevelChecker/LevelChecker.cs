public static class LevelChecker
{
    public static bool IsGameStart { get => true; }
    public static bool IsTryOpenDoor { get; set; }
    public static bool IsOpenDoor { get; set; }
    public static bool IsTakeMap { get; set; }
    public static bool IsComeToMountain { get; set; }
    public static bool IsSolveQuestLever { get; set; }
    public static bool IsSolveQuestInCastleWithSearchItems { get; set; }
    public static bool IsHeroTalkAIFirstTime { get; set; }
    public static bool IsHeroTakeTaskBartender { get; set; }
    public static bool IsHeroTakeTaskBlacksmith { get; set; }
    public static bool IsHeroTakeTaskMinerWithGears { get; set; }
    public static bool IsHeroDidTaskMinerWithGears { get; set; }
    public static bool IsHeroTakePickaxeAndHelpMinerWithMechanism { get; set; }
    public static bool IsHeroExtractedOre { get; set; }
    public static bool IsHeroHelpBlacksmithWithOven { get; set; }
    public static bool IsHeroReceivedHintFromBartender { get; set; }
    public static bool IsHeroFindFirstPartAI { get; set; }
    public static bool IsHeroReceivedHintFromMiner { get; set; }
    public static bool IsHeroFindSecondPartAI { get; set; }
    public static bool IsHeroRepairBridge { get; set; }
    public static bool IsHeroFindThirdPartAI { get; set; }
    public static bool IsHeroActivatedPortal { get; set; }
}
