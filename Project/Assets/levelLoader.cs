using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class levelLoader : MonoBehaviour
{
    public GameObject canvas;
    [Header("Movement Settings")]
    public GameObject transitionIn; //The object that physically moves inwards
    public GameObject transitionOut; //The object that physically moves outwards
    public float transitionTime;

    [Header("Transition Settings")]
    public int sceneID;

    private RectTransform canvasRectComponent;

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode) // Says what to do when a scene is loaded
    {
        transitionOut.transform.position = new Vector2(transitionOut.transform.position.x + canvas.GetComponent<RectTransform>().rect.width+100, transitionOut.transform.position.y);
        LeanTween.moveX(transitionOut, transitionOut.transform.position.x - canvas.GetComponent<RectTransform>().rect.width-100, transitionTime).setEaseInOutCubic();
    
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
        canvasRectComponent = canvas.GetComponent<RectTransform>();
    }
    public void TransitionLevel(int sceneID) // The method that an object calls from outside
    {
        LeanTween.moveX(transitionIn, transitionIn.transform.position.x  - (canvas.GetComponent<RectTransform>().rect.width + 100), transitionTime).setEaseInOutCubic().setOnComplete(changeLevel);
        void changeLevel()
        {
            SceneManager.LoadScene(sceneID);
        }

    }



}
