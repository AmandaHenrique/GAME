using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swat : MonoBehaviour {


    private UI ui;
    private bool clicou = false;
    public static bool isPreta;

	// Use this for initialization
	void Start () {
        ui = GameObject.Find("Canvas").GetComponent<UI>();
        isPreta = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if(clicou == false)
            {
                ui.showE();

                if (Input.GetKeyDown(KeyCode.E))
                {
                    ui.showVictory();
                    clicou = true;
                    Player.varPause = true;
                    ui.hideE();
                    ui.cursorTrue();
                    
                }
            }
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            if(clicou == false)
            {
                ui.hideE();
            }
            


        }
    }
}
