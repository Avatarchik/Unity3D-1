using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;

public class UpdateDB : MonoBehaviour
{
    public GameObject star;
    float x;
    float y;
    float z;
    string zID;

    void Start()
    {
        string m_ConnectionString;
        string m_SQLiteFileName = "CosmicDB.sqlite";
        string conn;
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
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        ///////////////////////////////////////////////////////////////////[DB Connection]


        ///////////////////////////////////////////////////////////////////[DB Query]
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT rowid, * " + "FROM zodiacTable";
        dbcmd.CommandText = sqlQuery;
        ///////////////////////////////////////////////////////////////////[DB Query]

        ///////////////////////////////////////////////////////////////////[Data Read]
        IDataReader reader = dbcmd.ExecuteReader();

        while (reader.Read())
        {
            //if (reader.GetInt32(0) == 1)
            //{
                
                int rowid = reader.GetInt32(0);
                Debug.Log(rowid);
                zID = reader.GetString(1);
                Debug.Log(zID);
                Debug.Log(GameObject.Find(zID).gameObject.transform.position);
                x = GameObject.Find(zID).gameObject.transform.position.x;
                y = GameObject.Find(zID).gameObject.transform.position.y;
                z = GameObject.Find(zID).gameObject.transform.position.z;

            //string zodiac = reader.GetString(2);
            //Debug.Log(zodiac);
            //string name = reader.GetString(3);
            //Debug.Log(name);
            //float locationX = reader.GetFloat(4);
            //Debug.Log(locationX);
            //float locationY = reader.GetFloat(5);
            //Debug.Log(locationY);
            //float locationZ = reader.GetFloat(6);
            //Debug.Log(locationZ);
            //string open = reader.GetString(7);
            //Debug.Log(open);
            //string find = reader.GetString(8);
            //Debug.Log(find);
            //int needPE = reader.GetInt32(9);
            //Debug.Log(needPE);
            //int nowPE = reader.GetInt32(10);
            //Debug.Log(nowPE);
            //string active = reader.GetString(11);
            //Debug.Log(active);
            //}
            //Debug.Log("value= " + zID + "  name =" + name);
          
        }
        reader.Close();
        reader = null;

        ///////////////////////////////////////////////////////////////////[Data Read]

        //포지션 업데이트 함수 동작(update Query)
        string UpdatesqlQuery = "UPDATE zodiacTable SET \"locationX\" =" + x + ", \"locationY\" = " + y + ", \"locationZ\" = " + z + " WHERE  \"zID\" = '" + zID + "'";
        //UPDATE zodiacTable SET "locationX" = 95.45624, "locationY" = 59.22803, "locationZ" = -94.25877 WHERE  "zID" = 'Aqua_1'
        Debug.Log(UpdatesqlQuery);
        dbcmd.CommandText = UpdatesqlQuery;
        dbcmd.ExecuteNonQuery();

        ///////////////////////////////////////////////////////////////////[DB Connection Close]
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
        ///////////////////////////////////////////////////////////////////[DB Connection Close]
    }

    void Update()
    {

    }
    void setStarPosition()
    {
        Debug.Log(star.transform.position);
    }

}