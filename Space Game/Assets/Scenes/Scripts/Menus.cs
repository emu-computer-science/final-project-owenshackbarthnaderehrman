using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    public Button ll1;
    public Button go;
    public Button qg;
    private Text timeGT;

    void Start()
    {
        if (ll1)
            ll1.onClick.AddListener(loadLevel1);
        if (go)
            go.onClick.AddListener(gotoMenu);
        if (qg)
            qg.onClick.AddListener(quitGame);
        GameObject scoreGO = GameObject.Find("Time");
        if (scoreGO != null)
        {
            timeGT = scoreGO.GetComponent<Text>();
            timeGT.text = (ll1 == null) ? "TIME: " + PlayerPrefs.GetInt("time") : "BEST: " + PlayerPrefs.GetInt("best");
        }
        if (ll1 != null)
            PlayerPrefs.SetInt("time", 0);
    }

    public void loadLevel1()
    {
        print("Something is happening");
        SceneManager.LoadScene("Level 1");
    }

    public void gotoMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
