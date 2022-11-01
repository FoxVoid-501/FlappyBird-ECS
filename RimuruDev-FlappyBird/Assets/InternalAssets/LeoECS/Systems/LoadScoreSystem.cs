using Leopotam.Ecs;
using RimuruDev.Core;
using UnityEngine;

namespace RimuruDev.ECS
{
    internal class LoadScoreSystem : IEcsInitSystem
    {
        private readonly EcsWorld world = null;
        private readonly GameDataContainer dataContainer = null;

        // Wtf? This i programmed?
        public void Init()
        {
            var entity = world.NewEntity();
            ref var score = ref entity.Get<ScoreComponent>().score;

            if (PlayerPrefs.GetInt("Score") <= 0)
                PlayerPrefs.SetInt("Score", score);
            /*else if (PlayerPrefs.GetInt("Score") > 0) 
            {
                score = PlayerPrefs.GetInt("Score");
                dataContainer.score = score;
            }*/
        }
    }
}
