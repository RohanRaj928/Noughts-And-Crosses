using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endScreenManager : MonoBehaviour
{
    // Inspector Variables
    [Header("Tween Data")]
    public float finalTextPos;
    public float finalButtonPos;
    public float timeTaken;
    
    private GameObject winText;
    private GameObject replayButton;

    private void Start()
    {
        winText = transform.Find("Win Text").gameObject;
        replayButton = transform.Find("Replay Button").gameObject;
    }


    public void onGameEnd(char winner)
    {
        
        TMPro.TextMeshProUGUI text = this.transform.GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>();
        if (winner == 'n')
        {
            text.text = "Noughts have won";
        }
        else
        {
            text.text = "Crosses have won";
        }

        winText.transform.localScale = Vector3.one;
        replayButton.transform.localScale = Vector3.one;

        LeanTween.moveLocalY(winText, finalTextPos, timeTaken).setEaseInOutQuart();
        LeanTween.moveLocalY(replayButton, finalButtonPos, timeTaken).setEaseInOutQuart();

    }
}


