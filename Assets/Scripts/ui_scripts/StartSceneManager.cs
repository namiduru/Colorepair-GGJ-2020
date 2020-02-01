using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceneManager : MonoBehaviour
{

    private bool isUpward = true;
    private bool isAnimationStarted = false;


    void Update() {
        if (isAnimationStarted) {
            if (isUpward) {
                transform.position = new Vector2(transform.position.x, transform.position.y + 2);
                if (transform.position.y > 100) {
                    isUpward = false;
                }
            } else {
                transform.position = new Vector2(transform.position.x, transform.position.y - 2);
                if (transform.position.y < 60) {
                    isUpward = true;
                }
            }
        }
    }

    public void LoadNextScene() {
        this.disableButtonInteraction();
        StartCoroutine(animatePlayButton());
    }

    private IEnumerator animatePlayButton() {
        toggleAnimationStarted();
        
        yield return new WaitForSeconds(2.1f);
        
        toggleAnimationStarted();
        
        SceneManager.LoadScene("MuratScene");
    }

    private void toggleAnimationStarted() {
        if (this.isAnimationStarted) {
            isAnimationStarted = false;
        } else {
            isAnimationStarted = true;
        }
    }

    private void disableButtonInteraction() {
        this.GetComponent<Button>().interactable = false;
    }
}
