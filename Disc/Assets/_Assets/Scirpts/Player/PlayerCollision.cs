using UnityEngine;
using GamerWolf.Utils;
using System.Collections;
using System.Collections.Generic;
public class PlayerCollision : MonoBehaviour {

    private PlayerController playerController;
    private void Start(){
        playerController = GetComponent<PlayerController>();
    }
    private void OnCollisionEnter(Collision coli){
        if(MasterController.current.isGamePlaying){
            ObjectPoolingManager.current.SpawnFromPool("Explosion Effect",coli.GetContact(0).point,Quaternion.FromToRotation(Vector3.up,coli.GetContact(0).normal));
            CinemachineScreenShakeManager.current.Shake();
            playerController.OnCollide(-coli.GetContact(0).normal);
            MasterController.current.SetGameOver();
            if(AudioManager.current != null){
                AudioManager.current.PlayOneShotMusic(SoundType.distructionSound1);
            }
        }
    }
}
