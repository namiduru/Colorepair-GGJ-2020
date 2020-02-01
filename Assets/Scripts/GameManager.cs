using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float TimeLeft;

    public BridgeConnection[] Bridges;
    public ScreenJuicer ScreenJ;
    public SpinnerJuicer SpinnerJuicer;
    private int _currentBridgeIndex;

    private bool _gameLoopActive;

    private void Awake(){
        TimeLeft = 30f;

        _gameLoopActive = true;
    }

    private void Update(){
        if(!_gameLoopActive)
            return;

        if(TimeLeft <= 0f){
            LoseGame();
        }else{
            TimeLeft -= Time.deltaTime;
        }
    }

    public void PlayGreen(){
        SpinnerJuicer.StartJuicing(BridgeConnectionType.Green, Bridges[_currentBridgeIndex].GetCurrentConnectionPosition());
        PlayPiece(BridgeConnectionType.Green);
    }

    public void PlayBlue(){
        SpinnerJuicer.StartJuicing(BridgeConnectionType.Blue, Bridges[_currentBridgeIndex].GetCurrentConnectionPosition());
        PlayPiece(BridgeConnectionType.Blue);
    }

    public void PlayRed(){
        SpinnerJuicer.StartJuicing(BridgeConnectionType.Red, Bridges[_currentBridgeIndex].GetCurrentConnectionPosition());
        PlayPiece(BridgeConnectionType.Red);
    }
    public void PlayPiece(BridgeConnectionType p_type){
        bool result = Bridges[_currentBridgeIndex].Play(p_type);

        if (result)
        {
            Bridges[_currentBridgeIndex].RebuildConnection();
            ScreenJ.ScreenZoomOut();
            Debug.Log("Correct");
        }
        else
        {
            Debug.Log("Incorrect");
        }

        if(Bridges[_currentBridgeIndex].IsComplete()){
            Debug.Log("Bridge Complete");
            GoToNextBridge();
        }
    }

    public void GoToNextBridge(){
        _currentBridgeIndex++;

        if(_currentBridgeIndex == Bridges.Length){
            WinGame();
        }
    }

    public void AddGameTime(float p_amount){
        TimeLeft += p_amount;
    }

    private void LoseGame(){
        Debug.Log("Game Lost");
        _gameLoopActive = false;
    }

    private void WinGame(){
        Debug.Log("GameComplete");
        _gameLoopActive = false;
    }
}
