using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mush : MonoBehaviour
{
    private Rigidbody2D rb2d; 
    private WallReflection wallReflection;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        wallReflection = GetComponent<WallReflection>();
    }

    // Update is called once per frame
    void Update()
    {
        float xSpeed = wallReflection.XSpeed();
        rb2d.velocity = new Vector2(xSpeed, rb2d.velocity.y);
    }
}
