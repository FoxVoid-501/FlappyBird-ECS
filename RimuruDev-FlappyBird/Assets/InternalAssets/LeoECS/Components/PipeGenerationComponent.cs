using UnityEngine;

namespace RimuruDev.ECS
{
    [SerializeField]
    public struct PipeGenerationComponent
    {
        public float pipeSpawnCooldown;
        public float pipeRandomPosition;
        public Vector2 pipeRandomRangeXY;
        public float pipeDestroyTimer;
        public bool isPipeSpawn;
        public float pipeSpawnPosX;
    }
}