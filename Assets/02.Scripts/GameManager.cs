using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    static GameManager _instance = null;

    public static GameManager Instance()
    {
        return _instance;
    }

    //Singleton Variable 
    public GameObject exploreUi;
    public GameObject player;
    public GameObject destination;
    public GameObject navUi_des;
    public GameObject navUi_player;

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
