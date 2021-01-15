using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuSelect : MonoBehaviour
{
    public TextSelect textSelect;
    private bool isBlinking = false;
    private int textNum;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {

            isBlinking = true;
            textNum = textSelect.textNum;

                
            
        }
        if(isBlinking)
        {
            var blinkingtext = textSelect.texts[textSelect.textNum].GetComponent<BlinkingText>();
            var nextScene = textSelect.texts[textSelect.textNum].GetComponent<NextScene>();
            blinkingtext.Blinking();
            nextScene.SceneWait();
        }
    }
}
