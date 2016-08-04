using UnityEngine;
using System.Collections;

public class missileGameManager : MonoBehaviour {

    static missileGameManager _instance = null;

    public static missileGameManager Instance()
    {
        return _instance;
    }

    public Vector3 enemyLastDir = new Vector3(0.0f, 0.0f, 0.0f);
    public bool lockOn = false;

    void Start()
    {
        if (_instance == null)
            _instance = this;
        lockOn = false;
    }


    public void targetLastDir(Vector3 position)
    {
        enemyLastDir = position;
    }

    public void lockOnStatus(bool status)
    {
        lockOn = status;
    }

}
