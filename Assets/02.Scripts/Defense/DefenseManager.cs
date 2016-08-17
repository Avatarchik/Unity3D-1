using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DefenseManager : MonoBehaviour {
    
    static DefenseManager _instance = null;

    public static DefenseManager Instance()
    {
        return _instance;
    }

    void Awake()
    {

    }

    public GameObject EnemyPathWork;
    bool roundInit;
    void Start()
    {
        if (_instance == null)
            _instance = this;

        roundInit = false;
        GameObject.Find("Ship").transform.FindChild("Ship_" + GameData.Instance().shipNum).gameObject.SetActive(true);
    }

    void Update()
    {
        if (EnemyPathWork.gameObject.GetComponent<EnemyPathWork>().endMove == true && roundInit == false && gameObject.GetComponent<RPSScript>().inputCnt == 5 && EnemyPathWork.gameObject.GetComponent<EnemyPathWork>().nt_sel == false)
        {
            Hashtable hash = new Hashtable();
            hash.Add("x", 1);
            hash.Add("y", 1);
            hash.Add("z", 1);
            //hash.Add("looktime", 1.0f);
            hash.Add("time", 1.0f);

            iTween.ScaleTo(GameObject.Find("btn_round").gameObject, hash);

            GameObject.Find("btn_round").gameObject.GetComponent<Button>().interactable = true;
            roundInit = true;
        }
        
    }
}
