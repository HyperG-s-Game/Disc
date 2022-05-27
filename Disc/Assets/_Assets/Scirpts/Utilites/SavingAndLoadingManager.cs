using System.IO;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace GamerWolf.Utils{

    public class SavingAndLoadingManager : MonoBehaviour{
        
        [SerializeField] private SaveData saveData;
        public static SavingAndLoadingManager instance {get;private set;}
        
        
        private void Awake(){
            if(instance == null){
                instance = this;
            }else{
                Destroy(instance.gameObject);
            }
            DontDestroyOnLoad(gameObject);
            
            LoadGame();
            

        }
        [ContextMenu("SAVE GAME")]
        public void SaveGame(){
            // saveData.gameData.Save();
            // for (int i = 0; i < saveData.rewardsSos.Length; i++){
            //     saveData.rewardsSos[i].Save();
            // }
            
            
        }
        [ContextMenu("LOAD GAME")]
        public void LoadGame(){
            // saveData.gameData.Load();
            // for (int i = 0; i < saveData.rewardsSos.Length; i++){
            //     saveData.rewardsSos[i].Load();
            // }
        }
        private void OnApplicationPause(bool pause){
            if(pause){
                SaveGame();
            }
        }
        
        private void OnApplicationQuit(){
            SaveGame();
            
        }

    }
    [System.Serializable]
    public struct SaveData{
        // public  GameDataSO gameData;
        // public RewardsSO[] rewardsSos;
        // public LevelDataSO[] levelDatas;
        // public SettingsSO settingsSO;
        
    }

}