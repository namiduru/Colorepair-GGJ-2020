using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerJuicer : MonoBehaviour
{
    public AnimationCurve TapJuiceCurve;
    public float TapJuiceTime;
    public float TapJuiceScale;

    private bool _tapJuicing;

    private ConnectionInputJuicer _inputJuicer;

    private void Awake(){
        _inputJuicer = GetComponent<ConnectionInputJuicer>();
    }

    private void StartJuicing(BridgeConnectionType p_type, Vector3 p_targetPosition){
        StartCoroutine(TapJuice());
        _inputJuicer.StartJuicing(p_type, p_targetPosition);
    }

    private IEnumerator TapJuice(){
        float timer = TapJuiceTime;
        float maxTimer = timer;

        Vector3 startScale = transform.localScale;
        Vector3 targetScale = transform.localScale;

        _tapJuicing = true;

        while(timer > 0f){

            targetScale = startScale + Vector3.one * TapJuiceCurve.Evaluate(1 - timer / maxTimer) * TapJuiceScale;
            transform.localScale = Vector3.Lerp(startScale, targetScale, 1 - timer / maxTimer);

            timer -= Time.deltaTime;

            yield return null;
        }

        transform.localScale = startScale;

        _tapJuicing = false;

        yield return null;
    }
}
