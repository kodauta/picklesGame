using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testText : MonoBehaviour
{
    public Vector3 textPos;
    // Start is called before the first frame update
    void Start()
    {
        var hoge = GetComponent<RectTransform>();
        hoge.localPosition = textPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
