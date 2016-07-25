using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;

public class SelectDB : MonoBehaviour
{
    static SelectDB _instance = null;

    public static SelectDB Instance()
    {
        return _instance;
    }

    string m_ConnectionString;
    string m_SQLiteFileName = "CosmicDB.sqlite";
    [Tooltip("Columnname\nEx)zId,locationX")]
    public string column = " ";
    [Tooltip("Tablename\nEx)zodiacTable")]
    public string table = " ";
    [Tooltip("WHERE = 'column'\nEx)WHERE = 'rowid'")]
    public string where = " ";
    string sqlQuery;
    string conn;
    string zID;
    float x;
    float y;
    float z;

    int cntField;
    int cntTemp = 1;


    ///////////////////////////////////////////////////
    //데이터 임시 저장 변수(column)
    public Vector3 starPosition;
    public int planetIndex;
    public string planetName;
    public int planetSize;
    public int planetColor;
    public int planetMat;
    public int food;
    public int shipNum;
    public int planetCount;
    public int starCount;
    public int starRowid;
    public int starOpen;
    public int starFind;
    public int starActive;
    public string zodiacName;
    public string starName;
    public int tree1;
    public int tree2;
    public int tree3;
    public int tree4;
    public int tree5;
    public int tree6;
    ///////////////////////////////////////////////////


    void Awake()
    {
        if (_instance == null)
            _instance = this;
    }

    //type (1 : 별 위치 , 2 : 플레이어 정보, 3 : )
    public void Select(int type)
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

        /////////////////////////////////////////////////////////////////[DB Path]
        if (Application.platform == RuntimePlatform.Android)
        {
            conn = "URI=file:" + Application.persistentDataPath + "/CosmicDB.sqlite"; //Path to databse on Android
        }
        else
        {
            conn = "URI=file:" + Application.streamingAssetsPath + "/CosmicDB.sqlite";
        } //Path to database Else
          /////////////////////////////////////////////////////////////////[DB Path]
          //Debug.Log(conn);

        /////////////////////////////////////////////////////////////////[DB Connection]
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        /////////////////////////////////////////////////////////////////[DB Connection]

        /////////////////////////////////////////////////////////////////[SELECT Query]
        IDbCommand dbcmd = dbconn.CreateCommand();
        //string sqlCount = "SELECT Count(rowid) as Count " + "FROM zodiacTable";
        //dbcmd.CommandText = sqlCount;
        //IDataReader reader = dbcmd.ExecuteReader();
        //while (reader.Read())
        //{
        //    cntField = reader.GetInt32(0);
        //}
        //reader.Close();
        //reader = null;
        sqlQuery = "SELECT " + column + " FROM " + table + " " + where;
        Debug.Log(sqlQuery);
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        /////////////////////////////////////////////////////////////////[SELECT Query]


        /////////////////////////////////////////////////////////////////[Data Read]
        if (type == 0) // Count
        {
            while (reader.Read())
            {
                if (table == "managePlanetTable")
                    planetCount = reader.GetInt32(0);
                else if (table == "zodiacTable")
                    starCount = reader.GetInt32(0);
            }
            reader.Close();
            reader = null;
        }

        if (type == 1) // 별 좌표 
        {
            while (reader.Read())
            {
                x = reader.GetFloat(0);
                y = reader.GetFloat(1);
                z = reader.GetFloat(2);
                if (reader.GetString(3) != null && reader.GetString(4) != null)
                {
                    starName = reader.GetString(3);
                    zodiacName = reader.GetString(4);
                }
                starPosition = new Vector3(x, y, z);
            }
            reader.Close();
            reader = null;

        }
        if (type == 2) // 유저 보유 식량
        {
            while (reader.Read())
            {
                food = reader.GetInt16(0);
                shipNum = reader.GetInt16(1);
            }
            reader.Close();
            reader = null;
        }
        if (type == 3) // 행성 로드
        {
            if (reader.Read())
            {
                planetIndex = reader.GetInt16(0);
                planetName = reader.GetString(1);
                planetSize = reader.GetInt16(2);
                planetColor = reader.GetInt16(3);
                planetMat = reader.GetInt16(4);
                x = reader.GetFloat(5);
                y = reader.GetFloat(6);
                z = reader.GetFloat(7);
                if (reader.IsDBNull(8) == false)
                {
                    tree1 = reader.GetInt16(8);
                    tree2 = reader.GetInt16(9);
                    tree3 = reader.GetInt16(10);
                    tree4 = reader.GetInt16(11);
                    tree5 = reader.GetInt16(12);
                    tree6 = reader.GetInt16(13);
                }
                starPosition = new Vector3(x, y, z);
            }
            else
            {
                planetIndex = 0;
            }
            //Select 결과가 없을 경우 예외처리 필요

            reader.Close();
            reader = null;
        }
        if (type == 4) // 별 정보 PlanetCollisionCheck line: 66 에서 사용 
        {
            while (reader.Read())
            {
                starRowid = reader.GetInt32(0);
                starOpen = reader.GetInt32(1);
                starFind = reader.GetInt32(2);
                starActive = reader.GetInt32(3);
                if(reader.IsDBNull(4) == false)
                {
                    zodiacName = reader.GetString(4);
                }
            }
            reader.Close();
            reader = null;
        }


        /////////////////////////////////////////////////////////////////[Data Read]


        /////////////////////////////////////////////////////////////////[UPDATE Query]
        //string UpdatesqlQuery = "UPDATE zodiacTable SET \"locationX\" =" + x + ", \"locationY\" = " + y + ", \"locationZ\" = " + z + " WHERE  \"zID\" = '" + zID + "'";

        //Debug.Log(UpdatesqlQuery);
        //dbcmd.CommandText = UpdatesqlQuery;
        //dbcmd.ExecuteNonQuery();
        /////////////////////////////////////////////////////////////////[UPDATE Query]

        dbcmd.Dispose();
        dbcmd = null;
        /////////////////////////////////////////////////////////////////[DB Connection Close]
        dbconn.Close();
        dbconn = null;
        /////////////////////////////////////////////////////////////////[DB Connection Close]

    }


}