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
    public bool scInit;         //SpaceCollision Init
    public bool spaceCollision = true;  
    public GameObject destination;
    public GameObject navUi_des;
    public GameObject navUi_player;
    public GameObject alertUi;
    public GameObject exploreUi;
    public GameObject exploreUi_star;
    public GameObject noMorePS;
    public GameObject Warning_collision;
    public string PlanetName;
    public int spentFuel;
    public Vector3 rotShip;
    public int rotRate;
    int itweenCnt;
    
    void Awake()
    {
      
    }

    void Start()
    {
        if (_instance == null)
            _instance = this;

        scInit = true;
        GameObject.Find("Ship").transform.FindChild("Ship_" + GameData.Instance().shipNum).gameObject.SetActive(true);
    }


    void Update()
    {
        itweenCnt = iTween.Count();
        if (itweenCnt != 0 && GameObject.Find("MobileJoystick").GetComponent<Image>().enabled == true)
        {
            Debug.Log(iTween.Count());
            GameObject.Find("MobileJoystick").GetComponent<Image>().enabled = false;
            GameManager.Instance().Warning_collision.SetActive(true);
        }
        
        else if (itweenCnt == 0 && GameObject.Find("MobileJoystick").GetComponent<Image>().enabled == false)
        {
            GameObject.Find("MobileJoystick").GetComponent<Image>().enabled = true;
            GameManager.Instance().Warning_collision.SetActive(false);
        }
    }
}
