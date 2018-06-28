using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public Text timerField;
    public Text scoreField;

    public GameManager Manager;
    public GameObject PauseMenu;
    public Image Progress;

    private float timer;

    private string minutes;
    private string seconds;
    private bool _ended = false;

    private void Awake()
    {
        Resume();
        scoreField.text = "PROGRESS";

    }


    void Update()
    {
        timer = Time.timeSinceLevelLoad;
        minutes = ((int)timer / 60).ToString();
        seconds = ((int)timer % 60).ToString();
        timerField.text = minutes + ":" + seconds;



        CheckProgress();

        if (Input.GetKeyDown(KeyCode.Escape) && !_ended)
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
        if(Progress.fillAmount == 1)
        {
            Manager.isOver = true;
        }
    }


}
