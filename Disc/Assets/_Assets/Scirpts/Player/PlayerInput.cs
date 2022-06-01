using UnityEngine;
public class PlayerInput : MonoBehaviour {
    [SerializeField] private Joystick joyStick;
    [SerializeField] private bool inputEnable = true,onPc = true;

    private void Start(){
        #if UNITY_EDITOR
            onPc = true;
        #else
            onPc = false;
        #endif
    }
    public float GetSideWaysInput(){
        
        float horizontalAmount = 0f;
        if(inputEnable){
            if(onPc){
                horizontalAmount = Input.GetAxis("Horizontal");
            }else{
                horizontalAmount = joyStick.Horizontal;
            }
        }
        return horizontalAmount;
    }
    public float GetForwardInput(){
        float verticalAmount = 0f;
        if(inputEnable){
            if(onPc){
                verticalAmount = Input.GetAxis("Vertical");
            }else{
                verticalAmount = joyStick.Vertical;
            }
        }
        return verticalAmount;
    }

    public void ToggleInput(bool value){
        inputEnable = value;
    }
    public bool IsInputAvailable(){
        return inputEnable;
    }
    
}
