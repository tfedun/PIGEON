using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour {

    public Rigidbody2D Bird;
    private Rigidbody2D rb2d;
    private bool k = false;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (k == true && Bird.gameObject.active)
            rb2d.velocity = new Vector2(-2, 0);
        else if (Input.GetMouseButtonDown(0))
            k = true;
        else if (k == false || !Bird.gameObject.active)
            rb2d.velocity = Vector2.zero;
    }
}
