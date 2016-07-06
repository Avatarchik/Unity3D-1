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
    private GameObject player;
    public float spawnTime = 10.0f;
    
    float deltaSpawnTime = 0.0f;

    int spawnCnt = 1;
    int maxSpawnCnt = 20;

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
        player = GameManager.Instance().player;
        if (spawnCnt > maxSpawnCnt)
            return;

        deltaSpawnTime += Time.deltaTime;

        if (deltaSpawnTime > spawnTime)
        {
            deltaSpawnTime = 0.0f;
            for (int i = 0; i < poolSize; i++)
            {
                if (planetPool[i].activeSelf == true)
                {
                    //충돌하지 않은 물음표 행성 10m 초과로 멀어지면 Active False 처리
                    //Debug.Log("Distance of RandomPlanet" + Vector3.Distance(planetPool[i].transform.position, player.transform.position));
                    if (Vector3.Distance(planetPool[i].transform.position, player.transform.position) > 10)
                    {
                        //Debug.Log("Planet Disable!");
                        planetPool[i].SetActive(false);
                    }
                    continue;
                }
                int planetRandom = Random.Range(1, 4);
                //Debug.Log("[SpawnDirection]\n1: left , 2: Right, 3: up, 4: down" + "\t<b>" +planetRandom +"</b>");
                Vector3 pcPosition = player.transform.localPosition;
                Vector3 left = Vector3.left * 3.5f;
                Vector3 right = Vector3.right * 3.5f;
                Vector3 up = Vector3.up * 3.5f;
                Vector3 down = Vector3.down * 3.5f;
                int x = Random.Range(-5, 5);

                
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