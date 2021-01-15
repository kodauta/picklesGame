using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SelectNextScene : MonoBehaviour
{
    public TextSelect textSelect;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if(textSelect.textNum == 0)
            {
                SceneManager.LoadScene("Stage1");
            }
            else if(textSelect.textNum ==1)
            {
                SceneManager.LoadScene("Stage1");
            }
            else
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }
}
