using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyPathWork : MonoBehaviour {

    public GameObject slider;
    public GameObject sliderFill;
    public GameObject notice_Select;

    bool SceneInit = true;
    public bool endMove = true;
    float changedGauge;
    void Awake()
    {
        SceneInit = false;
        endMove = false;
    }

    void Start()
    {
        slider.GetComponent<Slider>().onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        

    }

    void Update()
    {
        if (SceneInit == false)
        {
            Hashtable hash = new Hashtable();

            hash.Add("path", iTweenPath.GetPath("EnemyPath"));
            hash.Add("movetopath", true);
            hash.Add("orienttopath", true);
            hash.Add("looktime", 3.0f);
            hash.Add("time", 12.0f);
            hash.Add("easetype", iTween.EaseType.easeOutExpo);
            hash.Add("looptype", iTween.LoopType.none);

            //hash.Add("onstart", "ItweenStart");
            //hash.Add("onstarttarget", gameObject);

            //hash.Add("onupdate", "ItweenUpdate");
            //hash.Add("onupdatetarget", gameObject);

            hash.Add("oncomplete", "ItweenComplete");
            hash.Add("oncompletetarget", gameObject);

            iTween.MoveTo(gameObject, hash);
            SceneInit = true;
        }
        
        if(sliderFill.activeSelf == true)
        {
            GaugeInit(); 
        }
        
    }

    void ItweenStart()
    {
        Debug.Log("Tween Start : " + Time.realtimeSinceStartup);
    }

    void ItweenUpdate()
    {
        Debug.Log("Tween Update : " + Time.realtimeSinceStartup);
    }

    void ItweenComplete()
    {
        // itween을 이용하여 엔진 점점 줄어드는것으로 수정 필요
        for(int i = 1; i<6;i++)
        {
            gameObject.transform.FindChild("AirFighter_" + i).FindChild("Engine").transform.localScale = new Vector3(1, 1, 0.5f);
        }

        //UI 배치
        Hashtable hash = new Hashtable();
        hash.Add("y", 80);
        iTween.MoveBy(GameObject.Find("Button").gameObject, hash);

        //UI 배치
        Hashtable hash2 = new Hashtable();
        hash2.Add("y", -40);
        iTween.MoveBy(GameObject.Find("GameCount").gameObject, hash2);


        //UI 배치
        Hashtable hash3 = new Hashtable();
        hash3.Add("x", 1);
        hash3.Add("y", 1);
        hash3.Add("z", 1);
        hash3.Add("time", 0.5);
        iTween.ScaleTo(notice_Select, hash3);

        StartCoroutine(disableNotice());

        sliderFill.SetActive(true);
        endMove = true;

        Debug.Log("Tween Complete : " + Time.realtimeSinceStartup);
    }

    void ValueChangeCheck()
    {
        changedGauge = slider.GetComponent<Slider>().value;
    }

    void GaugeInit()
    {
        //Debug.Log("changedGauge"+changedGauge);
        if(changedGauge <= (0.20f* GameObject.Find("GameManager").GetComponent<RPSScript>().round))
        {
            slider.GetComponent<Slider>().value += 0.01f;
        }
    }

    IEnumerator disableNotice()
    {
        Debug.Log("!!");
        yield return new WaitForSeconds(4.0f);
        noticeFalse();
    }

    void noticeFalse()
    {
        notice_Select.SetActive(false);
    }
}
