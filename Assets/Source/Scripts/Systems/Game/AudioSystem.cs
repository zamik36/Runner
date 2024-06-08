using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using Kuhpik;
using Leopotam.EcsLite;
using Source.Scripts.Components.Events;
using Source.Scripts.Data;
using UnityEngine;


namespace Source.Scripts.Systems.Game
{
    public class AudioSystem : GameSystem
    {
        [SerializeField] private AudioSource music;
        [SerializeField] private AudioSource sound;

        [SerializedDictionary()] private Dictionary<SoundType, AudioClip> clips;

        private EcsFilter filter;

        public override void OnInit()
        {
            base.OnInit();
            filter = eventWorld.Filter<SoundEvent>().End();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            foreach (var e in filter)
            {
                var soundEvent = pool.SoundEvent.Get(e);

                var source = soundEvent.IsMusic ? music : sound;
                source.clip = clips[soundEvent.SoundType];
                source.Play();
            }
        }
    }
}