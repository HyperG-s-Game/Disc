using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerGraphicsBody : MonoBehaviour {
    
    
    public void TiltBody(float _roll){
        // float _roll = Mathf.Lerp(0,30,Mathf.Abs(inputAmount) * -Mathf.Sign(inputAmount));
        transform.localRotation = Quaternion.Euler(Vector3.forward * _roll);
    }
}
