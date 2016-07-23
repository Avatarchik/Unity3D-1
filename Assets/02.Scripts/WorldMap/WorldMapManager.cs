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
        
    }
    

}
