using UnityEngine;
using System.Collections;


public class AlertMove : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {
        if (GameManager.Instance().alertUi.activeSelf == true)
        {
            Hashtable hash = new Hashtable();
            hash.Add("y", -35);
            hash.Add("looktime", 1.0f);
            hash.Add("time", 5.0f);
            //hash.Add("easetype", iTween.EaseType.easeInOutExpo);

            iTween.MoveBy(gameObject, hash);
        }

    }
}
