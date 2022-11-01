using Leopotam.Ecs;
using UnityEngine;

namespace RimuruDev.ECS
{
    internal sealed class TimerPipeGeneratorSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PipeGenerationTimer> pipeGenrationTimer = null;

        public void Run()
        {
            foreach (var i in pipeGenrationTimer)
            {
                ref var entity = ref pipeGenrationTimer.GetEntity(i);
                ref var timer = ref pipeGenrationTimer.Get1(i);

                // TODO: Timer.Elapsed
                timer.Timer -= Time.deltaTime;

                if (timer.Timer <= 0)
                    entity.Del<PipeGenerationTimer>();
            }
        }
    }
}