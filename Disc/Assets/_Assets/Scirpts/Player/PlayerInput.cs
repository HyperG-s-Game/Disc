using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlayerInput : MonoBehaviour {
    
    [SerializeField] private bool InputEnable,onPc;
    



    
    public float GetSideWaysInput(){
        
        float horizontalAmount = 0f;
        if(InputEnable){
            if(onPc){
                horizontalAmount = Input.GetAxis("Horizontal");
            }else{
                if(Input.touchCount > 0){
                    Touch touch = Input.GetTouch(0);
                    if(touch.phase == TouchPhase.Moved){
                        horizontalAmount = touch.deltaPosition.x;
                    }
                }
            }
        }
        return horizontalAmount;
    }
    public float GetForwardInput(){
        float verticalAmount = 0f;
        if(InputEnable){
            if(onPc){
                verticalAmount = Input.GetAxis("Vertical");
            }else{
                if(Input.touchCount > 0){
                    Touch touch = Input.GetTouch(0);
                    if(touch.phase == TouchPhase.Moved){
                        verticalAmount = touch.deltaPosition.y;
                    }
                }
            }
        }
        return verticalAmount;
    }

    public void ToggleInput(bool value){
        InputEnable = value;
    }
    public bool IsInputAvailable(){
        return InputEnable;
    }
    
}
