using RimuruDev.Core;
using RimuruDev.Helpers;
using UnityEngine;

namespace RimuruDev.Mechanics
{
    public sealed class PipeController : MonoBehaviour
    {
      //  private GameDataContainer dataContainer;
      //  private PipeMotionController pipeMotionController;

        private void Awake() => Init();

        //private void Update()
        //{
        //    if (!dataContainer.isPipeSpawn) return;

        //    pipeMotionController.MotionLeft(ref dataContainer.pipePrefab, ref dataContainer.pipeMotionSpeed);
        //}

        private void Init()
        {
           // pipeMotionController = new PipeMotionController();
          //  dataContainer = IsNullFind<GameDataContainer>.Find(ref dataContainer, this);
        }
    }
}