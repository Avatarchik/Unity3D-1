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

        if (gameObject.GetComponent<Image>().canvasRenderer.GetAlpha() == 1)
            gameObject.GetComponent<Image>().CrossFadeAlpha(0, 1.5f, false);

        if (gameObject.GetComponent<Image>().canvasRenderer.GetAlpha() == 0)
        {
            gameObject.GetComponent<Image>().CrossFadeAlpha(1, 2.5f, true);
        }
    }
}
