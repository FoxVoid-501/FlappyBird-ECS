using RimuruDev.Core;

namespace RimuruDev.ECS
{
    public static class EventHandler
    {
        public static void RewardAccrual(ref int reward) => GameDataContainer.eventontainer.score += reward;
    }
}