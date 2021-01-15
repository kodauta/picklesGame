using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeadMove : MonoBehaviour
{
    public float riseSpeed;
    public float soundSpan;
    public AudioClip deadSound;
    public CameraShake cameraShake;
    private float timeCount;
    private AudioSource audioSource;
    private GameObject mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        mainCamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        cameraShake.Shake(mainCamera);
        timeCount += Time.deltaTime;
        transform.position +=  new Vector3(0, riseSpeed, 0);
        if(timeCount > soundSpan)
        {
            audioSource.PlayOneShot(deadSound);
            timeCount = 0;
        }
    }
}
