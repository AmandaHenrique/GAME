using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Marca : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        StartCoroutine(openMenu());
    }

    private IEnumerator openMenu()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("MENU");
    }
}

