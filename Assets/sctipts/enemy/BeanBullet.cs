using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanBullet : MonoBehaviour
{
    public float powerToSpeed;
    public Vector2 firstSpeed;
    public float gravityAccel;
    private float timeCount = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timeCount += Time.deltaTime;
        float diffX = powerToSpeed*firstSpeed.x;
        float diffY = powerToSpeed*firstSpeed.y-gravityAccel*timeCount;
        transform.position += new Vector3(diffX, diffY, 0);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player"|| collision.gameObject.tag == "Ice")
        {
            Destroy(gameObject);
        }
    }

}
