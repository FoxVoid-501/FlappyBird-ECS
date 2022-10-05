using RimuruDev.Core;
using RimuruDev.Helpers;
using UnityEngine;

namespace RimuruDev.UI
{
    public sealed class UIController : MonoBehaviour
    {
        private GameDataContainer dataContainer;

        private void Awake()
        {
            dataContainer = IsNullFind<GameDataContainer>.Find(ref dataContainer, this);
        }

        private void Update()
        {
            dataContainer.scoreText.text = $"{dataContainer.score}";

            if (dataContainer.failurePanel.activeInHierarchy == true)
            {
                dataContainer.scoreTextFailurepanel.text = $"{dataContainer.score}";
                dataContainer.bestScoreFailurepanel.text = $"{dataContainer.score}";
            }
        }
    }
}