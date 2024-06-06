﻿using System.Collections.Generic;
using Kuhpik;
using Leopotam.EcsLite;

namespace Source.Scripts.Systems.EcsUtil
{
    public class DestroyEventSystem : GameSystem
    {
        private Dictionary<EcsFilter,IEcsPool> filtersPools;

        public override void OnInit()
        {
            base.OnInit(); 
            
            filtersPools = new ();
            //AddFilter<DamageEvent>();
          
        }

        private void AddFilter<T>() where T: struct
        {
            filtersPools.Add(eventWorld.Filter<T>().End(),eventWorld.GetPool<T>());
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            foreach (var filter in filtersPools.Keys)
            {
                foreach (var ent in filter)
                {
                    filtersPools[filter].Del(ent);
                }
            }
           

        }
    }
}