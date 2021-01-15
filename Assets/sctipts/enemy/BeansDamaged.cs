using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeansDamaged : MonoBehaviour
{
    public GameObject angryBeans;

    public float damagedTime;
    private float timeCount = 0;
    private int rotateNum = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;
        if(timeCount > damagedTime)
        {
            transform.localScale = new Vector3(-1*transform.localScale.x ,1, 1);
            rotateNum += 1;
            timeCount = 0;
        }
        if(rotateNum>5)
        {
            Instantiate(angryBeans,transform.localPosition,Quaternion.identity);
            Destroy(gameObject);
        }


    }
}
