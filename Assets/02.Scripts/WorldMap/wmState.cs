using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class wmState : MonoBehaviour {
    int maxFood;
    bool warning = false;
	
    void Update()
    {
        if (warning == false)
        {
            SelectDB.Instance().column = "cFood, shipNum";
            SelectDB.Instance().table = "userTable";
            //SelectDB.Instance().where = "WHERE zID= " + "'" + hit.transform.name + "'";
            SelectDB.Instance().Select(2);

            switch (SelectDB.Instance().shipNum)
            {
                case 1:
                    maxFood = 300;
                    break;
                case 2:
                    maxFood = 350;
                    break;
                case 3:
                    maxFood = 400;
                    break;
                case 4:
                    maxFood = 600;
                    break;
                case 5:
                    maxFood = 700;
                    break;
            }
            if (SelectDB.Instance().food < maxFood)
            {
                WorldMapManager.Instance().Warning_ui.SetActive(true);
                GameObject.Find("Food").gameObject.GetComponentInChildren<Text>().text = maxFood.ToString();
                StartCoroutine(returnMain());
            }
            warning = true;
        }
    }
	
    IEnumerator returnMain()
    {
        yield return new WaitForSeconds(1.0f);
        GameObject.Find("returnSec").gameObject.GetComponentInChildren<Text>().text = "2";
        yield return new WaitForSeconds(1.0f);
        GameObject.Find("returnSec").gameObject.GetComponentInChildren<Text>().text = "1";
        yield return new WaitForSeconds(1.0f);
        GameObject.Find("returnSec").gameObject.GetComponentInChildren<Text>().text = "0";
        GameObject.Find("WorldMapManager").gameObject.GetComponent<ButtonController>().TransSceneToMain();
    }
}
