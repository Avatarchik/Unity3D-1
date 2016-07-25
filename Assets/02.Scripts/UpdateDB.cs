using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;

public class UpdateDB : MonoBehaviour
{
    static UpdateDB _instance = null;

    public static UpdateDB Instance()
    {
        return _instance;
    }
    string m_ConnectionString;
    string m_SQLiteFileName = "CosmicDB.sqlite";
    [Tooltip("Columnname\nEx)zId,locationX")]
    public string setColumn = " ";
    [Tooltip("Tablename\nEx)zodiacTable")]
    public string table = " ";
    public string where = " ";
    public string value = " ";
    string sqlQuery;
    string conn;

    //public GameObject star;
    float x;
    float y;
    float z;
    string zID;
    int cntField;
    int cntTemp = 1;

    void Awake()
    {
        if (_instance == null)
            _instance = this;
    }

    public void UpdateData()
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

        /////////////////////////////////////////////////////////////////[DB Connection]
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        /////////////////////////////////////////////////////////////////[DB Connection]

        /////////////////////////////////////////////////////////////////[INSERT Query]
        IDbCommand dbcmd = dbconn.CreateCommand();

        sqlQuery = "UPDATE " + table + " SET " + setColumn + where;
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


        //초기 별 좌표 일괄 업데이트
        /////////////////////////////////////////////////////////////////////[DB Connection]
        //IDbConnection dbconn;
        //dbconn = (IDbConnection)new SqliteConnection(conn);
        //dbconn.Open(); //Open connection to the database.
        /////////////////////////////////////////////////////////////////////[DB Connection]

        //for (cntTemp = 1; cntTemp != cntField; cntTemp++)
        //{
        //    IDbCommand dbcmd = dbconn.CreateCommand();
        //    string sqlCount = "SELECT Count(rowid) as Count " + "FROM zodiacTable";
        //    dbcmd.CommandText = sqlCount;
        //    IDataReader reader = dbcmd.ExecuteReader();
        //    while(reader.Read())
        //    {
        //        cntField = reader.GetInt32(0);
        //    }
        //    reader.Close();
        //    reader = null;
            
        //    string sqlQuery = "SELECT rowid, * " + "FROM zodiacTable";
        //    dbcmd.CommandText = sqlQuery;
     
        //    reader = dbcmd.ExecuteReader();
        
        //    while (reader.Read())
        //    {
        //        if (reader.GetInt32(0) == cntTemp)
        //        {

        //            int rowid = reader.GetInt32(0);
        //            Debug.Log(rowid);
        //            zID = reader.GetString(1);
        //            Debug.Log(zID);
        //            Debug.Log(GameObject.Find(zID).gameObject.transform.position);
        //            x = GameObject.Find(zID).gameObject.transform.position.x;
        //            y = GameObject.Find(zID).gameObject.transform.position.y;
        //            z = GameObject.Find(zID).gameObject.transform.position.z;
        //        }
        //    }
        //    reader.Close();
        //    reader = null;

        ////업데이트 함수 동작(update Query)
        /////////////////////////////////////////////////////////////////////[UPDATE Query]
        //    string UpdatesqlQuery = "UPDATE zodiacTable SET \"locationX\" =" + x + ", \"locationY\" = " + y + ", \"locationZ\" = " + z + " WHERE  \"zID\" = '" + zID + "'";
            
        //    Debug.Log(UpdatesqlQuery);
        //    dbcmd.CommandText = UpdatesqlQuery;
        //    dbcmd.ExecuteNonQuery();
        /////////////////////////////////////////////////////////////////////[UPDATE Query]
        //    dbcmd.Dispose();
        //    dbcmd = null;
        //}
        /////////////////////////////////////////////////////////////////////[DB Connection Close]
        //dbconn.Close();
        //dbconn = null;
        /////////////////////////////////////////////////////////////////////[DB Connection Close]
    }
       
}