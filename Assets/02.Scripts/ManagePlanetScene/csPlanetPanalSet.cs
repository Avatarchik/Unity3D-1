using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class csPlanetPanalSet : MonoBehaviour {


    public static int PlanetCount;

    GameObject PlanetExPanal;
    Text txt;

    public GameObject deleteBtn;

    void Start()
    {
        PlanetExPanal = GameObject.Find("UI/PlanetEx");
        txt = GameObject.Find("UI/PlanetEx/Text").GetComponent<Text>();
        PlanetCount = MovePlanet.Instance.planets.Count;
        setPanalVisible();
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

    public void ChangeText(string pName)
    {
        txt.text = pName;
    }

    public void setVisibleBtn()
    {
        deleteBtn.SetActive(true);
    }

    public void notVisibleBtn()
    {
        deleteBtn.SetActive(false);
    }

}
