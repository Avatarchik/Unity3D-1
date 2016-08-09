using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DefenseGauge : MonoBehaviour {

    //Color 는 0-1 값을 사용함
    Color myColor = Color.green;
    bool initGauge = true;

    void Start()
    {
        initGauge = false;
    }

	void Update () {
	    if(initGauge == false)
        {
            GetComponent<Image>().color = Color.white;
            myColor = GetComponent<Image>().color;
            Hashtable hash = new Hashtable();

            hash.Add("from", 60.0f);
            hash.Add("to", 255.0f);
            hash.Add("time", 2.0f);
            hash.Add("looptype", "loop");
            hash.Add("onupdate", "ValueToUpdate");

            iTween.ValueTo(gameObject, hash);
            initGauge = true;
        }
	}

    void ValueToUpdate(float updateValue)
    {
        //Debug.Log(updateValue + ", color : " + myColor.g);

        myColor.b = (255.0f - updateValue) / 255.0f;
        GetComponent<Image>().color = myColor;
    }
}
