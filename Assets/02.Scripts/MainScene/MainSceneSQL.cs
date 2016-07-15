﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;


public class MainSceneSQL : MonoBehaviour {
    string m_ConnectionString;
    string m_SQLiteFileName = "CosmicDB.sqlite";
    string conn;

    public static IDbConnection dbconn;
    public static IDbCommand dbcmd;
    public static IDataReader reader;



    void Awake()
    {
#if UNITY_EDITOR
        m_ConnectionString = "URI=file:" + Application.streamingAssetsPath + "/" + m_SQLiteFileName;
        //m_ConnectionString = "URI=file:" + Application.dataPath + "/" + m_SQLiteFileName;
#else
            // check if file exists in Application.persistentDataPath
            var filepath = string.Format("{0}/{1}", Application.persistentDataPath, m_SQLiteFileName);

            if (!File.Exists(filepath))
            {
                // if it doesn't ->
                // open StreamingAssets directory and load the db ->

#if UNITY_ANDROID
                WWW loadDb = new WWW("jar:file://" + Application.dataPath + "!/assets/" + m_SQLiteFileName);  // this is the path to your StreamingAssets in android
                loadDb.bytesDownloaded.ToString();
                while (!loadDb.isDone) { }  // CAREFUL here, for safety reasons you shouldn't let this while loop unattended, place a timer and error check
                // then save to Application.persistentDataPath
                File.WriteAllBytes(filepath, loadDb.bytes);
#elif UNITY_IOS
                     var loadDb = Application.dataPath + "/Raw/" + m_SQLiteFileName;  // this is the path to your StreamingAssets in iOS
                    // then save to Application.persistentDataPath
                    File.Copy(loadDb, filepath);
#elif UNITY_WP8
                    var loadDb = Application.dataPath + "/StreamingAssets/" + m_SQLiteFileName;  // this is the path to your StreamingAssets in iOS
                    // then save to Application.persistentDataPath
                    File.Copy(loadDb, filepath);
#elif UNITY_WINRT
      var loadDb = Application.dataPath + "/StreamingAssets/" + m_SQLiteFileName;  // this is the path to your StreamingAssets in iOS
      // then save to Application.persistentDataPath
      File.Copy(loadDb, filepath);
#else
     var loadDb = Application.dataPath + "/StreamingAssets/" + m_SQLiteFileName;  // this is the path to your StreamingAssets in iOS
     // then save to Application.persistentDataPath
     File.Copy(loadDb, filepath);

#endif
            }

            m_ConnectionString = "URI=file:" + filepath;
#endif

        ///////////////////////////////////////////////////////////////////[DB Path]
        if (Application.platform == RuntimePlatform.Android)
        {
            conn = "URI=file:" + Application.persistentDataPath + "/CosmicDB.sqlite"; //Path to databse on Android
        }
        else { conn = "URI=file:" + Application.streamingAssetsPath + "/CosmicDB.sqlite"; } //Path to database Else
                                                                                            ///////////////////////////////////////////////////////////////////[DB Path]


        ///////////////////////////////////////////////////////////////////[DB Connection]
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        ///////////////////////////////////////////////////////////////////[DB Connection]

    }

    void Start()
    {
        ///////////////////////////////////////////////////////////////////[DB Query]
        dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT * FROM userTableTest";
        //string sqlQuery = "SLECT Sount(rowid) as Count FROM userTableTest";
        dbcmd.CommandText = sqlQuery;
        ///////////////////////////////////////////////////////////////////[DB Query]
        int cnt = 0;
        ///////////////////////////////////////////////////////////////////[Data Read]
        reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            MainSingleTon.Instance.cPlanet = reader.GetString(cnt++);
            MainSingleTon.Instance.cFood = reader.GetInt32(cnt++);
            MainSingleTon.Instance.cTitanium = reader.GetInt32(cnt++);
            MainSingleTon.Instance.cRE = reader.GetInt32(cnt++);
            MainSingleTon.Instance.cYE = reader.GetInt32(cnt++);
            MainSingleTon.Instance.cBE = reader.GetInt32(cnt++);
            MainSingleTon.Instance.cOE = reader.GetInt32(cnt++);
            MainSingleTon.Instance.cGE = reader.GetInt32(cnt++);
            MainSingleTon.Instance.cVE = reader.GetInt32(cnt++);
            MainSingleTon.Instance.cPE = reader.GetInt32(cnt++);
            MainSingleTon.Instance.shipNum = reader.GetInt32(cnt++);

        }
        reader.Close();
        reader = null;

        sqlQuery = "select pid, name, size, color,mFood, le_persec, mat, state,lFood, lTitanium,position_house,tree,neighbor from managePlanetTableTest where User =\"true\"";
        dbcmd.CommandText = sqlQuery;
        reader = dbcmd.ExecuteReader();
        cnt = 0;
        while (reader.Read())
        {
            MainSingleTon.Instance.pID = reader.GetString(cnt++);
            MainSingleTon.Instance.pName = reader.GetString(cnt++);
            MainSingleTon.Instance.size = reader.GetInt32(cnt++);
            MainSingleTon.Instance.color = reader.GetInt32(cnt++);
            MainSingleTon.Instance.mFood = reader.GetInt32(cnt++);
            MainSingleTon.Instance.le_persec = reader.GetInt32(cnt++);
            MainSingleTon.Instance.mat = reader.GetInt32(cnt++);
            MainSingleTon.Instance.state = reader.GetInt32(cnt++);
            MainSingleTon.Instance.lFood = reader.GetInt32(cnt++);
            MainSingleTon.Instance.lTitanium = reader.GetInt32(cnt++);
            MainSingleTon.Instance.position_house = reader.GetBoolean(cnt++);
            MainSingleTon.Instance.tree = reader.GetInt32(cnt++);
            //MainSingleTon.Instance.user = reader.GetBoolean(cnt++);
            MainSingleTon.Instance.neighbor = reader.GetInt32(cnt++);
        }

        reader.Close();
        reader = null;


        //dbClose();
    }



    void dbClose()
    {
        ///////////////////////////////////////////////////////////////////[DB Connection Close]
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
        ///////////////////////////////////////////////////////////////////[DB Connection Close]
    }

}