using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WarningFoward : MonoBehaviour {

    void Update()
    {
        touchText();
    }

    void touchText()
    {
        //Debug.Log(gameObject.GetComponent<Image>().canvasRenderer.GetAlpha());

        if (gameObject.GetComponent<Text>().canvasRenderer.GetAlpha() == 1)
            gameObject.GetComponent<Text>().CrossFadeAlpha(0, 1.5f, false);

        if (gameObject.GetComponent<Text>().canvasRenderer.GetAlpha() == 0)
        {
            gameObject.GetComponent<Text>().CrossFadeAlpha(1, 2.5f, true);
        }
    }
}
