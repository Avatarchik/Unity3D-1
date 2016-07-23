using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WorldMapManager : MonoBehaviour
{

    static WorldMapManager _instance = null;

    public static WorldMapManager Instance()
    {
        return _instance;
    }

    public GameObject Warning_ui;
    public GameObject NotAnyMore_ui;
    public GameObject UseNav_ui;
    public GameObject Destination_ui;
    public GameObject Touch;
    public GameObject Notice;
    public bool dragState = false;

    void Start()
    {
        if (_instance == null)
            _instance = this;
        
    }

}
