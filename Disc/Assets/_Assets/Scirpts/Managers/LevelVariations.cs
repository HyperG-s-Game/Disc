using UnityEngine;
using GamerWolf.Utils;
using System.Collections;
using System.Collections.Generic;
public class LevelVariations : MonoBehaviour ,IPooledObject {
    
    [SerializeField] private Transform newObstacleSpawnPoint;
    [SerializeField] private Vector3 offset;
    [ContextMenu("Set Up")]
    public void SetUpNewObstaclePoint(){
        newObstacleSpawnPoint.position = offset;
    }
    public Transform GetNextObstacleSpawnPoint(){
        return newObstacleSpawnPoint;
    }
    public void DestroyMySelfWithDelay(float delay = 1f){
        Invoke(nameof(DestroyNow),delay);    
    }

    public void DestroyNow(){
        CancelInvoke(nameof(DestroyNow));
        gameObject.SetActive(false);
    }

    public void OnObjectReuse(){
        gameObject.SetActive(true);
    }
}
