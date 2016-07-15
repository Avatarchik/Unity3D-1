using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class MainSingleTon : MonoBehaviour {

    static MainSingleTon _instance = null;

    public static MainSingleTon Instance
    {
        get
        {
            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
            _instance = this;
        
    }


    public string cPlanet;
    public int cFood;
    public int cTitanium;
    public int cRE;
    public int cYE;
    public int cBE;
    public int cOE;
    public int cGE;
    public int cVE;
    public int cPE;
    public int shipNum;


    public string pID;
    public string pName;
    public int size;
    public int color;
    public int mFood;
    public int le_persec;
    public int mat;
    public int state;
    public int lFood;
    public int lTitanium;
    public bool position_house;
    public int tree;
    //public bool user;
    public int neighbor;

    public GameObject UIobj;

    public bool activeFusionPanal = false;

    void Start()
    {
        UIobj.GetComponent<MainUIfromSQL>().setPlanet();
    }
    
    void Update()
    {
        UIobj.GetComponent<MainUIfromSQL>().setUIText();
        if (activeFusionPanal) 
        {
            UIobj.GetComponent<FusionScript>().setText();

        }
    }
}
