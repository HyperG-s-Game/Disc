using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerCollision : MonoBehaviour {

    // [SerializeField] private float checkRadius;

    // [SerializeField] private LayerMask checkMask;
    // [SerializeField] private Vector3 m_colliderSize;
    // private void Update(){
    //     if(Physics.CheckSphere(transform.position,checkRadius,checkMask,QueryTriggerInteraction.Ignore)){
    //         // MasterController.current.SetGameOver();
    //     }
    // }
    private void OnCollisionEnter(Collision coli){
        MasterController.current.SetGameOver();
    }
    // private void OnDrawGizmosSelected(){
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawWireSphere(transform.position,checkRadius);
        
    // }
}
