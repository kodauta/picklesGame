using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pery : MonoBehaviour
{
    public GameObject fishBullet;
    public float bulletSpeed;
    public Vector3 adjustVector;
    public float shotSpan;
    public float shotAnimationPlayTime;
    private FishBullet script;
    private float timeCount;
    private float animationTimeCount;
    private Animator animator;
    private bool isShot = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        script = fishBullet.GetComponent<FishBullet>();
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;
        if(timeCount > shotSpan)
        {
            Shot(new Vector2(-transform.localScale.x, 0));
            isShot = true;
            timeCount = 0;
        }
        if (isShot == true)
        {
            animationTimeCount += Time.deltaTime;
            if(animationTimeCount > shotAnimationPlayTime)
            {
                isShot = false;
                animator.SetBool("isShot", false);
                animationTimeCount = 0;
            }
        }
    }
    void Shot(Vector2 direction)
    {
        if(isShot == false)
        {
            Instantiate(fishBullet, transform.position + adjustVector, Quaternion.identity);
            fishBullet.transform.localScale = this.transform.localScale;
            script.Speed = bulletSpeed * direction;
            animator.SetBool("isShot",true);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag =="Ice")
        {
            Vector3 icePos = col.transform.position;
            Vector2 direction = new Vector2(icePos.x-transform.position.x, icePos.y -transform.position.y).normalized;
            Shot(direction);
            isShot = true;
        }
    }
}