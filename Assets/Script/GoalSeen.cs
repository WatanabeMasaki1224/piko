using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalSeen : MonoBehaviour
{
    // Start is called before the first frame update
   

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameTimer timer = FindObjectOfType<GameTimer>();
        if (timer != null)
        {
            timer.StopTimer(); // タイマー停止
            Debug.Log("ゴール！");
        }
    }
}
