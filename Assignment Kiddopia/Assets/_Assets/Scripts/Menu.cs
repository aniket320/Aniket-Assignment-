using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public static Menu menu;
    public GameObject StartPanel, PausePanel, EndPanel;
    public bool pause,Gamestart;
    public TMP_Text Retrypsneltxt;
    float counts;

    void Awake()
    {
        menu = this;  
    }
    void Start()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = !pause;
        }
        if (pause)
        {
            LeanTween.scale(PausePanel, new Vector3(1, 1, 1), 0.3f);
            Gamestart = true;
        }
        counts = PlayerPrefs.GetFloat("counter", counts);
        Retrypsneltxt.text = counts.ToString();
    }

    public void PlayButton()
    {
        Gamestart = false;
        LeanTween.moveLocal(StartPanel, new Vector3(0, -500, 0), 0.3f);
        LeanTween.scale(StartPanel, new Vector3(0, 0, 0), 0.3f);
        transform.GetChild(0).gameObject.SetActive(true);
    }

    public void ResumeButton()
    {
        pause = false;
        Gamestart = false;
        LeanTween.scale(PausePanel, new Vector3(0, 0, 0), 0.3f);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void failui()
    {
        LeanTween.scale(EndPanel, new Vector3(1, 1, 1), 0.3f);
        transform.GetChild(0).gameObject.SetActive(false);
    }
    public void retryButton()
    {              
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        LeanTween.scale(EndPanel, new Vector3(0, 0, 0), 0.3f);
        transform.GetChild(0).gameObject.SetActive(false);
        PlayButton();
    }
}
