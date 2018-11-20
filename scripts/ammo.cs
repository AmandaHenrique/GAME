using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ammo : MonoBehaviour {

    private UI ui;
    AudioSource audio;
    public static bool clickE;

	// Use this for initialization
	void Start () {
        audio = GameObject.Find("soundAmmo").GetComponent<AudioSource>();
        ui = GameObject.Find("Canvas").GetComponent<UI>();

	}
	
	// Update is called once per frame
	void Update () { 

	}

    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            ui.showE();
            clickE = true;
            if (Input.GetKey(KeyCode.E))
            {
                audio.Play();
                Player.yourBullets += 40;
                ui.hideE();
                ui.updateBullets(Player.bullets, Player.yourBullets);
                StartCoroutine(waitAmmo());
                Destroy(this.gameObject);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            ui.hideE();
        }
    }


    IEnumerator waitAmmo()
    {
        yield return new WaitForSeconds(0.1f);
    }
}