using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class getEnergyTextScript : MonoBehaviour {


    float outTime = 3;
    //float delTime = 5;
    float count = 0;
    int fontsize = 60;

    void Update()
    {
        count += 0.5f;
        if (count >= 1)
        {
            count = 0;
            fontsize--;
            if (fontsize <= 2)
            {
                Destroy(this.gameObject);
            }
            this.GetComponent<Text>().fontSize = fontsize;


        }

    }

    public void setText(string tex)
    {
        this.GetComponent<Text>().text = tex;
    }

}
