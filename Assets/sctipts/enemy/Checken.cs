using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checken : MonoBehaviour
{
    public float walkSpeed;
    public float followSpeed;
    public float Recognition;
    public float heightRecognition;
    public float jumpSpeed;
    public float gravity;
    public float jumpTimeAvility;
    public float returnTime;
    public float returnPos;
    public float jumpPossibility;
    private Rigidbody2D rb2d;
    private GameObject player;
    private float jumpTime = 0;
    private float timeCount = 0;
    private float previousPos;

    private float firstTime = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        previousPos = transform.position.x;     
    }

    // Update is called once per frame
    void Update()
    {
        firstTime += Time.deltaTime;
        if (Random.Range(0,100) < jumpPossibility || jumpTime < 0)
        {
            if(jumpTime < jumpTimeAvility && firstTime > 5)
            {
                Jump();
            }
        }
        else
        {
            jumpTime = 0;
            FundamentalMove();
            FollowingMove();
        }
    }
    void FundamentalMove()
    {
        timeCount += Time.deltaTime; //　ぶつかったとき反転するために時間計測、何秒に一回ぶつかりを検出するか（毎フレームごとにやると反転し続ける)
        
        if (transform.localScale.x > 0)  // どっちに動くか
        {
            rb2d.velocity = new Vector2(-walkSpeed, rb2d.velocity.y);
        } 
        else
        {
            rb2d.velocity = new Vector2(walkSpeed, rb2d.velocity.y);
        }
        if (timeCount > returnTime)
        {
            timeCount = 0;
            if (Mathf.Abs(transform.position.x-previousPos)< returnPos)
            {
                transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);                
            }
            previousPos = transform.position.x;
        }
    }
    void FollowingMove()
    {
       float distance = this.transform.position.x - player.transform.position.x;

        if (Mathf.Abs(distance) < Recognition && player.transform.position.y-this.transform.position.y < heightRecognition && transform.position.y < -1)
        {
            if(distance < 0)
            {
                rb2d.velocity = new Vector2 (followSpeed, rb2d.velocity.y);
                this.transform.localScale = new Vector3 (-1, 1, 1);
            }
            else
            {
                rb2d.velocity = new Vector2 (-followSpeed, rb2d.velocity.y);
                this.transform.localScale = new Vector3 (1, 1, 1);    
            }

        }
        else
        {
            rb2d.velocity = new Vector2 (rb2d.velocity.x, rb2d.velocity.y);
        } 
    }
    void Jump()
    {
        rb2d.velocity = new Vector2 (rb2d.velocity.x, jumpSpeed - gravity*jumpTime);
        jumpTime += Time.deltaTime;
    }


}
