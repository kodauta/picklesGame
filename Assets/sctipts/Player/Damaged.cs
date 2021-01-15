
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damaged : MonoBehaviour
{
    public Vector2 knockBackDirection;
    public float knockBackIntensity;
    public float gravityAccel;
    public float destroyTime;
    public float maxStopTime;
    public GroundCheck groundCheck;
    public GameObject player;
    public bool isSetInvincible = false;
    private bool startTimeCount;
    private float timeCount = 0;
    private float timeCountForFall; //ひっかかかるとあれするやつ
    private float timeCountOnGround = 0;
    private Rigidbody2D rb2d;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timeCount > 0.05 || timeCountOnGround > 0.05)
        {
            anim.SetBool("NextState", true); //わたわたするアニメーションにいくやつ 
        }   
        if(!startTimeCount || timeCount > 3)
        {
            timeCount += Time.deltaTime;
            float ySpeed = knockBackDirection.y*knockBackIntensity - gravityAccel*timeCount;
            rb2d.velocity = new Vector2 (knockBackDirection.x*knockBackIntensity, ySpeed);
        }
        else
        {
            timeCountOnGround += Time.deltaTime;
            if(timeCountOnGround > destroyTime)
            {
                InstantiatePlayer();
            }
            rb2d.velocity = new Vector2(0,0);
        }
        startTimeCount = groundCheck.IsGround();
        
        timeCountForFall += Time.deltaTime;
        if(timeCountForFall > maxStopTime)
        {
            InstantiatePlayer();
        }
    }
    void InstantiatePlayer()
    {
        GameObject obj = Instantiate(player, this.transform.position, Quaternion.identity);
        PlayerController script = obj.GetComponent<PlayerController>();
        script.isInvincible = isSetInvincible;
        Destroy(gameObject);
    }

}
