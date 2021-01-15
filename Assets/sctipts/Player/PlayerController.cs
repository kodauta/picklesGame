using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;


public class PlayerController : MonoBehaviour
{
    //inspector variable
    public AudioClip jumpSound;
    public float speed; 
    public float gravityAccel;
    public float jumpSpeed;
    public float fallSpeed;
    public float pushButtonTimeAbility;
    public float riseAbilityTime;
    public float invincibleTimeLimit;

    public GroundCheck ground;
    public GroundCheck head;
    public GameObject knockBackAnim;
    public float deathGroundLevel;
    public GameObject deadPlayer;
    public bool isInvincible;
    

    
    //private variable
    private GameObject canvas;
    private Rigidbody2D rb2d;
    private Animator anim;
    private Damaged damaged;
    private StatusCounter statusCounter;
    private AudioSource audioSource;
    public bool operatability = true;
    public bool isGround = false;
    private bool isHead = false;
    private bool isJump = false;
    private float invincibleTime = 0;
    private float jumpTime = 0.0f;
    private float pushButtonTime = 0.0f;
    private float ySpeed = 0.0f;
    private float xSpeed = 0.0f;
    private List<string> taglist; 
    private Vector3 collidedEnemyPos;
      // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        damaged = knockBackAnim.GetComponent<Damaged>();
        canvas = GameObject.Find("Canvas");
        statusCounter = canvas.GetComponent<StatusCounter>();
        audioSource = GetComponent<AudioSource>();
        taglist = new List<string>(){"Enemy", "EnemyBullet", "Boss"};
    }

    // Update is called once per frame
    void FixedUpdate() //プレイヤー操作 
    {
        //移動系
        isGround = ground.IsGround();//接地判定
        print(isGround);
        isHead = head.IsGround();//頭判定
        float horizontalkey = Input.GetAxis("Horizontal");//横移動のボタンが押されているかどうかの判定
        if(isGround)//キャラクターが接地しているとき
        {
            anim.SetBool("isFall", false);
            anim.SetBool("isJump", false);
            if(Input.GetButtonDown("Jump") && operatability)//ジャンプボタンが押された場合
            {
                ySpeed = jumpSpeed;
                isJump = true;//ジャンプしている判定にする
                jumpTime = 0.0f;
                anim.SetBool("isJump", true);
                audioSource.PlayOneShot(jumpSound);
            }
            else
            {
                isJump = false;
                jumpTime = 0.0f;
                pushButtonTime = 0.0f;
                ySpeed = 0.0f;
                anim.SetBool("isJump", false);
            }
        }
        else if(Input.GetButton("Jump") && pushButtonTime < pushButtonTimeAbility && isJump && !isHead)//長押しでハイジャンプできるようにしてるやつ
        {
            if (pushButtonTime < riseAbilityTime)  // ジャンプで上昇できる時間の制限
            {
                ySpeed = jumpSpeed;
                pushButtonTime = pushButtonTime + Time.deltaTime;
            }
            else  // これは滞空時間を設けてる
            {
                anim.SetBool("isJump", false);
                anim.SetBool("isFall", true);
                ySpeed = 0;
                pushButtonTime = pushButtonTime + Time.deltaTime;
            }
        }
        else  // 接地していない時
        {
            anim.SetBool("isFall", true);
            isJump = false;
            jumpTime += Time.deltaTime;//対空時間の計算
            if(ySpeed > -fallSpeed)
            {
                ySpeed -= gravityAccel * Time.deltaTime;//加速度×時間で落ちてくるようにする
            }
            else//ある一定値以上で落ちる速度が一定になる。
            {
                ySpeed = -fallSpeed;
            }
        }
        // 横移動の処理
        if(horizontalkey > 0 && operatability)//右移動
        {
            transform.localScale = new Vector3(-1,1,1);
            xSpeed = speed;
            anim.SetBool("isRun", true);
        }
        else if (horizontalkey < 0 && operatability)//左移動
        {
            transform.localScale = new Vector3(1,1,1);
            xSpeed = -speed;
            anim.SetBool("isRun", true);
        }
        else//止まってる
        {
            xSpeed = 0.0f;
            anim.SetBool("isRun", false);
        }
        rb2d.velocity = new Vector2(xSpeed, ySpeed);//最終的にここのベクトルに上で計算した速度を代入してる

        if(isInvincible)
        {
            invincibleTime += Time.deltaTime;
            if (invincibleTime < invincibleTimeLimit)
            {
                float level = Mathf.Abs(Mathf.Sin(Time.time * 100 * invincibleTime));
			    gameObject.GetComponent<SpriteRenderer> ().color =  new Color(1f,1f,1f,level);
            }
            else
            {
                invincibleTime = 0;
                isInvincible = false;
                gameObject.GetComponent<SpriteRenderer> ().color =  new Color(1f,1f,1f,1f);
            }

        }
        FallDeathCheck();
        if(statusCounter.hpCounter <= 0)
        {
            Death();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(taglist.Contains(collision.gameObject.tag)) // 敵にぶつかりなおかつすでにノックバックしてないとき
        {
            if(!isInvincible)
            {
                GameObject obj = GameObject.Find("Damaged(Clone)"); //これがねえと複数プレーヤーが生成される
                collidedEnemyPos = collision.gameObject.transform.position;
                ///ここにくらった時HPが減る処理を書く//
                statusCounter.hpCounter -= 1;
                if(obj == null && statusCounter.hpCounter >= 1) //これがねえと複数プレーヤーが生成される
                {
                    GameObject Obj = Instantiate(knockBackAnim, this.transform.position, Quaternion.identity); //ダメージくらうやつを作る
                    damaged.knockBackDirection = KnockBack(collidedEnemyPos); // くらった時のアニメーションのスクリプト内の最初に飛ぶ方向を決めてる
                    damaged.isSetInvincible = true;
                    Destroy(gameObject);
                }
            }

        }
    }
    Vector2 KnockBack(Vector3 collidedObjectPos) // ぶつかったオブジェクトとの相対位置で吹っ飛ぶ方向を決めてる
    {
        return new Vector2 (
            transform.position.x-collidedObjectPos.x,
            transform.position.y-collidedObjectPos.y
            );
    }
    void FallDeathCheck()
    {
        float playerYPos = transform.position.y;
        if(playerYPos < deathGroundLevel)
        {
            statusCounter.hpCounter = 0;
        }
    }
    void Death()
    {
        Destroy(GameObject.Find("BGMSpeaker(Clone)"));
        Instantiate(deadPlayer, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}


