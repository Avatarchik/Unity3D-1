using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlanetListMain : MonoBehaviour {

    static PlanetListMain _instance = null;

    public static PlanetListMain Instance
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
    public List<GameObject> planetList = new List<GameObject>();
    public Dictionary<int, GameObject> DictionaryPlanet = new Dictionary<int, GameObject>();

    //size) 1= small, 2 = midium, 3= large, 4= xlarge
    //color) 1= blue, 2= red , 3= yellow, 4= violate, 5= green, 6 = gren
    //mat ) 1= 1, 2=2, 3=3
    //list입력관련 (size)(color)(mat) -> 변경순서mat->size->color


    void Start()
    {
        //PlanetPosition = GameObject.Find("PlanetPosition");
        //DictionaryPlanet.Add(111, planetList[0]);
        //Debug.Log(planetList[0]);
        //Debug.Log(DictionaryPlanet["111"]);
        //Debug.Log(DictionaryPlanet[])
        //Debug.Log(DictionaryPlanet[0]);
        //Pla = Instantiate(DictionaryPlanet[111], PlanetPosition.transform.position, PlanetPosition.transform.rotation) as GameObject;
        //Pla.name = "death_planet";
        //Pla.transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
        //Pla.transform.parent = PlanetPosition.transform;
    }
    
}
