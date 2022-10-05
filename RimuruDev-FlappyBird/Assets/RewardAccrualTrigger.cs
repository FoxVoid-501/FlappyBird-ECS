using RimuruDev.Helpers;
using UnityEngine;

namespace RimuruDev.ECS
{
    public sealed class RewardAccrualTrigger : MonoBehaviour
    {
        private int reward = 1;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.gameObject.CompareTag(Tag.Player)) return;

            EventHandler.RewardAccrual(ref reward); // TODO: Magic number.

            Destroy(this.gameObject.GetComponent<BoxCollider2D>());
        }
    }
}