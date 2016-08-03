using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Loading : MonoBehaviour {

    public Text progressLabel;


    // Use this for initialization
	void Start () {
        StartCoroutine(Load());
	}
	
    IEnumerator Load()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync("main");

        while (!async.isDone)
        {
            float progress = async.progress * 100.0f;
            int pRounded = Mathf.RoundToInt(progress);
            progressLabel.text = "loading..." + pRounded.ToString() + "%";

            yield return true;
        }
    }

}
