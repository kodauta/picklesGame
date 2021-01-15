using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryBeans : MonoBehaviour
{
    public GameObject damaged;
    public GameObject beanBullet;
    private EnemyMoveIndex script;
    public AudioClip beanBulletSound;
    public float soundHearableDistance;
    public int throwTiming;
    public float throwPower;
    public int throwNum;
    private Animator anim;
    private float animationTime;
    private float playTime = 0;
    private AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        animationTime = anim.GetCurrentAnimatorStateInfo(0).length;
        script = GetComponent<EnemyMoveIndex>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        script.FollowingMove();
        playTime += Time.deltaTime;
        
        if (playTime >= throwTiming*animationTime)
        {
            var camera = GameObject.Find("Main Camera");
            var distance = Mathf.Abs(Vector3.Distance(camera.transform.position, transform.position));
            if(distance < soundHearableDistance)
            {
                audioSource.PlayOneShot(beanBulletSound);
            }          
            for (int i=0; i < throwNum; ++i)
            {
                GameObject obj = Instantiate(beanBullet, transform.position, Quaternion.identity);
                BeanBullet script = obj.GetComponent<BeanBullet>();
                script.firstSpeed = new Vector2 (throwPower*Mathf.Cos(Mathf.PI/4 + Mathf.PI/(2*(throwNum-1))*i), throwPower*Mathf.Sin(Mathf.PI/4 + Mathf.PI/(2*(throwNum-1))*i));
            }
            playTime = 0;
        }
    }
}
