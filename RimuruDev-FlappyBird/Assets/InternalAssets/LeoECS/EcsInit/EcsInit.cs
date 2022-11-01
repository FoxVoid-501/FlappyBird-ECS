using Leopotam.Ecs;
using RimuruDev.Core;
using UnityEngine;
using Voody.UniLeo;

namespace RimuruDev.ECS
{
    public sealed class EcsInit : MonoBehaviour
    {
        public EcsWorld ecsWorld;
        public EcsSystems ecsSystems;

        public GameDataContainer dataContainer;

        private void Awake() => dataContainer.GetComponent<GameDataContainer>();

        private void Start()
        {
            ecsWorld = new EcsWorld();
            ecsSystems = new EcsSystems(ecsWorld);

#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(ecsWorld);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(ecsSystems);
#endif
            ecsSystems.ConvertScene();
            {
                AddInjections();
                AddOneFrames();
                AddSystems();

            }
            ecsSystems.Init();
        }

        private void Update() => ecsSystems?.Run();

        private void OnDestroy()
        {
            if (ecsSystems != null)
            {
                ecsSystems.Destroy();
                ecsSystems = null;
                ecsWorld.Destroy();
                ecsWorld = null;
            }
        }

        private void AddSystems()
        {
            ecsSystems
            .Add(new SpawnBirdSystem())
            .Add(new InputSystem())
            .Add(new TimerPipeGeneratorSystem())
            .Add(new PipeGeneratorSystem())
            .Add(new DeathSystem())
            .Add(new PopupSpawnTimer())
            .Add(new AddPopup())
            //  .Add(new TimerForSaveScoreSystem())
            //  .Add(new TimerForBestSaveScoreSystem())
            //  .Add(new LoadScoreSystem())
            //  .Add(new LoadBestScoreSystem())
            //  .Add(new SaveScoreSystem())
            //  .Add(new SaveBestScoreSystem())
            .Add(new UpdateUIText()

            );
        }

        private void AddInjections()
        {
            ecsSystems.Inject(dataContainer);
        }

        private void AddOneFrames()
        {

        }
    }
}