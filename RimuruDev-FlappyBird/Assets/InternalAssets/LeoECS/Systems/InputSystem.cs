using Leopotam.Ecs;
using RimuruDev.Core;
using UnityEngine;

namespace RimuruDev.ECS
{
    internal sealed class InputSystem : IEcsRunSystem
    {
        private readonly GameDataContainer dataContainer = null;
        private readonly EcsFilter<BirdComponent> bird = null;

        public void Run()
        {
            if (!Input.GetMouseButtonDown(0)) return;

            foreach (var i in bird)
            {
                ref var birdRigidbody = ref bird.Get1(i).birdRigidbody;
                ref var birdFlyForce = ref bird.Get1(i).flyUpForce;

                birdRigidbody = ref dataContainer.birdRigidbody;
                birdFlyForce = ref dataContainer.flyUpForce;

                FlyUp(ref birdRigidbody, ref birdFlyForce);
            }
        }

        private void FlyUp(ref Rigidbody2D birdRigidbody2D, ref float flyUpForce) =>
           birdRigidbody2D.velocity = Vector2.up * flyUpForce;
    }
}