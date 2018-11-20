using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimations : MonoBehaviour {

    private Animator animator;
    public static bool shooting = false;
    public static bool isReload = false;
    public bool animationReload;

    public GameObject player;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();


    }
	
	// Update is called once per frame
	void Update () {
        leftClick();
        animator.SetBool("shooting", shooting);
        reload();
    }


    void leftClick()
    {
        if (Input.GetMouseButton(0) && Player.bullets > 0) 
        {
            shooting = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            shooting = false;
        }
    }
    
    void reload()
    {
        animationReload = Player.isReload;
        animator.SetBool("reload", animationReload);
    }
}
