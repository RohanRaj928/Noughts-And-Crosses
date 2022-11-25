using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firework : MonoBehaviour
{
    [Header("Game Manager")]
    public gameManager gm;
    
    [Header("Tween Data")]
    public Vector2 heightRange;
    public Vector2 leftRightOffsetRange;
    public AnimationCurve tweenCurve;
    public float timeTaken;

    [Header("Firework Data")]
    public GameObject Explosion;
    public Color noughtMin;
    public Color noughtMax;
    [Space(6)]
    public Color crossMin;
    public Color crossMax;

    //


    // Start is called before the first frame update
    void Start()
    {
        float height = Random.Range(heightRange.x, heightRange.y);
        float leftRigtOffset = Random.Range(leftRightOffsetRange.x, leftRightOffsetRange.y);

        LeanTween.move(gameObject, new Vector2(gameObject.transform.position.x + leftRigtOffset, gameObject.transform.position.y + height), timeTaken).setEase(tweenCurve).setOnComplete(onTweenEnd);
    }

    void onTweenEnd()
    {
        GameObject pSystem = Instantiate(Explosion);
        pSystem.transform.position = transform.position;
        ParticleSystem.MainModule pSystemComponent = pSystem.GetComponent<ParticleSystem>().main;

        if (gm.currentTurn == 'n')
        {
            pSystemComponent.startColor = new ParticleSystem.MinMaxGradient(noughtMin, noughtMax);
        }
        else
        {
            
            pSystemComponent.startColor = new ParticleSystem.MinMaxGradient(crossMin, crossMax);
        }

        pSystem.SetActive(true);
        Destroy(gameObject);

    }
}
