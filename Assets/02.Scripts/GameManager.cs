using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    static GameManager _instance = null;

    public static GameManager Instance()
    {
        return _instance;
    }

    //Singleton Variable 

    //Planet Management
    

    //Explore Scene
    public GameObject player;
    public GameObject tempPlanet;
    public Vector3 planetSpawnPoint;
    public GameObject spaceChecker;
    public bool spaceCollision = false;
    public GameObject destination;
    public GameObject navUi_des;
    public GameObject navUi_player;
    public GameObject alertUi;
    public GameObject exploreUi;

    

    void Start()
    {
        if (_instance == null)
            _instance = this;
    }
}
