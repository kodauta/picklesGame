using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public GameObject damaged;
    public DamagedEnemy damagedEnemy;
    public int enemyScorePoint;
    private StatusCounter statusCounter;

    void Start()
    {
        var canvas = GameObject.Find("Canvas");
        statusCounter = canvas.GetComponent<StatusCounter>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Ice")
        {
            if(collision.gameObject.tag == "Ice")
            {
                statusCounter.score += enemyScorePoint;
            }
            ItemDrop script = GetComponent<ItemDrop>();
            if (script != null) // 敵がitemを保持しているとき
            {
                script.Drop(); //そのアイテムを落とす
            }
            
            if(collision.transform.position.x > transform.position.x)
            {
                damagedEnemy.blowAwayDirection = -1;
            }
            else
            {
                damagedEnemy.blowAwayDirection = 1;
            }
            Instantiate(damaged, transform.position, Quaternion.identity);
            Destroy(gameObject);            
        }
    }
    
}

