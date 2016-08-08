using UnityEngine;
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

    public GameObject ship;

    void Start()
    {
        if (_instance == null)
            _instance = this;

        GameObject.Find("Ship").transform.FindChild("Ship_" + GameData.Instance().shipNum).gameObject.SetActive(true);
    }

    void Update()
    {
        
    }
}
