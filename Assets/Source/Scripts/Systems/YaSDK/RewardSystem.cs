using System.Collections;
using Kuhpik;
using Leopotam.EcsLite;
using Source.Scripts.Components.Events;
using Source.Scripts.Helpers;
using Source.Scripts.SDK;
using Source.Scripts.UI;
using Source.Scripts.YaSDK;
using UnityEngine;

namespace Source.Scripts.Systems.Game
{
    //mb is better to logic in suitable system
    public class RewardSystem : GameSystem
    {
        private EcsFilter filter;
        private Coroutine coroutineReward;
      
        private bool rewardTimerReady;
        
        public override void OnInit()
        {
            base.OnInit();
            filter = eventWorld.Filter<SDKEvent>().End();
            //do - get screen with reward start logic

            coroutineReward = StartCoroutine(RewardCd());
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            //CheckEvent(); --check event or subscribe btn
        }

        private void CheckEvent()
        {
            foreach (var e in filter)
            {
                if (pool.SDKEvent.Get(e).SdkEventType==SdkEventType.REWARD  //is inter event
                    && rewardTimerReady                                     //timer ready
                    && (!game.WantToAskReviewNow))  //there will not be rate us screen
                {
                    OnShowReward();
                }
            }
        }
        

        private void OnShowReward()
        {
            YandexManager.Instance.ShowRewardedAd();
            coroutineReward = StartCoroutine(RewardCd());
        }

        private IEnumerator RewardCd()
        {
            rewardTimerReady = false;
            yield return new WaitForSeconds(sdkConfig.RewardCD);
            rewardTimerReady = true;
        }
    }
}