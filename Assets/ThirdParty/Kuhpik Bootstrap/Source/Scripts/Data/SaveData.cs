using System;
using System.Collections;
using System.Collections.Generic;
using Source.Scripts.Data;
using Source.Scripts.YaSDK;

namespace Kuhpik
{
    /// <summary>
    /// Used to store player's data. Change it the way you want.
    /// </summary>
    [Serializable]
    public class SaveData
    {
        //sdk
        public PlayerSDKData PlayerSDKData=new PlayerSDKData();
        
        //settings
        public bool MusicOn = true;
        public bool SoundOn = true;
        public LangType LangType;
        
        //tutor
        public TutorStepType CurrentTutorStepType;
       
        //data
    }
}