using UnityEngine;
using System.Collections;

public class EnemyPathWork : MonoBehaviour {

    bool SceneInit = true;


    void Awake()
    {
        SceneInit = false;
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

        Hashtable hash = new Hashtable();
        hash.Add("y", 100);
        iTween.MoveBy(GameObject.Find("Button").gameObject, hash);


        Debug.Log("Tween Complete : " + Time.realtimeSinceStartup);
    }
}
