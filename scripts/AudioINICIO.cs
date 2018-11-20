using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioINICIO : MonoBehaviour {
    public static bool tocando = true;

    void Awake()
    {
        GameObject[] sounds = GameObject.FindGameObjectsWithTag("music1");
        if(sounds.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if (tocando == false)
        {
            Destroy(this.gameObject);
        }
    }
}
