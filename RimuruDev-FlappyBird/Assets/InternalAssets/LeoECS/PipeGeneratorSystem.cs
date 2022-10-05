using Leopotam.Ecs;
using RimuruDev.Core;
using UnityEngine;

namespace RimuruDev.ECS
{
    internal sealed class PipeGeneratorSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly GameDataContainer dataContainer = null;
        private readonly EcsWorld ecsWorld = null;

        private readonly EcsFilter<PipeSpawnTag, PipeSettingsComponent, PipeGenerationComponent>.
                         Exclude<PipeGenerationTimer> timePipeGeneratePipe = null;

        public void Init() => CreatingNewEntity();

        public void Run()
        {
            foreach (var i in timePipeGeneratePipe)
            {
                ref var PipeGeneratorEentity = ref timePipeGeneratePipe.GetEntity(i);

                ref var pipePrefab = ref PipeGeneratorEentity.Get<PipeSettingsComponent>().pipePrefab;
                ref var pipeSettings = ref PipeGeneratorEentity.Get<PipeGenerationComponent>();

                pipePrefab = ref dataContainer.pipePrefab;

                ref var pipespawnPosX = ref pipeSettings.pipeSpawnPosX;
                pipespawnPosX = ref dataContainer.pipeSpawnPosX; ;

                ref var pipeLifeTimer = ref pipeSettings.pipeDestroyTimer;
                pipeLifeTimer = ref dataContainer.pipeDestroyTimer;

                ref var pipeSpawnCooldown = ref pipeSettings.pipeSpawnCooldown;
                pipeSpawnCooldown = ref dataContainer.pipeSpawnCooldown;

                var newPipes = Object.Instantiate(pipePrefab, new Vector3(pipespawnPosX, RandomY(), 89), Quaternion.identity);

                Object.Destroy(newPipes, pipeLifeTimer);

                PipeGeneratorEentity.Get<PipeGenerationTimer>().Timer = pipeSpawnCooldown;
            }
        }

        private void CreatingNewEntity()
        {
            var pipeGeneratorEntity = ecsWorld.NewEntity();

            pipeGeneratorEntity.Get<PipeSpawnTag>();
            pipeGeneratorEntity.Get<PipeSettingsComponent>();
            pipeGeneratorEntity.Get<PipeGenerationComponent>();
        }

        private float RandomY() =>
           Random.Range(dataContainer.pipeRandomRangeXY.x, dataContainer.pipeRandomRangeXY.y);
    }
}