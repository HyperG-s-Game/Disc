using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LeveDistroyer : MonoBehaviour {
    
    [SerializeField] private LevelVariations varitions;
    private void OnTriggerEnter(Collider coli){
        if(coli.GetComponent<PlayerCollision>() != null){
            varitions.DestroyNow();
        }
    }
}
