using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class csPlanetPanalSet : MonoBehaviour {


    public static int PlanetCount;
    public static int nowPlanetNum = 1;

    GameObject PlanetExPanal;
    Text txt;



    void Start()
    {
        PlanetExPanal = GameObject.Find("UI/ManagePlanet_ui/PlanetEx");
        txt = GameObject.Find("UI/ManagePlanet_ui/PlanetEx/Text").GetComponent<Text>();
        PlanetCount = MovePlanet.Instance.planets.Count;
        setPanalVisible();
        ChangeText();
    }

    void Update()
    {
        

    }

    public void setPanalVisible()
    {
        PlanetExPanal.gameObject.SetActive(true);
    }
    
    public void setPanalNotVisible()
    {
        PlanetExPanal.gameObject.SetActive(false);
    }

    public void ChangeText()
    {
        string temp = nowPlanetNum + "번째 행성";
        txt.text = temp;
    }
}
