using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float TimeLeft;

    public BridgeConnection[] Bridges;

    public ConnectionInputJuicer ConnectionIJ;
    public ScreenJuicer ScreenJ;
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

        if (Input.GetKeyDown(KeyCode.A))
        {
            ConnectionIJ.StartJuicing(BridgeConnectionType.Blue, Bridges[_currentBridgeIndex].GetCurrentConnectionPosition());
            PlayPiece(BridgeConnectionType.Blue);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            ConnectionIJ.StartJuicing(BridgeConnectionType.Green, Bridges[_currentBridgeIndex].GetCurrentConnectionPosition());
            PlayPiece(BridgeConnectionType.Green);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            ConnectionIJ.StartJuicing(BridgeConnectionType.Red, Bridges[_currentBridgeIndex].GetCurrentConnectionPosition());
            PlayPiece(BridgeConnectionType.Red);
        }

        if(Input.GetKeyDown(KeyCode.Space)){
            ConnectionIJ.StartJuicing(BridgeConnectionType.Red, Bridges[_currentBridgeIndex].GetCurrentConnectionPosition());
        }
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
