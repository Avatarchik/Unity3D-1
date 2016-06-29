using UnityEngine;
using System.Collections;

public class PlanetManager : MonoBehaviour
{
    public GameObject planet;
    public float spawnTime = 2.0f;

    float deltaSpawnTime = 0.0f;

    int spawnCnt = 1;
    int maxSpawnCnt = 10;

    GameObject[] planetPool;
    int poolSize = 10;

    void Start()
    {
        planetPool = new GameObject[poolSize];
        for(int i=0; i< poolSize; ++i)
        {
            planetPool[i] = Instantiate(planet) as GameObject;
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
            for(int i = 0; i < poolSize; i++)
            {
                if (planetPool[i].activeSelf == true)
                    continue;

                int x = Random.Range(-20, 20);
                planetPool[i].transform.position = new Vector3(x, 0.1f, 20.0f);
                planetPool[i].SetActive(true);

                planetPool[i].name = "Planet_" + spawnCnt;
                ++spawnCnt;
                break;
            }
            
        }
    }
}