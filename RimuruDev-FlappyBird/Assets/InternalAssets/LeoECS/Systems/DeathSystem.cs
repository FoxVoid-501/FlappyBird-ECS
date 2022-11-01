using Leopotam.Ecs;
using RimuruDev.Core;
using RimuruDev.Helpers;
using UnityEngine;
using UnityEngine.UI;
using Voody.UniLeo;

namespace RimuruDev.ECS
{
    internal class DeathSystem : IEcsRunSystem
    {
        private readonly EcsFilter<BirdComponent, PerformDeathEvent> deathFilter = null;
        private readonly EcsFilter<Popup> popupFilter = null;

        private readonly EcsFilter<BestScoreCompopent> bestScore = null;
        private readonly EcsFilter<ScoreComponent> score = null;

        private readonly GameDataContainer dataContainer = null;

        public void Run()
        {
            foreach (var i in deathFilter)
            {
                ref var entity = ref deathFilter.GetEntity(i);

                // Удаление всех труб в мире.
                var pipes = GameObject.FindGameObjectsWithTag(Tag.Pipe);
                {
                    foreach (var pipe in pipes)
                        Object.Destroy(pipe, 0.2f);
                }

                // Остановка спавна труб.
                var world = WorldHandler.GetWorld().
                                    GetFilter(typeof(EcsFilter<
                                                               PipeSpawnTag,
                                                               PipeSettingsComponent,
                                                               PipeGenerationComponent>)).
                                    GetEntity(0);
                world.Destroy();

                Object.Destroy(dataContainer.birtClone, 1.5f);
                entity.Destroy();

                // Вызываем Попап проигрыша.
                foreach (var index in popupFilter)
                {
                    ref var popupEntity = ref popupFilter.GetEntity(index);
                    popupEntity.Get<PerformDeathEvent>();
                    popupEntity.Get<PopupTimer>().timer = dataContainer.timePopupSpawn;
                }

                // Сохраняем результат.
                foreach (var scoreIndex in score)
                {
                    Debug.Log("Save result");
                    ref var scoreEntity = ref score.GetEntity(scoreIndex);
                    scoreEntity.Get<TimerForSaveScore>().timer = dataContainer.autoSaveTimer;

                    PlayerPrefs.SetInt("Score", dataContainer.score);

                    Debug.Log("Score= " + PlayerPrefs.GetInt("Score"));
                }

                // Сохраняем лучший результат.
                foreach (var bestScoreIndex in bestScore)
                {
                    Debug.Log("Save best result");
                    ref var bestScoreEntity = ref bestScore.GetEntity(bestScoreIndex);
                    bestScoreEntity.Get<TimerForSaveBestScore>().timer = dataContainer.autoSaveBestScoreTimer;

                    var score = PlayerPrefs.GetInt("Score");
                    var _bestScore = PlayerPrefs.GetInt("BestScore");

                    if (score >= _bestScore)
                        PlayerPrefs.SetInt("BestScore", score);

                    if (_bestScore <= 0)
                        PlayerPrefs.SetInt("BestScore", score);
                    // Show best score;

                    Debug.Log("Score best= " + PlayerPrefs.GetInt("Score"));
                }

                foreach (var item in popupFilter)
                {
                    ref var popup = ref popupFilter.Get1(item);
                    popup.popup.transform.GetChild(0).GetChild(0).GetComponentInChildren<Text>().text = PlayerPrefs.GetInt("Score").ToString();
                    popup.popup.transform.GetChild(0).GetChild(1).GetComponentInChildren<Text>().text = PlayerPrefs.GetInt("BestScore").ToString();
                    Debug.Log("Set text");
                }
            }
        }
    }
}