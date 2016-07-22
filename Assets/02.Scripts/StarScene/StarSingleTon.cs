using UnityEngine;
using System.Collections;

public class StarSingleTon : MonoBehaviour {

    static StarSingleTon _instance = null;

    public static StarSingleTon Instance
    {
        get
        {
            return _instance;
        }
    }
    //color) 1= blue, 2= red , 3= yellow, 4= violate, 5= green, 6 = Orange
    //size) 1= small, 2 = midium, 3= large, 4= xlarge
    //mat ) 1= 1, 2=2, 3=3
    //list입력관련 (Color)(Size)(Mat) -> 변경순서mat->size->color

    void Awake()
    {
        rowid = GameObject.Find("OBJ").GetComponent<OBJScript>().rowid;
        if (_instance == null)
            _instance = this;


    }


    public int cPlanet;
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


    public int rowid;
    public string zID;
    public string zodiac;
    public string zName;
    public Vector3 location = new Vector3();
    public bool zOpen;
    public bool zFind;
    public int needPE;
    public int nowPE;
    public bool zActive;




}
