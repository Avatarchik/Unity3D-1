using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    static GameManager _instance = null;

    public static GameManager Instance()
    {
        return _instance;
    }

    //Singleton Variable 
    
    //Common
    public GameObject player;

    //Explore Scene
    public GameObject spaceChecker;
    public bool spaceCollision = false;
    public GameObject destination;
    public GameObject navUi_des;
    public GameObject navUi_player;
    public GameObject exploreUi;

    void Start()
    {
        if (_instance == null)
            _instance = this;
    }
    
    //public GameObject exUiget()
    //{
    //    return exploreUi;
    //}


}
