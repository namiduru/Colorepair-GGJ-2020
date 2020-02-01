﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] float heightCoefficient = 0.12f;
    [SerializeField] GameObject spinner;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Input.mousePosition.y < Screen.height * heightCoefficient) {
            if (spinner.transform.eulerAngles.z > 180 && spinner.transform.eulerAngles.z < 300) {
                Debug.Log("Green is clicked!");
            } else if (spinner.transform.eulerAngles.z > 60 && spinner.transform.eulerAngles.z < 180) {
                Debug.Log("Red is clicked!");
            } else {
                Debug.Log("Blue is clicked");
            }
        }    
    }

}
