using RimuruDev.Core;
using RimuruDev.Helpers;
using System.Collections;
using UnityEngine;

namespace RimuruDev.Mechanics
{
    public sealed class PipeGeneratorController : MonoBehaviour
    {
        private GameDataContainer dataContainer;

        private void Awake() => dataContainer = IsNullFind<GameDataContainer>.Find(ref dataContainer, this);

        //private void Start() => StartCoroutine(Spawner());

        public IEnumerator Spawner()
        {
            while (dataContainer.isPipeSpawn)
            {
                yield return new WaitForSeconds(dataContainer.pipeSpawnCooldown);
                {
                    var newPipes = Instantiate(dataContainer.pipePrefab, new Vector3(dataContainer.pipeSpawnPosX, RandomY(), 0), Quaternion.identity);

                    Destroy(newPipes, dataContainer.pipeDestroyTimer);
                }
            }
        }

        private float RandomY() =>
            Random.Range(dataContainer.pipeRandomRangeXY.x, dataContainer.pipeRandomRangeXY.y);
    }
}