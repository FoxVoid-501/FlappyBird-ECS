using Leopotam.Ecs;
using RimuruDev.Core;
using UnityEngine;

namespace RimuruDev.ECS
{
    internal class SaveScoreSystem : IEcsRunSystem
    {
        private readonly GameDataContainer dataContainer = null;

        private readonly EcsFilter<ScoreComponent>.
                         Exclude<TimerForSaveScore> saveScoreFilter = null;

        public void Run()
        {/*
            foreach (var i in saveScoreFilter)
            {
                ref var score = ref saveScoreFilter.Get1(i).score;
                ref var timer = ref saveScoreFilter.GetEntity(i).Get<TimerForSaveScore>().timer;

                score = ref dataContainer.score;
                timer = dataContainer.autoSaveTimer;
                PlayerPrefs.SetInt("Score", score);

                //Debug.Log("Oveeeeeeer save");

             
            }*/
        }
    }
}