using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyemovement : MonoBehaviour {

    public GameObject Eye;
    float a;
    int Rotationx;

    void Update()
    {
        a += 1;
        Rotationx = Random.Range(0,360);
        if (a >= 100)
        {
            Eye.transform.rotation = Quaternion.Euler(0, 0, Rotationx);
            a = 0;
        }
    }
}
