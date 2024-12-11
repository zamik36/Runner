using System;
using UnityEngine;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using Leopotam.EcsLite;
using Source.Scripts.EcsUtil;
using Source.Scripts.Helpers;

namespace Kuhpik
{
    /// <summary>
    /// Used to store game data. Change it the way you want.
    /// </summary>
    [Serializable]
    public class GameData
    {
        //leo ecs
        public EcsWorld World;
        public EcsWorld EventWorld;
        public Fabric Fabric;
        public Pools Pools;
        public int PlayerEntity;

        //sdk data
        public bool WantToAskReviewNow;
        public bool HasAskedReviewInSession;

        //managers
        public CameraSwitcher CameraSwitcher;
        public AnimManager AnimManager;
    }
}