using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class levelLoader : MonoBehaviour
{
    public GameObject panel;
    public float tweenTime;

    private UnityEngine.UI.Image imageComponent;
    
    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode) // Says what to do when a scene is loaded
    {
        LeanTween.value(panel.gameObject, 1, 0, tweenTime)
            .setEaseOutCubic()
            .setOnUpdate(setColor);
    
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading; // Tells 'OnLevelFinishedLoading' method to start listening for a scene change when script is enabled.
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading; //Unsubscribes the delegate
    }

    public void Start()
    {
        imageComponent = panel.GetComponent<UnityEngine.UI.Image>();
    }
    public void TransitionLevel(int sceneID) // The method that an object calls from outside
    {
        Color endColor = new Color(1f, 0f, 0f);
        LeanTween.value(panel.gameObject, 0, 1, tweenTime)
            .setEaseOutCubic()
            .setOnUpdate(setColor)
            .setOnComplete(sceneChange)
            .setOnCompleteParam(sceneID);
            
    }

    public void setColor(float value)
    {
        imageComponent.color = new Color(imageComponent.color.r, imageComponent.color.g, imageComponent.color.b, value);
    }

    void sceneChange()
    {
        SceneManager.LoadScene(1);
    }



}
