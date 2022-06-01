using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class UIManager : MonoBehaviour {
    
    [SerializeField] private TextMeshProUGUI[] currentDistacnceTextsArray,highScoreDistanceTexts;
    [SerializeField] private TextMeshProUGUI speedText;

    [SerializeField] private GameDataSO gameDataSO;
    [Header("Settings ")]
    [SerializeField] private Sprite onSprite;
    [SerializeField] private Sprite offSprite;
    [SerializeField] private TextMeshProUGUI soundViewText,musicViewText;
    [SerializeField] private Button soundButton,musicButton;
    
    public static UIManager current;
    private void Awake(){

        current = this;
    }
    private void Start(){
        
        CheckAudioStatus();
    }
    public void SetcurrentDistance(float currentDistance){
        foreach(TextMeshProUGUI texts in currentDistacnceTextsArray){
            texts.SetText(string.Concat(currentDistance.ToString("0"),"m"));
        }
    }
    public void SetLongestDistance(){
        foreach(TextMeshProUGUI texts in highScoreDistanceTexts){
            texts.SetText(string.Concat(gameDataSO.GetLongestDistance().ToString("0"),"m"));
        }
    }
    public void SetSpeed(float currentSpeed){
        speedText.SetText(string.Concat(currentSpeed.ToString("F2"),"Km/s"));
    }
    public void ToggleMusic(){
        gameDataSO.ToggelMusic();
        CheckAudioStatus();
    }
    public void ToggleSound(){
        gameDataSO.ToggelSound();
        CheckAudioStatus();
    }
    private void CheckAudioStatus(){
        if(gameDataSO.GetMusicState()){
            musicButton.image.sprite = onSprite;
            musicViewText.SetText("ON");
        }else{
            musicButton.image.sprite = offSprite;
            musicViewText.SetText("OFF");
        }

        if(gameDataSO.GetSoundState()){
            soundButton.image.sprite = onSprite;
            soundViewText.SetText("ON");
        }else{
            soundButton.image.sprite = offSprite;
            soundViewText.SetText("OFF");
        }
        

    }
   
}
