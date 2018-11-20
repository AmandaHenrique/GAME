using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedDoor : MonoBehaviour {

    private UI ui;
    private Animator animator;
    private bool openV;
    // Use this for initialization
    void Start()
    {
        ui = GameObject.Find("Canvas").GetComponent<UI>();
        animator = GetComponent<Animator>();
        openV = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (openV)
        {
            animator.SetBool("openV", openV);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (KeyVer.keyVermelha)
            {
                ui.showE();

                if (Input.GetKeyDown(KeyCode.E))
                {
                    ui.hideE();
                    openV = true;
                    KeyVer.keyVermelha = false;
                    ui.HideKeyUIVer();
                }
            }


        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (KeyVer.keyVermelha)
            {
                ui.hideE();
            }

        }
    }

    IEnumerator waitDoor()
    {
        yield return new WaitForSeconds(0.2f);
        KeyVer.keyVermelha = false;
    }
}
