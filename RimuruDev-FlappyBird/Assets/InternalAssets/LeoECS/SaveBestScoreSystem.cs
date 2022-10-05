using Leopotam.Ecs;
using RimuruDev.Core;

namespace RimuruDev.ECS
{
    internal class SaveBestScoreSystem : IEcsRunSystem
    {
        private readonly GameDataContainer dataContainer = null;
        private readonly EcsFilter<BestScoreCompopent>.Exclude<TimerForSaveBestScore> timerFilter = null;

        public void Run()
        {
            foreach (var i in timerFilter)
            {
                ref var entity = ref timerFilter.GetEntity(i);
                ref var bestScore = ref timerFilter.Get1(i).bestScore;
                ref var timer = ref entity.Get<TimerForSaveBestScore>().timer;

                if (bestScore > dataContainer.score)
                {
                    return;
                }
                else if (bestScore < dataContainer.score)
                {
                    bestScore = dataContainer.score;
                }

                timer = dataContainer.autoSaveBestScoreTimer;
            }
        }
    }
    internal struct TimerForSaveBestScore { public float timer; }
}