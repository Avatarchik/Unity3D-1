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

    
    public GameObject NotAnyMore_ui;
    public GameObject UseNav_ui;
    public GameObject Destination_ui;
    public GameObject Touch;
    public GameObject Notice;
    public GameObject ChooseStar;
    public bool dragState = false;

    void Start()
    {
        if (_instance == null)
            _instance = this;
        
        if(GameObject.Find("WorldMapFlag") == null)
        {
            GameObject.Find("ReturnButton").gameObject.GetComponent<Button>().onClick.AddListener(() => gameObject.GetComponent<ButtonController>().TransSceneToMain());
        }
        else
        {
            
            UseNav_ui.SetActive(false);
            Touch.SetActive(true);
            Touch.transform.FindChild("Choose").gameObject.SetActive(false);
            Notice.SetActive(true);
            Notice.GetComponentInChildren<Text>().CrossFadeAlpha(-1, 8.0f, false);
            //버튼 함수의 동적 할당
            //onClick.AddListener(() => gameObject.GetComponent<ButtonController>().TransSceneToManage(파라미터)); 파라미터 사용시
            //onClick.AddListener(gameObject.GetComponent<ButtonController>().TransSceneToManage); 파라미터 미사용시
            GameObject.Find("ReturnButton").gameObject.GetComponent<Button>().onClick.AddListener(() => gameObject.GetComponent<ButtonController>().TransSceneToManage());
        }
        loadStar();
    }
    void loadStar()
    {
        SelectDB.Instance().table = "zodiacTable";
        SelectDB.Instance().column = "Count(*)";
        SelectDB.Instance().Select(0);
        for (int i = 1; i <= SelectDB.Instance().starCount; i++)
        {
            SelectDB.Instance().table = "zodiacTable";
            SelectDB.Instance().column = "rowid, open, find, active, zID";
            SelectDB.Instance().where = "WHERE \"rowid\" =" + i;
            SelectDB.Instance().Select(4);

            if (SelectDB.Instance().starActive == 0)
            {
                Debug.Log("@@@" + GameObject.Find(SelectDB.Instance().zodiacName).name);
                GameObject.Find(SelectDB.Instance().zodiacName).gameObject.GetComponent<SphereCollider>().enabled = true;
                GameObject.Find(SelectDB.Instance().zodiacName).gameObject.GetComponent<SphereCollider>().isTrigger = true;
            }
            else if (SelectDB.Instance().starActive == 1)
            {
                Debug.Log("###" + GameObject.Find(SelectDB.Instance().zodiacName).name);
                GameObject.Find(SelectDB.Instance().zodiacName).gameObject.GetComponent<SphereCollider>().enabled = false;
                GameObject.Find(SelectDB.Instance().zodiacName).gameObject.GetComponent<MeshRenderer>().enabled = false;

            }
        }
    }


}
