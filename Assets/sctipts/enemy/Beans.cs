using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beans : MonoBehaviour
{
    public GameObject beanBullet;
    public GameObject damaged;
    public float throwPower;
    public int throwNum;
    public float coolTime;
    public float soundHearableDistance;
    private float timeCount = 0;
    private Vector3 firstPos;
    private float animationTime;
    private float playTime = 0;
    private Animator anim;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        firstPos = transform.position;
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position= firstPos;
        timeCount += Time.deltaTime;

        if(timeCount > coolTime)
        {            
            playTime += Time.deltaTime;
            anim.SetBool("isThrow", true);
            animationTime = anim.GetCurrentAnimatorStateInfo(0).length;
            if (playTime >= animationTime)
            {
                var camera = GameObject.Find("Main Camera");
                var distance = Mathf.Abs(Vector3.Distance(camera.transform.position, transform.position));
                if(distance < soundHearableDistance)
                {
                    audioSource.Play();
                }                
                for (int i=0; i < throwNum; ++i)
                {
                    GameObject obj = Instantiate(beanBullet, transform.position, Quaternion.identity);
                    BeanBullet script = obj.GetComponent<BeanBullet>();
                    script.firstSpeed = new Vector2 (throwPower*Mathf.Cos(Mathf.PI/4 + Mathf.PI/(2*(throwNum-1))*i), throwPower*Mathf.Sin(Mathf.PI/4 + Mathf.PI/(2*(throwNum-1))*i));
                }
                anim.SetBool("isThrow", false);
                timeCount = 0;
                playTime = 0;
            }
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player"|| collision.gameObject.tag == "Ice")
        {
            Instantiate(damaged,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
