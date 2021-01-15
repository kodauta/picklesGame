using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneSideFloor : MonoBehaviour
{
    public BoxCollider2D box;
    public float offset;
    private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        player = GameObject.Find("Pickles(Clone)");
    }

    // Update is called once per frame
    void Update()
    {        
        if(player == null)
        {
            box.enabled = false;
            player = GameObject.Find("Pickles(Clone)");
            if(player == null)
            {
                player = GameObject.Find("Damaged(Clone)");
            }
        }
        else
        {
            if(player.transform.position.y > transform.position.y + offset)
            {

                box.enabled = true;
            }
            else if (player.transform.position.x > transform.position.x + box.size.x/2 || player.transform.position.x < transform.position.x - box.size.x/2)
            {
                box.enabled = false;
            }
        }
    }
}
