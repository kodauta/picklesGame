using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Item;
    public float randomNum;
    public float interval;
    public float accel;
    public float moveRangeMax;
    public float moveRangeMin;
    public Vector3 itemPos;
    private float timeCount;
    // Start is called before the first frame update
    void Start()
    {
        timeCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;
        if (timeCount > interval)
        {
            transform.position = new Vector3 (Random.Range(moveRangeMin, moveRangeMax), transform.position.y, transform.position.z);
            GameObject enemyObj = Instantiate(Enemy, this.transform.position, Quaternion.identity);
            if (Random.Range(0,100) < randomNum) // itemを持って生まれてくる人
            {
                GameObject itemObj = Instantiate(Item, this.transform.position + itemPos, Quaternion.identity);
                itemObj.transform.parent = enemyObj.transform;
            }
            timeCount = 0;
        }
        
    }
}
