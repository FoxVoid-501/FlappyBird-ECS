using UnityEngine;

namespace RimuruDev.ECS
{
    internal struct BirdComponent
    {
        public GameObject birdPrefab;
        public Rigidbody2D birdRigidbody;

        public float flyUpForce;
    }
}