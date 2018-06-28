using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
    
    public Text TimerField;
    public Text ScoreField;
    public Text EndMessage;

    public GameManager Manager;
    public GameObject PauseMenu;
    public GameObject EndMenu;
    public Image Progress;

    private float _timer;

    private string _minutes;
    private string _seconds;

    private void Awake()
    {
        Resume();
        ScoreField.text = "PROGRESS";
        EndMenu.SetActive(false);

    }


    void Update()
    {
        _timer = Time.timeSinceLevelLoad;
        _minutes = ((int)_timer / 60).ToString();
        _seconds = ((int)_timer % 60).ToString();
        TimerField.text = _minutes + ":" + _seconds;



        CheckProgress();

        if (Input.GetKeyDown(KeyCode.Escape) && !Manager.IsOver)
        {
            if (Manager.IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if(Manager.IsOver)
        {
            if(Progress.fillAmount == 1f)
            {
                Finish(Color.blue, "YOU WIN!");
            }
            else
            {
                Finish(Color.red, "YOU LOOSE!");
            }

        }

    }

    void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Manager.IsPaused = false;
    }

    void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        Manager.IsPaused = true;
    }

    public void OnResumeBtnClicked()
    {
        Resume();
    }

    public void OnRestartBtnClicked()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnMenuBtnClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void CheckProgress()
    {
        Progress.fillAmount = ((float)Manager.OpenedCells / ((float)Manager.TotalCells - (float)Manager.Mine_num));
        if(Progress.fillAmount == 1f)
        {
            Manager.IsOver = true;
        }
    }

    void Finish(Color c, string message)
    {
        Time.timeScale = 0f;
        Manager.GameOver();
        EndMenu.SetActive(true);
        EndMessage.color = c;
        EndMessage.text = message;
    }




}
