using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class MainUIfromSQL : MonoBehaviour {


    public GameObject haveFood;
    public GameObject haveTitanium;
    public GameObject havePEEnergy;
    public GameObject PlanetName;
    public GameObject leftFood;
    public GameObject leftTitanium;
    public GameObject singleTon;
    public GameObject PlanetList;
    public GameObject PlanetPosition;
    

    public GameObject Planet; // 수정해야함 -> DB에서 리스트 읽어서 해당행성 불러올 수 있도록
    GameObject Pla;

    public void setUIText()
    {
        haveFood.GetComponent<Text>().text = singleTon.GetComponent<MainSingleTon>().cFood + "";
        haveTitanium.GetComponent<Text>().text = singleTon.GetComponent<MainSingleTon>().cTitanium + "";
        havePEEnergy.GetComponent<Text>().text = singleTon.GetComponent<MainSingleTon>().cPE + "";
        PlanetName.GetComponent<Text>().text = singleTon.GetComponent<MainSingleTon>().pName;
        leftFood.GetComponent<Text>().text = singleTon.GetComponent<MainSingleTon>().lFood + "";
        leftTitanium.GetComponent<Text>().text = singleTon.GetComponent<MainSingleTon>().lTitanium + "";

    }

    public void setPlanet()
    {
        Pla = Instantiate(Planet, PlanetPosition.transform.position, PlanetPosition.transform.rotation) as GameObject;
        Pla.name = "death_planet";
        Pla.transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
        Pla.transform.parent = PlanetPosition.transform;
    }
}
