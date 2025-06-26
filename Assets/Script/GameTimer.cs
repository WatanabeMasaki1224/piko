using UnityEngine;
using TMPro; // TextMeshPro ���g�����߂ɕK�v�I
using UnityEngine.SceneManagement; // ���V�[���؂�ւ��ɕK�v

public class GameTimer : MonoBehaviour
{
    public TMP_Text timerText;        // �o�ߎ��ԕ\���p�iTextMeshPro�j
    public GameObject clearPanel;     // �N���A�p�l��
    public TMP_Text clearTimeText;    // �N���A�^�C���\���p�iTextMeshPro�j

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
        StartTimer();  // �����Ń^�C�}�[�J�n
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
        clearTimeText.text = "�N���A�^�C��" + FormatTime(timeElapsed);

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            movejump controller = player.GetComponent<movejump>();
            if (controller != null)
            {
                controller.enabled = false; // �� �v���C���[����𖳌����I
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
        SceneManager.LoadScene("Title"); // �� �^�C�g���V�[�����ɍ��킹�ďC���I
    }

}