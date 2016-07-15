﻿using UnityEngine;
using System.Collections;

public class GameData : MonoBehaviour {

    static GameData _instance = null;

    public static GameData Instance()
    {
        return _instance;
    }

    public Vector3 starPosition;
    public bool navOn = false;

    void Start()
    {
        if (_instance == null)
            _instance = this;
    }
    
}
