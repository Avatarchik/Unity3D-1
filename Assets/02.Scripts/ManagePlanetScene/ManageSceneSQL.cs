using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;

public class ManageSceneSQL : MonoBehaviour {

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
        settingInfo();

    }

    void settingInfo()
    {
        ///////////////////////////////////////////////////////////////////[DB Query]
        dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT count(*) FROM managePlanetTableTest";
        dbcmd.CommandText = sqlQuery;
        ///////////////////////////////////////////////////////////////////[DB Query]
        int cnt = 0;
        ///////////////////////////////////////////////////////////////////[Data Read]
        reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            MovePlanet.Instance.planetCount = reader.GetInt32(cnt++);
        }

        //MovePlanet.Instance.getPlanets();

        reader.Close();
        reader = null;

        //sqlQuery = "select * from managePlanetTableTest where rowid = " + MainSingleTon.Instance.cPlanet;
        sqlQuery = "select rowid, name, size, color, mat, mFood, mTitanium, locationX, locationY, locationZ, le_persec, position_house, state, user, neighbor, lFood, lTitanium, tree1, tree2, tree3, tree4, tree5, tree6 FROM managePlanetTableTest ";
        dbcmd.CommandText = sqlQuery;
        reader = dbcmd.ExecuteReader();
        cnt = 0;
        while (reader.Read())
        {
            int rowid = reader.GetInt32(cnt++);
            string pName = reader.GetString(cnt++);
            int size = reader.GetInt32(cnt++);
            int color = reader.GetInt32(cnt++);
            int mat = reader.GetInt32(cnt++);
            int mFood = reader.GetInt32(cnt++);
            int mTitanium = reader.GetInt32(cnt++);
            float locationX = reader.GetFloat(cnt++);
            float locationY = reader.GetFloat(cnt++);
            float locationZ = reader.GetFloat(cnt++);
            int le_persec = reader.GetInt32(cnt++);
            bool position_house = reader.GetBoolean(cnt++);
            int state = reader.GetInt32(cnt++);
            bool user = reader.GetBoolean(cnt++);
            int neighbor = reader.GetInt32(cnt++);
            int lFood = reader.GetInt32(cnt++);
            int lTitanium = reader.GetInt32(cnt++);

            //MainSingleTon.Instance.planetTouchT = ;
            //MainSingleTon.Instance.titaniumTouchT = ;
            //MainSingleTon.Instance.treeTouchT = ;
            //MainSingleTon.Instance.breaktime = ;

            int tree1 = reader.GetInt32(cnt++);
            int tree2 = reader.GetInt32(cnt++);
            int tree3 = reader.GetInt32(cnt++);
            int tree4 = reader.GetInt32(cnt++);
            int tree5 = reader.GetInt32(cnt++);
            int tree6 = reader.GetInt32(cnt++);

            MovePlanet.Instance.getPlanets(color, size, mat, rowid);

            GameObject.Find("RotatePlanet/" + rowid).GetComponent<PlanetInfo>().rowid = rowid;
            GameObject.Find("RotatePlanet/" + rowid).GetComponent<PlanetInfo>().pName = pName;
            GameObject.Find("RotatePlanet/" + rowid).GetComponent<PlanetInfo>().size = size;
            GameObject.Find("RotatePlanet/" + rowid).GetComponent<PlanetInfo>().color = color;
            GameObject.Find("RotatePlanet/" + rowid).GetComponent<PlanetInfo>().mat = mat;
            GameObject.Find("RotatePlanet/" + rowid).GetComponent<PlanetInfo>().mFood = mFood;
            GameObject.Find("RotatePlanet/" + rowid).GetComponent<PlanetInfo>().mTitanium = mTitanium;
            GameObject.Find("RotatePlanet/" + rowid).GetComponent<PlanetInfo>().locationX = locationX;
            GameObject.Find("RotatePlanet/" + rowid).GetComponent<PlanetInfo>().locationY = locationY;
            GameObject.Find("RotatePlanet/" + rowid).GetComponent<PlanetInfo>().locationZ = locationZ;
            GameObject.Find("RotatePlanet/" + rowid).GetComponent<PlanetInfo>().le_persec = le_persec;
            GameObject.Find("RotatePlanet/" + rowid).GetComponent<PlanetInfo>().position_house = position_house;
            GameObject.Find("RotatePlanet/" + rowid).GetComponent<PlanetInfo>().state = state;
            GameObject.Find("RotatePlanet/" + rowid).GetComponent<PlanetInfo>().user = user;
            GameObject.Find("RotatePlanet/" + rowid).GetComponent<PlanetInfo>().neighbor = neighbor;
            GameObject.Find("RotatePlanet/" + rowid).GetComponent<PlanetInfo>().lFood = lFood;
            GameObject.Find("RotatePlanet/" + rowid).GetComponent<PlanetInfo>().lTitanium = lTitanium;
            GameObject.Find("RotatePlanet/" + rowid).GetComponent<PlanetInfo>().tree1 = tree1;
            GameObject.Find("RotatePlanet/" + rowid).GetComponent<PlanetInfo>().tree2 = tree2;
            GameObject.Find("RotatePlanet/" + rowid).GetComponent<PlanetInfo>().tree3 = tree3;
            GameObject.Find("RotatePlanet/" + rowid).GetComponent<PlanetInfo>().tree4 = tree4;
            GameObject.Find("RotatePlanet/" + rowid).GetComponent<PlanetInfo>().tree5 = tree5;
            GameObject.Find("RotatePlanet/" + rowid).GetComponent<PlanetInfo>().tree6 = tree6;
            cnt = 0;
        }
        MovePlanet.Instance.setPlanets();
    }



    public void UpdateQuery(string ShipQuery)
    {
        dbcmd.CommandText = ShipQuery;
        dbcmd.ExecuteNonQuery();

        settingInfo();

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
