using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerGraphicsBody : MonoBehaviour {
    [SerializeField] private float rotaionSmoothTime;
    [SerializeField] private Transform rotationBody;
    
    public void Rotate(float speed){
        rotationBody.Rotate(Vector3.up * speed * Time.deltaTime);
    }
    public void TiltBody(float _roll){
        // float _roll = Mathf.Lerp(0,30,Mathf.Abs(inputAmount) * -Mathf.Sign(inputAmount));
        Quaternion smoothRot = Quaternion.Slerp(transform.localRotation,Quaternion.Euler(Vector3.forward * _roll),rotaionSmoothTime * Time.deltaTime);
        transform.localRotation = smoothRot;
    }
}
