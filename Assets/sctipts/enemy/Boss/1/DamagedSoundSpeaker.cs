using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSoundSpeaker : MonoBehaviour
{
    private float timeCount = 0;
    public float destroyTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;
        if(timeCount>destroyTime)
        {
            Destroy(gameObject);
        }
    }
}
