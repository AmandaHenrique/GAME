using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse : MonoBehaviour {
    //float speed = 3f;
    // Use this for initialization
    private Player player;

	void Start () {
        player = GameObject.Find("Player").GetComponent <Player>();
        Cursor.visible = false;

        //trava o cursor no meio da tela /da mira
        Cursor.lockState = CursorLockMode.Locked; 
	}
	
	// Update is called once per frame
	void Update () {
        MouseX();
        MouseY();
        CursorTrue();
        CameraMouse();

    }
    void MouseX()
    {
        if(Player.varPause == false)
        {
            float mouseX = Input.GetAxis("Mouse X");
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x,
                                                    transform.localEulerAngles.y + mouseX,
                                                    transform.localEulerAngles.z);

        }

    }
    void MouseY()
    {
        if(Player.varPause == false)
        {
            float mouseY = Input.GetAxis("Mouse Y");
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x + (-mouseY),
                                                    transform.localEulerAngles.y,
                                                    transform.localEulerAngles.z);
        }
        
    }

    void CursorTrue()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None; //destrava o cursor
        }
    }

    void CameraMouse()
    {
        if (Player.varPause)
        {
            player.enabled = false;
        }
        else if(Player.varPause == false)
        {
            player.enabled = true;
        }
    }


}
