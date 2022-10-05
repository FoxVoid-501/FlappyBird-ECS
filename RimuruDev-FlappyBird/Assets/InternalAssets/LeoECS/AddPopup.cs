using Leopotam.Ecs;
using RimuruDev.Core;

namespace RimuruDev.ECS
{
    internal sealed class AddPopup : IEcsInitSystem, IEcsRunSystem
    {
        private readonly GameDataContainer dataContainer = null;
        private readonly EcsWorld ecsWorld = null;
        private readonly EcsFilter<Popup, PerformDeathEvent>.Exclude<PopupTimer> popupFilter = null;

        public void Init()
        {
            var entity = ecsWorld.NewEntity();

            entity.Get<Popup>().popup = dataContainer.failurePanel;
            //entity.Get<PopupTimer>().timer = dataContainer.timePopupSpawn;
        }

        public void Run()
        {
            foreach (var i in popupFilter)
            {
                ref var entity = ref popupFilter.GetEntity(i);
                ref var popup = ref popupFilter.Get1(i);

                //entity.Get<PopupTimer>().timer = dataContainer.timePopupSpawn;

                popup.popup.SetActive(true);
                entity.Destroy();
            }
        }
    }

    internal struct PopupTimer { public float timer; }
}