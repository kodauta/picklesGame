using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingRange : MonoBehaviour
{
    private GameObject mainCamera;
    private Vector3 cameraPos;
    public float drawingRange;


    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
        
    }
    void Update()
    {
        cameraPos = mainCamera.gameObject.transform.position;
        float distance = Vector3.Distance(cameraPos, transform.position);
        if(distance>drawingRange)
        {
            Destroy(gameObject);
        }
    }

}
