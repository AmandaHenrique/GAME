using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class telaPreta : MonoBehaviour {

    Animator animator;
    private bool telaIsPreta;

      Menu menu;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        menu = GameObject.Find("Menu").GetComponent<Menu>();
    }
	
	// Update is called once per frame
	void Update () {
        telaIsPreta = swat.isPreta;

        if (telaIsPreta)
        {
            gameObject.SetActive(true);
            animator.SetBool("telaIsPreta", telaIsPreta);
            StartCoroutine(waitPreta());
        }
	}


    IEnumerator waitPreta()
    {
        yield return new WaitForSeconds(2.5f);
        menu.loadScene("MENU");
    }
}
