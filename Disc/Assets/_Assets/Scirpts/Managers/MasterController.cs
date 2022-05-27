using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class MasterController : MonoBehaviour {
    
   [SerializeField] private UnityEvent OnGameStart;
   [SerializeField] private UnityEvent OnGamePlaying,OnGameEnd;

    [SerializeField] private bool isGamePlaying;


    public static MasterController current;
    private void Awake(){
        current = this;
    }

    private void Start(){
        StartCoroutine(GameStartRoutine());
    }
    private IEnumerator GameStartRoutine(){
        OnGameStart?.Invoke();
        while(!isGamePlaying){
            yield return null;
        }
        yield return StartCoroutine(GamePlayingRoutine());
    }
    private IEnumerator GamePlayingRoutine(){
        OnGamePlaying?.Invoke();
        while(isGamePlaying){
            yield return null;
        }
        OnGameEnd?.Invoke();
    }
    public void GameStart(){
        isGamePlaying = true;
    }
    public void SetGameOver(){
        isGamePlaying = false;
    }
}
