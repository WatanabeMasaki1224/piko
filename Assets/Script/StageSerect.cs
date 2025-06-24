using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSerect : MonoBehaviour
{
    // Start is called before the first frame update
    public void  LoadStage1()
    {
        SceneManager.LoadScene("Stage1");
        Debug.Log("ƒ{ƒ^ƒ“‚ª‰Ÿ‚³‚ê‚Ü‚µ‚½I");
    }

    // Update is called once per frame
    public void LoadStage2() 
    {
        SceneManager.LoadScene("Stage2");
    }
}
