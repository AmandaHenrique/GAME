using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class load : MonoBehaviour {

    private bool loadScene;
    public string scene;
    //public Slider slider;
    public GameObject allLoading;
    //public Text porcento;

    void Start()
    {
        //slider.gameObject.SetActive(false);
        allLoading.SetActive(false);
    }

    void Update()
    {
        if (Menu.clickPlay && loadScene == false)
        {
            loadScene = true;
            allLoading.SetActive(true);
            //slider.gameObject.SetActive(true);
            StartCoroutine(loadNewScene(scene));
            Menu.clickPlay = false;
        }
    }

    IEnumerator loadNewScene(string scene)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(scene);
        while (!async.isDone)
        {
            float progress = Mathf.Clamp01(async.progress / 0.9f);
            //slider.value = progress;
            //porcento.text = progress * 100f + " %";
            yield return null;
        }
    }
}
