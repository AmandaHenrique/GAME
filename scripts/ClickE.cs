using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickE : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (ammo.clickE)
        {
            gameObject.SetActive(true);
        }
        
	}
}
