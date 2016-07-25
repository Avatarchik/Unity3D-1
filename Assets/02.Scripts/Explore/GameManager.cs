using UnityEngine;
using UnityEngine.UI;
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
    public bool scInit = false;         //SpaceCollision Init
    public bool spaceCollision = true;  
    public GameObject destination;
    public GameObject navUi_des;
    public GameObject navUi_player;
    public GameObject alertUi;
    public GameObject exploreUi;
    public GameObject noMorePS;
    public string PlanetName;
    public Vector3 rotShip;
    public int rotRate;
    int itweenCnt;
    
    void Awake()
    {
        switch (GameData.Instance().shipNum)
        {
            case 1:
                GameObject.Find("Ship_1").gameObject.SetActive(true);
                break;
            case 2:
                GameObject.Find("Ship_2").gameObject.SetActive(true);
                break;
            case 3:
                GameObject.Find("Ship_3").gameObject.SetActive(true);
                break;
            case 4:
                GameObject.Find("Ship_4").gameObject.SetActive(true);
                break;
            case 5:
                GameObject.Find("Ship_5").gameObject.SetActive(true);
                break;
        }
    }

    void Start()
    {
        if (_instance == null)
            _instance = this;
    }


    void Update()
    {
        itweenCnt = iTween.Count();
        if (itweenCnt != 0 && GameObject.Find("MobileJoystick").GetComponent<Image>().enabled == true)
        {
            Debug.Log(iTween.Count());
            GameObject.Find("MobileJoystick").GetComponent<Image>().enabled = false;
        }
        
        else if (itweenCnt == 0 && GameObject.Find("MobileJoystick").GetComponent<Image>().enabled == false)
        {
            GameObject.Find("MobileJoystick").GetComponent<Image>().enabled = true;
        }
    }
}
