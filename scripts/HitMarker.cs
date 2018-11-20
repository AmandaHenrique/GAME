using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitMarker : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, 1f);
    }
	
	// Update is called once per frame
	void Update () {
        //StartCoroutine(WaitHitMarker());
    }

    /*IEnumerator WaitHitMarker()
    {
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);
    }*/
}
