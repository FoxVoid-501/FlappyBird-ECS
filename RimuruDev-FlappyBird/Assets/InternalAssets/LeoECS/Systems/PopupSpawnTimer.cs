using Leopotam.Ecs;
using UnityEngine;

namespace RimuruDev.ECS
{
    internal class PopupSpawnTimer : IEcsRunSystem
    {
        private readonly EcsFilter<PopupTimer> popupTimer = null;

        public void Run()
        {
            foreach (var i in popupTimer)
            {
                ref var entity = ref popupTimer.GetEntity(i);
                ref var timer = ref popupTimer.Get1(i);

                // TODO: Timer.Elapsed
                timer.timer -= Time.deltaTime;

                if (timer.timer <= 0)
                    entity.Del<PopupTimer>();
            }
        }
    }
}