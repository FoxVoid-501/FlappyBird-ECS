using UnityEngine;

namespace RimuruDev.ECS
{
    [SerializeField]
    public struct PipeSettingsComponent
    {
        public GameObject pipePrefab;
        public float pipeMotionSpeed;
    }
}