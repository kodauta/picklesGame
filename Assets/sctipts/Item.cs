using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject collectedPrefab;
    private GameObject canvas;
    private StatusCounter statusCounter;

    public float itemCoolTime = 0.05f;
    public int itemHealPoint;
    public int itemIceGagePoint;
    public int itemScorePoint;
    public int itemLifePoint;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        statusCounter = canvas.GetComponent<StatusCounter>();
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {            
            var collected = Instantiate
            (
                collectedPrefab,
                transform.position,
                Quaternion.identity // 回転させないで表示
            );
            var animator = collected.GetComponent<Animator>();
            var animationTime = animator.GetCurrentAnimatorStateInfo(0).length;
            Destroy(collected, animationTime);
            if(statusCounter.hpCounter < 5)
            {
                statusCounter.hpCounter += itemHealPoint;
            }
            if(statusCounter.iceGageCounter < 5)
            {
                statusCounter.iceGageCounter += itemIceGagePoint;
            }
            statusCounter.lifeCounter += itemLifePoint;
            statusCounter.score += itemScorePoint;
            if(gameObject.tag == "Charger")
            {
                statusCounter.chargerCounter += 1;
            }

            Destroy(gameObject);
        }
    }
}
