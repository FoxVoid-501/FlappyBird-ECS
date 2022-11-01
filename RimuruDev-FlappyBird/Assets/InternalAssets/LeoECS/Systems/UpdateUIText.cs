using Leopotam.Ecs;
using RimuruDev.Core;

namespace RimuruDev.ECS
{
    internal class UpdateUIText : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsWorld ecsWorld = null;
        private readonly EcsFilter<UI, ScoreText> uiFilter = null;
        private readonly GameDataContainer dataContainer = null;

        public void Init()
        {
            var entity = ecsWorld.NewEntity();

            entity.Get<UI>();
            entity.Get<ScoreText>().scoreText = dataContainer.scoreText;
        }

        public void Run()
        {
            foreach (var i in uiFilter)
            {
                ref var scoreText = ref uiFilter.Get2(i).scoreText;

                scoreText.text = dataContainer.score.ToString();
            }
        }
    }
}