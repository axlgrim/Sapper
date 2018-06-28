using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
    
    public Text timerField;
    public Text scoreField;
    public Text EndMessage;

    public GameManager Manager;
    public GameObject PauseMenu;
    public GameObject EndMenu;
    public Image Progress;

    private float timer;

    private string minutes;
    private string seconds;

    private void Awake()
    {
        Resume();
        scoreField.text = "PROGRESS";
        EndMenu.SetActive(false);

    }


    void Update()
    {
        timer = Time.timeSinceLevelLoad;
        minutes = ((int)timer / 60).ToString();
        seconds = ((int)timer % 60).ToString();
        timerField.text = minutes + ":" + seconds;



        CheckProgress();

        if (Input.GetKeyDown(KeyCode.Escape) && !Manager.isOver)
        {
            if (Manager.isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if(Manager.isOver)
        {
            if(Progress.fillAmount == 1f)
            {
                Finish(Color.green, "YOU WIN!");
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
        Manager.isPaused = false;
    }

    void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        Manager.isPaused = true;
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
        Progress.fillAmount = ((float)Manager.openedCells / ((float)Manager.totalCells - (float)Manager.mine_num));
        if(Progress.fillAmount == 1f)
        {
            Manager.isOver = true;
        }
    }

    void Finish(Color c, string message)
    {
        Time.timeScale = 0f;
        Manager.gameOver();
        EndMenu.SetActive(true);
        EndMessage.color = c;
        EndMessage.text = message;
    }




}
