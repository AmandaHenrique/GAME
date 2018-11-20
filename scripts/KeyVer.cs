using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyVer : MonoBehaviour
{

    private UI ui;
    private Player player;
    public static bool keyVermelha = false;

    private bool vai;
    // Use this for initialization
    void Start()
    {
        //this.gameObject.SetActive(false);
        ui = GameObject.Find("Canvas").GetComponent<UI>();
        player = GameObject.Find("Player").GetComponent<Player>();
        keyVermelha = false;
}

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            ui.showE();
            if (Input.GetKeyDown(KeyCode.E))
            {
                keyVermelha = true;
                ui.showKeyUIVer();
                ui.hideE();
                this.gameObject.SetActive(false);
                ui.showMessageFriend();
                


            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            ui.hideE();
        }
    }

}
