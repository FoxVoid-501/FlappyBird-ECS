using Leopotam.Ecs;
using RimuruDev.Core;
using UnityEngine;

namespace RimuruDev.ECS
{
    internal sealed class SpawnBirdSystem : IEcsInitSystem
    {
        private readonly GameDataContainer dataContainer = null;
        private readonly EcsWorld ecsWorld = null;

        public void Init()
        {
            ref var birdPrefab = ref ecsWorld.NewEntity().Get<BirdComponent>().birdPrefab;
            ref var birdSpawnPoint = ref ecsWorld.NewEntity().Get<BirdSpawnPoint>().birdSpawnPoint;

            birdPrefab = dataContainer.birdPrefab;
            birdSpawnPoint = dataContainer.birdSpawnPosition;

            var birdClone = Object.Instantiate(birdPrefab, birdSpawnPoint, Quaternion.identity);

            dataContainer.birtClone = birdClone;
            dataContainer.birdRigidbody = dataContainer.birtClone.GetComponent<Rigidbody2D>();
        }
    }
}