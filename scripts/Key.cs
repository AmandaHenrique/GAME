using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    private UI ui;
    private Player player;
    public static bool keyAzul = false;

    // Use this for initialization
    void Start()
    {
        this.gameObject.SetActive(false);
        ui = GameObject.Find("Canvas").GetComponent<UI>();
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        rotate();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            ui.showE();
            if (Input.GetKeyDown(KeyCode.E))
            {
                keyAzul = true;
                ui.showKeyUI();
                ui.hideE();
                this.gameObject.SetActive(false);
                


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

    private void rotate()
    {
        transform.Rotate(0, +2, 0);
    }

}
