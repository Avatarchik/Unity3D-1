using UnityEngine;
using System.Collections;

public class getTextScript : MonoBehaviour {

    float outTime = 3;
    //float delTime = 5;
    float count = 0;
    int fontsize = 30;
    void Start()
    {
    }
    
    void Update()
    {
        count += 0.5f;
        if(count >= 1)
        {
            count = 0;
            fontsize--;
            this.GetComponent<TextMesh>().fontSize = fontsize;

            if(fontsize ==0)
            {
                Destroy(this.gameObject);
            }
        }

    }

    public void setText(string tex)
    {
        this.GetComponent<TextMesh>().text = tex;
    }
}
