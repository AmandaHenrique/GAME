using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
    public static bool clickPlay = false;

    UI ui;

    private void Start()
    {
        ui = GameObject.Find("Canvas").GetComponent<UI>();

    }

    public void loadScene(string name)
    {
        SceneManager.LoadScene(name);
        if (name == "OJOGO")
        {
            clickPlay = true;
            AudioINICIO.tocando = false;
        }
    }
    public void loadSceneBack(string name)
    {
        SceneManager.LoadScene(name);
        
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void pauseOff()
    {
        Player.varPause = false;
        Time.timeScale = 1;
        ui.cursorFalse();
        ui.pauseScreenOff();
        StartCoroutine(waitPause());
        
    }

    IEnumerator waitPause()
    {
        yield return new WaitForSeconds(0.1f);
    }

   
}
