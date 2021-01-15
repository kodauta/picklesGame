using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallReflection : MonoBehaviour
{
    private float timeCount;
    private float previousPos;
    public float returnTime;
    public float returnPos;
    public float walkspeed;
    // Start is called before the first frame update
    void Start()
    {
        timeCount = 0;
        previousPos = transform.position.x;     
    }
    public float XSpeed()
    {
        timeCount += Time.deltaTime; //　ぶつかったとき反転するために時間計測、何秒に一回ぶつかりを検出するか（毎フレームごとにやると反転し続ける)
        
        if (timeCount > returnTime)
        {
            timeCount = 0;
            if (Mathf.Abs(transform.position.x-previousPos)< returnPos)
            {
                transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);                
            }
            previousPos = transform.position.x;
        }

        if (transform.localScale.x > 0)  // どっちに動くか
        {
            return -walkspeed;
        } 
        else
        {
            return walkspeed;
        }


    }
}

