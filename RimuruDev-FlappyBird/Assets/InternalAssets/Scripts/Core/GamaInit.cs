using RimuruDev.Helpers;
using UnityEngine;

namespace RimuruDev.Core
{
    public sealed class GamaInit : MonoBehaviour
    {
        private GameDataContainer dataContainer;

        private void Awake()
        {
            dataContainer = IsNullFind<GameDataContainer>.Find(ref dataContainer, this);
        }

        private void Start()
        {
            Init();
        }

        public void Init()
        {

            dataContainer.failurePanel.SetActive(false);

            BirdReSpawn();

            CleansingWorldFromPipes();

            dataContainer.score = 0;

            dataContainer.birdRigidbody = dataContainer.birtClone.GetComponent<Rigidbody2D>();
            dataContainer.birdRigidbody2DClone = dataContainer.birdRigidbody;

            dataContainer.birdCharacterController.enabled = true;
            dataContainer.pipeGeneratorController.StartCoroutine(dataContainer.pipeGeneratorController.Spawner());
        }

        private static void CleansingWorldFromPipes()
        {
            var pipes = GameObject.FindGameObjectsWithTag(Tag.Pipe);

            foreach (var pipe in pipes)
                Destroy(pipe);
        }

        private void BirdReSpawn()
        {
            if (dataContainer.birtClone != null)
                Destroy(dataContainer.birtClone);

            if (dataContainer.birtClone == null)
                dataContainer.birtClone = Instantiate(dataContainer.birdPrefab, dataContainer.birdSpawnPosition, Quaternion.identity); ;
        }
    }
}