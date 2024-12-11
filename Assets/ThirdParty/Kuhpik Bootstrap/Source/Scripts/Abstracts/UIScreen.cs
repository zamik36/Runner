using NaughtyAttributes;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Kuhpik
{
    public class UIScreen : MonoBehaviour, IUIScreen
    {
        [SerializeField] [BoxGroup("Settings")] bool shouldOpenWithState;
        [SerializeField] [BoxGroup("Settings")] [ShowIf("shouldOpenWithState")] GameStateID[] statesToOpenWith;

        //You will get the idea once you use it
        [SerializeField] [BoxGroup("Elements")] bool hideElementsOnOpen;
        [SerializeField] [BoxGroup("Elements")] bool showElementsOnHide;

        [SerializeField] [BoxGroup("Elements")] [ShowIf("hideElementsOnOpen")] GameObject[] elementsToHideOnOpen;
        [SerializeField] [BoxGroup("Elements")] [ShowIf("showElementsOnHide")] GameObject[] elementsToShowOnHide;

        HashSet<GameStateID> statesMap;
        protected UIConfig config;
        

        public void Init(UIConfig config)
        {
            this.config = config;
            statesMap = new HashSet<GameStateID>(statesToOpenWith);
        }

        public virtual void Open()
        {
            foreach (var element in elementsToHideOnOpen)
            {
                element.SetActive(false);
            }

            gameObject.SetActive(true);
        }

        public virtual void Close()
        {
            foreach (var element in elementsToShowOnHide)
            {
                element.SetActive(true);
            }

            gameObject.SetActive(false);
        }

        /// <summary>
        /// Subscribe is called on Awake()
        /// </summary>
        public virtual void Subscribe()
        {
        }

        internal void TryOpenWithState(GameStateID id)
        {
            if (shouldOpenWithState && statesMap.Contains(id))
            {
                Open();
            }
        }
        
#if UNITY_EDITOR
       
        private void OnValidate()
        {
            var n = (GetType().ToString());
            var split = n.Split('.').ToList();
            n = split[split.Count-1];
            n = System.Text.RegularExpressions.Regex.Replace(n, "[A-Z]", " $0");
            gameObject.name = n;
        }
#endif
    }
}