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

    void Start()
    {
        if (ll1)
            ll1.onClick.AddListener(loadLevel1);
        if (go)
            go.onClick.AddListener(gotoMenu);
        if (qg)
            qg.onClick.AddListener(quitGame);
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
