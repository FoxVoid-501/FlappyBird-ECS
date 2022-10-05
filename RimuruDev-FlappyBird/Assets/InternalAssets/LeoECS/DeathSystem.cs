using Leopotam.Ecs;
using RimuruDev.Core;
using RimuruDev.Helpers;
using UnityEngine;
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
                    ref var scoreEntity = ref score.GetEntity(scoreIndex);
                    scoreEntity.Get<TimerForSaveScore>().timer = dataContainer.autoSaveTimer;
                }

                // Сохраняем лучший результат.
                foreach (var bestScoreIndex in bestScore)
                {
                    ref var bestScoreEntity = ref bestScore.GetEntity(bestScoreIndex);
                    bestScoreEntity.Get<TimerForSaveBestScore>().timer = dataContainer.autoSaveBestScoreTimer;
                }
            }
        }
    }

    internal struct PerformDeathEvent { };
}