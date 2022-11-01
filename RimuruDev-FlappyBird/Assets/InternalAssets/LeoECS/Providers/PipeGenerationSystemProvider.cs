using UnityEngine;

namespace RimuruDev.ECS
{
    [RequireComponent(typeof(PipeSpawnTagProvider))]
    [RequireComponent(typeof(PipeSettingsProvider))]
    [RequireComponent(typeof(PipeGenerationProvider))]
    public sealed class PipeGenerationSystemProvider : MonoBehaviour { }
}