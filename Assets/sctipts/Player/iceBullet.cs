using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceBullet : MonoBehaviour
{
    public GameObject destroyAnim;
    private GameObject player;
    private PlayerController script;

    // Start is called before the first frame update
    void Start()
    {
        player =  GameObject.Find ("Pickles(Clone)");
        script = player.GetComponent<PlayerController>();
    }
    void Update()
    {
        player =  GameObject.Find ("Pickles(Clone)");
        if (player == null)
        {
            PlayDestroyAnimation();
        }
    }

    // Update is called once per frame
    

    void OnCollisionEnter2D(Collision2D collision) //敵に当たると氷と敵が消える関数
    {            
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyBullet")
        {
            if (collision.gameObject.transform.childCount == 1) //敵がアイテム持ってるとき
            {
                collision.transform.DetachChildren();　//子オブジェクトとして持ってるアイテムを切り離して落とす
            }
            Destroy(collision.gameObject);
            PlayDestroyAnimation();
        }    
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            PlayDestroyAnimation();
        }
    }
    public void PlayDestroyAnimation()
    {
        if(player != null)
        {
            GameObject.Find("IceGenerator").GetComponent<ice>().isIcePossession = false;
        }
        GameObject Obj = Instantiate(destroyAnim, this.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
