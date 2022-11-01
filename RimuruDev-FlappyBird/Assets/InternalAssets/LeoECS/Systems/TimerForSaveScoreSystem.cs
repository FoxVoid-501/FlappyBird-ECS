using Leopotam.Ecs;
using UnityEngine;

namespace RimuruDev.ECS
{
    internal sealed class TimerForSaveScoreSystem : IEcsRunSystem
    {
        private readonly EcsFilter<TimerForSaveScore> timerFilter = null;

        public void Run()
        {
            foreach (var i in timerFilter)
            {
                ref var entity = ref timerFilter.GetEntity(i);
                ref var timer = ref timerFilter.Get1(i);

                timer.timer -= Time.deltaTime;

                if (timer.timer == 0)
                    entity.Del<TimerForSaveScore>();
            }
        }
    }

    internal sealed class TimerForBestSaveScoreSystem : IEcsRunSystem
    {
        private readonly EcsFilter<TimerForSaveBestScore> timerFilter = null;

        public void Run()
        {
            foreach (var i in timerFilter)
            {
                ref var entity = ref timerFilter.GetEntity(i);
                ref var timer = ref timerFilter.Get1(i);

                timer.timer -= Time.deltaTime;

                if (timer.timer == 0)
                    entity.Del<TimerForSaveBestScore>();
            }
        }
    }
}