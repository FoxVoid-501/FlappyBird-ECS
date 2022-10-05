using RimuruDev.Core;
using RimuruDev.Helpers;
using UnityEngine;

namespace RimuruDev.Mechanics
{
    public sealed class PipeMotionController : MonoBehaviour
    {
        private GameDataContainer dataContainer;

        private void Awake() => dataContainer = IsNullFind<GameDataContainer>.Find(ref dataContainer, this);

        private void Update()
        {
            if (!dataContainer.isPipeSpawn) return;

            transform.Translate(-dataContainer.pipeMotionSpeed * Time.deltaTime, 0, 0);
        }
    }
}