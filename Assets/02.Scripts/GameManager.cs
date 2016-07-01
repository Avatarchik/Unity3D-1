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
