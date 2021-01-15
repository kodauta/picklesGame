using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour//接地判定を取得するための関数
{
    private string groundTag = "Ground";
    private string blockTag = "Block";
    private string platformTag = "GroundPlatform";
    private bool isGround = false;
    private bool isGroundEnter, isGroundStay, isGroundExit;
    private List<string> taglist = new List<string>();
    private GameObject floorObject;
    private bool isIceFloor = false;
    public string str = "str";
    public bool IsGround()
    {
        if(Input.GetAxis("Horizontal") == 0)
        {
            if (isGroundEnter || isGroundStay)
            {
                isGround = true;
            }
            else if (isGroundExit)
            {
                isGround = false;
            }
        }
        else
        {
            if (isGroundEnter || isGroundStay)
            {
                isGround = true;
            }
            else
            {
                isGround = false;
            }
        }

        isGroundEnter = false;
        isGroundStay = false;
        isGroundExit = false;
        return isGround;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == groundTag || collision.tag == blockTag)
        {
            isGroundEnter = true;  
        }
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.tag == groundTag || collision.tag == blockTag)
        {
            isGroundStay = true;
        }
    }
        
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == groundTag || collision.tag == blockTag)
        {
            isGroundExit = true;
        }
    }
}
