using UnityEngine;
using TMPro; // TextMeshPro を使うために必要！
using UnityEngine.SceneManagement; // ←シーン切り替えに必要

public class GameTimer : MonoBehaviour
{
    public TMP_Text timerText;        // 経過時間表示用（TextMeshPro）
    public GameObject clearPanel;     // クリアパネル
    public TMP_Text clearTimeText;    // クリアタイム表示用（TextMeshPro）

    private float timeElapsed = 0f;
    private bool isTiming = false;

    void Update()
    {
        if (isTiming)
        {
            timeElapsed += Time.deltaTime;
            timerText.text = FormatTime(timeElapsed);
        }
    }

    void Start()
    {
        StartTimer();  // 自動でタイマー開始
    }

    public void StartTimer()
    {
        isTiming = true;
        timeElapsed = 0f;
        clearPanel.SetActive(false);
        Debug.Log("Start");
    }

    public void StopTimer()
    {
        isTiming = false;
        clearPanel.SetActive(true);
        clearTimeText.text = "クリアタイム" + FormatTime(timeElapsed);

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            movejump controller = player.GetComponent<movejump>();
            if (controller != null)
            {
                controller.enabled = false; // ← プレイヤー操作を無効化！
            }
        }
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        float seconds = time % 60f;
        return string.Format("{0:00}:{1:00.00}", minutes, seconds);
    }


    public void BackToTitle()
    {
        SceneManager.LoadScene("Title"); // ← タイトルシーン名に合わせて修正！
    }

}