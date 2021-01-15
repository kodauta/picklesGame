using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveIndex : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb2d; 
    private float previousPos;
    public float returnTime;
    public float returnPos;
    public float walkSpeed;
    public float Recognition;
    public float heightRecognition;
    public float jumpAccel;

    // Start is called before the first frame update
    public void Start()
    {
        player = GameObject.Find("Pickles(Clone)");
        rb2d = GetComponent<Rigidbody2D>();  
        previousPos = transform.position.x;     
    }
    public void FundamentalMove(float timeCount) //　ぶつかったとき反転するために時間計測、何秒に一回ぶつかりを検出するか（毎フレームごとにやると反転し続ける)
    {       
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
    public void FollowingMove()
    {
        player = GameObject.Find("Pickles(Clone)");
        if(player != null)
        {
            float distance = this.transform.position.x - player.transform.position.x;

            if (Mathf.Abs(distance) < Recognition && player.transform.position.y-this.transform.position.y < heightRecognition)
            {
                if(distance < 0)
                {
                    rb2d.velocity = new Vector2 (walkSpeed, rb2d.velocity.y);
                    this.transform.localScale = new Vector3 (-1, 1, 1);
                }
                else
                {
                    rb2d.velocity = new Vector2 (-walkSpeed, rb2d.velocity.y);
                    this.transform.localScale = new Vector3 (1, 1, 1);    
                }
            }
            else
            {
                rb2d.velocity = new Vector2 (0, rb2d.velocity.y);
            }
        }
    }

   // Start is called before the first frame update

}
