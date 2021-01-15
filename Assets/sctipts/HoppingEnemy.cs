using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoppingEnemy : MonoBehaviour
{
    public float yFirstSpeed;
    public float ySpeedMax;
    public float gravityAccelaration;
    public float stopTime;
    public float diffPosYThreshold;
    private WallReflection wallReflection;
    private float timeCount = 0;
    private float prevYPos;
    private float prevXPos;
    private bool isHop = false;  
    private Rigidbody2D rb2d;
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        wallReflection = GetComponent<WallReflection>();
        prevYPos = transform.localPosition.y;
        prevXPos = transform.localPosition.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isHop)
        {
            timeCount += Time.deltaTime;
            rb2d.constraints = RigidbodyConstraints2D.FreezePositionX;
            if(timeCount > stopTime)
            {
                isHop = true;
                timeCount = 0;
                anim.SetBool("isHop", true);
                rb2d.constraints = RigidbodyConstraints2D.None;
            }
            rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        else
        {
            float xSpeed = wallReflection.XSpeed();
            timeCount += Time.deltaTime;
            Hop(timeCount, xSpeed);
            float diffYPos = prevYPos - transform.localPosition.y;
            
            if(diffYPos > 0 && Mathf.Abs(diffYPos) < diffPosYThreshold)
            {
                isHop = false;
                timeCount = 0;
                anim.SetBool("isHop", false);
            }
            
            prevYPos = transform.localPosition.y;
        }
    }

    void Hop(float timeCount,float xSpeed)
    {

       float ySpeed = yFirstSpeed - gravityAccelaration * timeCount;
       if (ySpeed < -ySpeedMax)
       {
           rb2d.velocity = new Vector2(xSpeed, -ySpeedMax);
       }
       else
       {
           rb2d.velocity = new Vector2(xSpeed, ySpeed);
       }
       prevXPos = transform.localPosition.x;
    }


}
