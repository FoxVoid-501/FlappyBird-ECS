using Leopotam.Ecs;
using Leopotam;
using Leopotam.Ecs;
using RimuruDev.Core;
using UnityEngine;
using Voody.UniLeo;
using RimuruDev.Core;
using RimuruDev.Helpers;
using RimuruDev.Mechanics;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RimuruDev.ECS;

public class Health : MonoBehaviour
{
    public int health = 1;

    private GameDataContainer dataContainer;

    private void Awake()
    {
        dataContainer = IsNullFind<GameDataContainer>.Find(ref dataContainer, this);
    }

    internal void ApplayDaamge(int damage)
    {
        //if (health < 0) { Debug.LogWarning("Player is dead"); health = 0; return; }

        //if (health > 0) health -= damage;

        //if (health == 0) //ApplayDead();
    }

    //private void ApplayDead()
    //{
    //    var pipes = GameObject.FindGameObjectsWithTag(Tag.Pipe);

    //    foreach (var pipe in pipes)
    //        Destroy(pipe, 0.2f);

    //    Destroy(dataContainer.birtClone, 0.5f);

    //    dataContainer.isPipeSpawn = false;
    //    {
    //        var world = WorldHandler.GetWorld().
    //                                 GetFilter(typeof(EcsFilter<
    //                                                            PipeSpawnTag,
    //                                                            PipeSettingsComponent,
    //                                                            PipeGenerationComponent>)).
    //                                 GetEntity(0);
    //        world.Destroy();
    //        //GameDataContainer.eventontainer.failurePanel.SetActive(true);
    //        //var entity = WorldHandler.GetWorld().NewEntity();

    //        //ref var popup = ref entity.Get<Popup>().popup;

    //        //popup = ref dataContainer.failurePanel;

    //        //var _world = WorldHandler.GetWorld().
    //        //                        GetFilter(typeof(EcsFilter<Popup>)).GetEntity(0);
    //        // EcsFilter<Popup> s = null;

    //        //foreach (var j in s)
    //        //{
    //        //    ref var _popup = ref s.Get1(j);

    //        //    _popup.popup.SetActive(true);
    //        //}
    //        //WorldHandler.Destroy();
    //    }

    //    //dataContainer.failurePanel.SetActive(true);

    //    //Destroy(GameObject.FindGameObjectWithTag(Tag.Player), 0.5f);

    //    //var pipes = GameObject.FindGameObjectsWithTag(Tag.Pipe);

    //    //foreach (var pipe in pipes)
    //    //    Destroy(pipe, 0.2f);

    //    //dataContainer.birdRigidbody2DClone = null;
    //    //dataContainer.birtClone = null;

    //    //dataContainer.failurePanel.SetActive(true);
    //}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (!collision.gameObject.CompareTag(Tag.Pipe)) return;

    //    dataContainer.birdCharacterController.enabled = false;
    //    dataContainer.pipeGeneratorController.StopAllCoroutines();

    //    var pipes = GameObject.FindGameObjectsWithTag(Tag.Pipe);

    //    foreach (var pipe in pipes)
    //        Destroy(pipe, 0.2f);

    //    Destroy(GameObject.FindGameObjectWithTag(Tag.Player), 0.5f);
    //    dataContainer.birdRigidbody2DClone = null;
    //    dataContainer.birtClone = null;

    //    dataContainer.failurePanel.SetActive(true);
    //}
}
