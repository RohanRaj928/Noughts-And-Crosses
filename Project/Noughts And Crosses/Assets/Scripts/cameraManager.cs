using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class cameraManager : MonoBehaviour
{
    [Header("Tween Settings")]
    public float endSize;
    public float tweenTime;

    Camera cam;

    private void Start()
    {
        cam = gameObject.GetComponent<Camera>();
    }


    public void gameEnd()
    {
        LeanTween.value(gameObject, changeCameraSize, cam.orthographicSize, endSize, tweenTime).setEaseInOutQuart();
        
    }

    private void changeCameraSize(float size, float ratio)
    {
        gameObject.GetComponent<Camera>().orthographicSize = size;
    }
}

