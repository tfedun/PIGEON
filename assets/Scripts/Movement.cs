using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public int speed = 0;
    bool fly = false;
    public Rigidbody2D Bird;
    public Rigidbody2D Poop;
    public Transform Bird1;
    int a = 0;

    void Update()
    {
        if (Input.GetMouseButton(0))
            OnMouseDown();
        else OnMouseUp();
    }
    void OnMouseDown()
    {
        if (Input.mousePosition.x < 400)
        {
            speed += 30;

            if (speed >= 500)
                speed = 500;

            Bird.velocity = Vector2.zero;
            Bird.AddForce(new Vector2(0, speed));
        }
        else if (Input.mousePosition.x > 400)
        {
            if (a != 0)
                a -= 10;
            else
            {
                a = 100;
                Rigidbody2D Poop1;
                Poop1 = Instantiate(Poop, Bird1.position, Bird1.rotation) as Rigidbody2D;
                Poop1.AddForce(new Vector2(0, -600));
            }
        }
    }

    void OnMouseUp()
    {
        speed -= 10;
    
        if (speed <= 0)
            speed = 0;

        if(!fly)
        {
            Bird.AddForce(new Vector2(1,0));
        }
        
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Road")
            fly = false;
        else fly = true;
    }
     
}