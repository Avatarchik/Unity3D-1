using UnityEngine;
using System.Collections;
using Mono.Data.Sqlite;
using System.Data;
using System;




public class SqliteTest : MonoBehaviour {



    void Start()
    {
        string m_ConnectionString;
        string m_SQLiteFileName = "CosmicDB.sqlite";

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
                var loadDb = new WWW("jar:file://" + Application.dataPath + "!/assets/" + m_SQLiteFileName);  // this is the path to your StreamingAssets in android
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

        string conn = "URI=file:" + Application.streamingAssetsPath + "/CosmicDB.sqlite"; //Path to database.

        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT value,name, randomSequence " + "FROM PlaceSequence";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            int value = reader.GetInt32(0);
            string name = reader.GetString(1);
            int rand = reader.GetInt32(2);

            Debug.Log("value= " + value + "  name =" + name + "  random =" + rand);
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    
        //using (IDbConnection dbConnection = new SqliteConnection(m_ConnectionString))
        //{
        //    dbConnection.Open();

        //    using (IDbCommand dbCmd = dbConnection.CreateCommand())
        //    {
        //        IDbConnection dbconn;
        //        IDbCommand dbcmd = dbconn.CreateCommand();

        //        string sqlQuery = "SELECT value,name, randomSequence " + "FROM PlaceSequence";
        //        dbcmd.CommandText = sqlQuery;
        //        IDataReader reader = dbcmd.ExecuteReader();

        //        //string sqlQuery = "SELECT...";
        //        //dbCmd.CommandText = sqlQuery;
        //        //using (IDataReader reader = dbCmd.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                int value = reader.GetInt32(0);
        //                string name = reader.GetString(1);
        //                int rand = reader.GetInt32(2);

        //                Debug.Log("value= " + value + "  name =" + name + "  random =" + rand);
        //            }
        //            dbConnection.Close();
        //            reader.Close();
        //        }
        //    }
        //}
    }


}