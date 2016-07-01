using UnityEngine;
using System.Collections;


public class PlanetManager : MonoBehaviour
{
    //[SerializeField, Tooltip("Add Planet.")]
    //public Planet m_planet = new Planet
    //{
    //    size = 1,

    //};

    //[System.Serializable]
    //public struct Planet
    //{
    //    public int size;
    //    static public GameObject[] planet;

    //}

    //public Testitem[] planetList;

    public GameObject udp;
    public GameObject[] planet;

    public float spawnTime = 10.0f;
    public GameObject player;
    float deltaSpawnTime = 0.0f;

    int spawnCnt = 1;
    int maxSpawnCnt = 10;

    GameObject[] planetPool;
    int poolSize = 20;

    void Start()
    {
        planetPool = new GameObject[poolSize];
        for (int i = 0; i < poolSize; ++i)
        {
            planetPool[i] = Instantiate(udp) as GameObject;
            planetPool[i].SetActive(false);
        }
    }

    void Update()
    {
        if (spawnCnt > maxSpawnCnt)
            return;

        deltaSpawnTime += Time.deltaTime;

        if (deltaSpawnTime > spawnTime)
        {
            deltaSpawnTime = 0.0f;
            for (int i = 0; i < poolSize; i++)
            {
                if (planetPool[i].activeSelf == true)
                    continue;
                int planetRandom = Random.Range(1, 4);
                Debug.Log(planetRandom);
                Vector3 pcPosition = player.transform.localPosition;
                Vector3 left = Vector3.left * 3.5f;
                Vector3 right = Vector3.right * 3.5f;
                Vector3 up = Vector3.up * 3.5f;
                Vector3 down = Vector3.down * 3.5f;
                int x = Random.Range(-5, 5);

                //planetPool[i].transform.position = new Vector3(x, pcPosition.y, pcPosition  .z + 12.5f);
                if (planetRandom == 1)
                    planetPool[i].transform.position = player.transform.position + player.transform.forward * 12.5f + left;

                else if (planetRandom == 2)
                    planetPool[i].transform.position = player.transform.position + player.transform.forward * 12.5f + right;

                else if (planetRandom == 3)
                    planetPool[i].transform.position = player.transform.position + player.transform.forward * 12.5f + up;

                else if (planetRandom == 4)
                    planetPool[i].transform.position = player.transform.position + player.transform.forward * 12.5f + down;


                planetPool[i].SetActive(true);

                planetPool[i].name = "Planet_" + spawnCnt;
                ++spawnCnt;
                break;
            }

        }
    }

    public void planetChange(Vector3 spawnPoint)
    {
        int rand = Random.Range(1, 9);
        GameObject obj = Instantiate(planet[rand]);
        obj.transform.position = spawnPoint;
    }
}