using Leopotam.Ecs;
using RimuruDev.Core;
using RimuruDev.ECS;
using RimuruDev.Helpers;
using UnityEngine;
using Voody.UniLeo;

public class DoingHarmTrigger : MonoBehaviour
{
    private int damage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag(Tag.Player)) return;

        //collision.gameObject.GetComponent<Health>().ApplayDaamge(damage);

        ref var birdEntity = ref WorldHandler.GetWorld().GetFilter(typeof(EcsFilter<BirdComponent>)).GetEntity(0);

        birdEntity.Get<PerformDeathEvent>();

        //PerformDeathEvent;
    }
}