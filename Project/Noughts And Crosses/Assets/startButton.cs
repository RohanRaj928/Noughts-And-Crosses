using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startButton : MonoBehaviour
{
    public GameObject explosion;

    public void Explosion()
    {
        Instantiate(explosion, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
    }
}
