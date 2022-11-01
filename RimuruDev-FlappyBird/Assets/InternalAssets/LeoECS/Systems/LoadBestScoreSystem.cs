using Leopotam.Ecs;
using RimuruDev.Core;
using UnityEngine;

namespace RimuruDev.ECS
{
    internal class LoadBestScoreSystem : IEcsInitSystem
    {
        private readonly GameDataContainer dataContainer = null;
        private readonly EcsWorld world = null;

        // Wtf? This i programmed? Shit!
        public void Init()
        {
            var entity = world.NewEntity();
            ref var bestScore = ref entity.Get<BestScoreCompopent>();

            if (PlayerPrefs.GetInt("BestScore") <= 0)
                PlayerPrefs.SetInt("BestScore", 0);
           /* else if (PlayerPrefs.GetInt("BestScore") > 0)
            {
                bestScore.bestScore = PlayerPrefs.GetInt("BestScore");
                dataContainer.bestScore = bestScore.bestScore;
            }*/
        }
    }
}