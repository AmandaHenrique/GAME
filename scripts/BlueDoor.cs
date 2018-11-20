using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueDoor : MonoBehaviour {

    
    private UI ui;
    private Animator animator;
    private bool open;
	// Use this for initialization
	void Start () {
        ui = GameObject.Find("Canvas").GetComponent<UI>();
        animator = GetComponent<Animator>();
        open = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (open)
        {
            animator.SetBool("open", open);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Key.keyAzul)
            {
                ui.showE();

                if (Input.GetKeyDown(KeyCode.E))
                {
                    ui.hideE();
                    open = true;
                    Key.keyAzul = false;
                    ui.HideKeyUI();                    
                }
            }
            
           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            if (Key.keyAzul)
            {
                ui.hideE();
            }
            
        }
    }


    
}
