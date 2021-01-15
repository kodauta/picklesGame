using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBullet : MonoBehaviour
{
    public Vector2 Speed;
    public float addjust;
    // Start is called before the first frame update
    void Start()
    {
        Speed = new Vector2(-10, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += addjust * new Vector3(Speed.x, Speed.y, 0);
    }
        void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player"|| collision.gameObject.tag == "Ice")
        {
            Destroy(gameObject);
        }
    }
}
