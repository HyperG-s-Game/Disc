using UnityEngine;
using GamerWolf.Utils;
using System.Collections;
using System.Collections.Generic;
[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour {
    
    [SerializeField] private float moveSpeed,idleRotation,movingRotation;
    [SerializeField] private float yawAmount;


    [SerializeField] private PlayerGraphicsBody body;
    private float _yaw,horizontalInput;
    private Rigidbody rb;
    private PlayerInput playerInputs;
    private void Awake(){
        rb = GetComponent<Rigidbody>();
        playerInputs = GetComponent<PlayerInput>();
    }
    private void Start(){
        if(AudioManager.current != null){
            AudioManager.current.PlayMusic(SoundType.BGM);
        }
    }
    private void Update(){
        if(playerInputs.IsInputAvailable()){
            horizontalInput = playerInputs.GetSideWaysInput();
            float vertical = playerInputs.GetForwardInput();
            _yaw += horizontalInput * yawAmount * Time.deltaTime;
            float _pitch = Mathf.Lerp(0,20,Mathf.Abs(vertical)) * -Mathf.Sign(vertical);
            float _roll = Mathf.Lerp(0,30,Mathf.Abs(horizontalInput)) * -Mathf.Sign(horizontalInput);
            body.TiltBody(_roll);
            body.Rotate(movingRotation);
            transform.localRotation = Quaternion.Euler(Vector3.right * _pitch);
        }else{
            body.Rotate(idleRotation);
        }
        
    }
    private void FixedUpdate(){
        if(playerInputs.IsInputAvailable()){
            Vector3 moveDir = transform.forward * moveSpeed + transform.right * yawAmount * horizontalInput;
            rb.MovePosition(rb.position + moveDir * Time.fixedDeltaTime);
        }
    }
    public void OnCollide(Vector3 hitDir){
        idleRotation = 0;
        body.transform.rotation = Quaternion.Euler(Vector3.zero);
        rb.freezeRotation = false;
        rb.useGravity = true;
        rb.AddForce(hitDir * 20f,ForceMode.Impulse);
        rb.AddTorque(Vector3.Cross(Vector3.forward ,hitDir) * 5f,ForceMode.Impulse);
    }
    
}
