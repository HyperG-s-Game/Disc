using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {
    
    [SerializeField] private float moveSpeed;
    [SerializeField] private float yawAmount;
    private float _yaw,horizontalInput;
    private Rigidbody rb;
    private void Awake(){
        rb = GetComponent<Rigidbody>();
    }
    private void Update(){
        horizontalInput = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        _yaw += horizontalInput * yawAmount * Time.deltaTime;
        float _pitch = Mathf.Lerp(0,20,Mathf.Abs(vertical)) * -Mathf.Sign(vertical);
        float _roll = Mathf.Lerp(0,30,Mathf.Abs(horizontalInput)) * -Mathf.Sign(horizontalInput);
        
        transform.localRotation = Quaternion.Euler(Vector3.right * _pitch + Vector3.forward * _roll);
        
    }
    private void FixedUpdate(){
        Vector3 moveDir = transform.forward * moveSpeed + transform.right * yawAmount * horizontalInput;
        // transform.position += moveDir * Time.deltaTime;
        rb.MovePosition(rb.position + moveDir * Time.fixedDeltaTime);
    }
}
