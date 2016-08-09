using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyPathWork : MonoBehaviour {

    bool SceneInit = true;
    bool endMove = true;

    void Awake()
    {
        SceneInit = false;
        endMove = false;
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
        if (endMove == true)
        {
            Debug.Log("@#@#@");
            Hashtable hash2 = new Hashtable();
            hash2.Add("from", 0);
            hash2.Add("to", 0.25f);
            hash2.Add("time", 1.0f);
            hash2.Add("onupdate", "ValueToUpdate");
            iTween.ValueTo(GameObject.Find("GameCount").gameObject, hash2);
            endMove = false;
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

        Debug.Log("#####");

        endMove = true;

        Debug.Log("Tween Complete : " + Time.realtimeSinceStartup);
    }

    void ValueToUpdate(float updateValue)
    {
        Debug.Log("@@@@"+updateValue);
        GameObject.Find("GameCount").gameObject.GetComponent<Slider>().value = updateValue;
    }
}
