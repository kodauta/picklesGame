using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ice : MonoBehaviour
{
    public float Speed;
    public float ySpeedOffset;
    public int iceConsumption;
    public GameObject iceBullet;
    public GameObject iceCreateAnimation;
    public AudioClip iceMake;
    private GameObject player;
    private GameObject Anim;
    private PlayerController playerController;
    private StatusCounter statusCounter;
    private Rigidbody2D icerb2d;
    private AudioSource audioSource;
    private bool isAnimPlay = false;
    public bool isIcePossession = false;
    private bool isIceThrown = false;
    private float iceXspeed;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Pickles(Clone)");
        playerController = player.GetComponent<PlayerController>();
        statusCounter = GameObject.Find("Canvas").GetComponent<StatusCounter>();
        audioSource = GetComponent<AudioSource>();
        isIcePossession = false;
    }

    void Update()
    {
        player = GameObject.Find("Pickles(Clone)");
        GameObject Obj = GameObject.Find("ice(Clone)");
        if(Obj == null) //氷がフィールドのどこにもないとき
        {
            isIceThrown = false;
            if(Input.GetButtonDown("Fire1") && Input.GetAxis("Vertical") >= 0 && player != null && !isAnimPlay)//氷ボタンを押すと氷を生成
            {
                if(statusCounter.iceGageCounter > 0)
                {
                    statusCounter.iceGageCounter -= iceConsumption;
                    isIcePossession = true;//氷の所有をtrueにする
                    Anim = animGenerate();//アニメーション再生
                    audioSource.PlayOneShot(iceMake);
                }
            }
            if(isAnimPlay)　//アニメーションの消滅はアニメーションにアタッチされてるスクリプトで管理されている
            {
                if(Anim == null)
                {
                    iceGenerate(); //弾を生成し
                    isAnimPlay = false; //アニメーションのプレイをオフにする
                }
                else 
                {
                    icePossess(Anim);
                }
            }


        }
        else if (Obj != null)//氷オブジェクトがある時
        {
            if (isIcePossession) //氷を所有しているとき
            {
                icePossess(Obj);//氷所有関数の呼び出し(氷がプレイやーの動きと同期)
            }
            if(Input.GetButtonDown("Fire1"))//氷ボタンを押すと氷を投げる
            {
                isIcePossession =false;
                if(!isIceThrown)
                {
                    iceXspeed = determineIceDirection();
                }
                iceThrow(Obj, iceXspeed);//氷投げ関数の呼び出し
                isIceThrown = true;
            }
            if(isIceThrown)
            {
                iceThrown(Obj, iceXspeed);
            }
        }
        
    }

    public GameObject animGenerate()
    {
        GameObject Obj = Instantiate(iceCreateAnimation, this.transform.position, Quaternion.identity);
        isAnimPlay = true;
        return Obj;
    }
    public void iceGenerate() // プレイヤーの上に出す
    {
        GameObject Obj = Instantiate(iceBullet, this.transform.position, Quaternion.identity);
    }
    public void icePossess(GameObject Obj) //　プレイヤーにくっつく
    {
        Obj.transform.position = this.transform.position;
    }

    public float determineIceDirection() //氷の飛んでく方向を決める
    {
        if(player.transform.localScale.x < 0)
        {
            return Speed;
        }
        else
        {
            return -Speed;
        }
    }
    public void iceThrow(GameObject Obj, float xSpeed) //氷投げ関数
    {   
        icerb2d = Obj.GetComponent<Rigidbody2D>();
        float ySpeed = icerb2d.velocity.y - ySpeedOffset;         
        icerb2d.velocity = new Vector2(xSpeed, ySpeed);       
    }

    public void iceThrown(GameObject Obj, float xSpeed)　//氷が投げられた後の動き
    {
        icerb2d = Obj.GetComponent<Rigidbody2D>();
        float thrownYSpeed = icerb2d.velocity.y;
        if(thrownYSpeed > 0)
        {
            icerb2d.velocity = new Vector2(xSpeed, 0);
        }
        else
        {
            icerb2d.velocity = new Vector2(xSpeed, -ySpeedOffset);
        }
    }
}
