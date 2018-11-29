using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    public Text bullets;
    public Text yourBullets;
    public Text points;
    public Text rank;

    public Sprite[] playerLifes;
    public Image lifesImage;

    public GameObject clickE;
    public GameObject showMessageKey;
    public GameObject keyui;
    public GameObject keyuiVer;
    public GameObject lose;
    public GameObject victory;

    public GameObject pause;
    public bool isPause;

    public GameObject messageFriend;
    
    public void updateLifes(int lifes)
    {
        lifesImage.sprite = playerLifes[lifes];
    }

	public void updateBullets(int quant1, int quant2)
    {
        bullets.text = quant1 + "  I  " + quant2;
    }

    public void showE()
    {
        clickE.SetActive(true);
    }

    public void hideE()
    {
        clickE.SetActive(false);
    }

    public void updatePoints(int pontos)
    {
        points.text = "Points - " + pontos;
    }

    public void updateRank(int rankValue)
    {
        rank.text = "Rank - "+rankValue;
    }

    public void showGetKey()
    {
        showMessageKey.SetActive(true);
    }
    public void hideShowGetKey()
    {
        showMessageKey.SetActive(false);
    }

    //AZUL
    public void showKeyUI()
    {
        keyui.SetActive(true);
    }
    public void HideKeyUI()
    {
        keyui.SetActive(false);
    }


    //VERMELHA
    public void showKeyUIVer()
    {
        keyuiVer.SetActive(true);
    }
    public void HideKeyUIVer()
    {
        keyuiVer.SetActive(false);
    }

    public void showMessageFriend()
    {
        messageFriend.SetActive(true);
        StartCoroutine(waitFriend());
    }
    IEnumerator waitFriend()
    {
        yield return new WaitForSeconds(10f);
        messageFriend.SetActive(false);
    }


    //LOSE
    public void showLose()
    {
        lose.SetActive(true);
    }
    public void hideLose()
    {
        lose.SetActive(false);
    }


    //PAUSE


    public void pauseScreenOn()
    {
        pause.SetActive(true);
    }

    public void pauseScreenOff()
    {
        pause.SetActive(false);
    }

    public void cursorTrue()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None; ;
    }

    public void cursorFalse()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    //VICTORY

    public void showVictory()
    {
        victory.SetActive(true);
        Player.speed = 0;
        StartCoroutine(waitVictory());
        
    }

    public void hideVictory()
    {
        victory.SetActive(false);
    }

    IEnumerator waitVictory()
    {
        yield return new WaitForSeconds(10f);
        Player.varPause = false;
        swat.isPreta = true;
    }




}
