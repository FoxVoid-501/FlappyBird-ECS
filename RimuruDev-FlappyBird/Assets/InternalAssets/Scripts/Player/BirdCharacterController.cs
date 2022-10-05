using RimuruDev.Core;
using RimuruDev.Helpers;
using UnityEngine;

namespace RimuruDev.Mechanics
{
    public sealed class BirdCharacterController : MonoBehaviour
    {
        private GameDataContainer dataContainer;
        private PlayerInputHandler inputHandler;

        private void Awake() => Init();

        private void Update()
        {
            if (!Input.GetMouseButtonDown(0)) return;

            inputHandler.FlyUp(ref dataContainer.birdRigidbody, ref dataContainer.flyUpForce);
        }

        private void Init()
        {
            inputHandler = new PlayerInputHandler();

            dataContainer = IsNullFind<GameDataContainer>.Find(ref dataContainer, this);
        }
    }
}