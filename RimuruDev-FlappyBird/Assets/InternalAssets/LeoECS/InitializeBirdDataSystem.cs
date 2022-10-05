using Leopotam.Ecs;
using RimuruDev.Core;
using RimuruDev.Helpers;
using UnityEngine;

namespace RimuruDev.ECS
{
    internal sealed class InitializeBirdDataSystem : IEcsInitSystem
    {
        private GameDataContainer dataContainer = null;
        private readonly EcsFilter<BirdComponent> bird = null;

        public void Init()
        {
            //var birdClone = GameObject.FindGameObjectWithTag(Tag.Player);

            //ref var birClone = ref 
        }
    }
}