using System;
using UnityEngine;
using GamerWolf.Utils;
using System.Collections;
using System.Collections.Generic;
public class LevelManager : MonoBehaviour {
    
    [SerializeField] private Transform startingPoint;
    [SerializeField] private List<string> levelVariationNameList;
    private ObjectPoolingManager poolingManager;
    private LevelVariations currentLevelVariations;

    [SerializeField] private int crossedLevelVariation;
    public Action OnSpawningNewSection;

    public static LevelManager current;

    private void Awake(){
        current = this;
    }
    private void Start(){
        poolingManager = ObjectPoolingManager.current;
        OnSpawningNewSection += ()=>{
            crossedLevelVariation = 0;
            SpawnMoreLevel();
        };
        Invoke(nameof(Spawn),0.1f);

    }

    public void Spawn(){
        if(currentLevelVariations == null){
            GameObject Clone = poolingManager.SpawnFromPool("Level1",startingPoint.position,startingPoint.rotation);
            if(Clone.TryGetComponent<LevelVariations>(out LevelVariations newVar)){
                currentLevelVariations = newVar;
            }

        }
        LevelLoader.showLevel = true;;
        Invoke(nameof(SpawnMoreLevel),0.1f);
        
    }
    private void SpawnMoreLevel(){
        for (int i = 0; i < 10; i++){
            int rand = UnityEngine.Random.Range(0,levelVariationNameList.Count);
            GameObject Clone = poolingManager.SpawnFromPool(levelVariationNameList[rand],currentLevelVariations.GetNextObstacleSpawnPoint().position,currentLevelVariations.GetNextObstacleSpawnPoint().rotation);
            if(Clone.TryGetComponent<LevelVariations>(out LevelVariations newVar)){
                currentLevelVariations = newVar;
            }   
        }
    }
    public void InvokeSpawnNewSection(){
        crossedLevelVariation++;
        if(crossedLevelVariation > 5){
            OnSpawningNewSection?.Invoke();
        }
    }
    
}
