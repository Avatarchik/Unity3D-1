using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;

public class InsertDB : MonoBehaviour
{
    static InsertDB _instance = null;

    public static InsertDB Instance()
    {
        return _instance;
    }

    string m_ConnectionString;
    string m_SQLiteFileName = "CosmicDB.sqlite";
    [Tooltip("Columnname\nEx)zId,locationX")]
    public string column = " ";
    [Tooltip("Tablename\nEx)zodiacTable")]
    public string table = " ";
    public string values = " ";
    string sqlQuery;
    string conn;
    string zID;
    float x;
    float y;
    float z;

    int cntField;
    int cntTemp = 1;

    void Start()
    {
        if (_instance == null)
            _instance = this;
    }

    
    public void Insert()
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

        /////////////////////////////////////////////////////////////////[INSERT Query]
        IDbCommand dbcmd = dbconn.CreateCommand();
 
        sqlQuery = "INSERT INTO " + table + " (" + column + ") VALUES (" + values + ")";
        Debug.Log(sqlQuery);
        dbcmd.CommandText = sqlQuery;
        dbcmd.ExecuteNonQuery();
        /////////////////////////////////////////////////////////////////[INSERT Query]
        
        dbcmd.Dispose();
        dbcmd = null;
        /////////////////////////////////////////////////////////////////[DB Connection Close]
        dbconn.Close();
        dbconn = null;
        /////////////////////////////////////////////////////////////////[DB Connection Close]

    }


}