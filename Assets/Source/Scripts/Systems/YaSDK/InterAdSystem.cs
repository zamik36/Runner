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
    public class InterAdSystem : GameSystem
    {
        private EcsFilter filter;
        private InterAdUIScreen interAdUIScreen;
      
        private Coroutine coroutineInter;
        private bool interTimerReady;
        
        public override void OnInit()
        {
            base.OnInit();
            filter = eventWorld.Filter<SDKEvent>().End();
            interAdUIScreen = FindObjectOfType<InterAdUIScreen>(true);
            
            YandexManager.Instance.InterClosedEvent += OnInterClosed;

            coroutineInter = StartCoroutine(InterCd());
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            foreach (var e in filter)
            {
                if (pool.SDKEvent.Get(e).SdkEventType==SdkEventType.INTER  //is inter event
                    && interTimerReady                                     //timer ready
                    && (!game.WantToAskReviewNow))  //there will not be rate us screen
                {
                    ShowInter();
                }
            }
        }

        private void ShowInter()
        {
            if (sdkConfig.AnimateInterCountdown)
                StartCoroutine(CountdownAnimation());
            else
                YandexManager.Instance.ShowInter();
        }

        private IEnumerator CountdownAnimation()
        {
            interAdUIScreen.Open();
            interAdUIScreen.AnimateCountDots(2f); //2f is required by sdk!
            yield return new WaitForSeconds(2f);
            interAdUIScreen.Close();
            YandexManager.Instance.ShowInter();
        }

        private void OnInterClosed()
        {
            coroutineInter = StartCoroutine(InterCd());
        }

        private IEnumerator InterCd()
        {
            interTimerReady = false;
            yield return new WaitForSeconds(sdkConfig.InterCD);
            interTimerReady = true;
        }
        
    }
}