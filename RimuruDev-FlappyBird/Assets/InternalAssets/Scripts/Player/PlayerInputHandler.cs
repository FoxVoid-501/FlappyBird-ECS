using UnityEngine;

namespace RimuruDev.Mechanics
{
    public sealed class PlayerInputHandler
    {
        public void FlyUp(ref Rigidbody2D birdRigidbody2D, ref float flyUpForce, bool isDebug = false)
        {
            if (isDebug)
                if (birdRigidbody2D.velocity == Vector2.zero) { Debug.LogError($"Rigidbody2D.velocity is null. [{birdRigidbody2D.velocity}]"); }

            birdRigidbody2D.velocity = Vector2.up * flyUpForce;
        }

        public void FlyUp(ref Rigidbody2D birdRigidbody2D, ref float flyUpForce) =>
            birdRigidbody2D.velocity = Vector2.up * flyUpForce;
    }
}