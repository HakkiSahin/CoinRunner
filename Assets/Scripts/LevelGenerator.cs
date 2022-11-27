using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject withoutCoin;
    public List<GameObject> coin;
    public List<GameObject> curveCoin;
    public List<GameObject> obstacle;
    public GameObject finish;
    
    private Transform parentObject;

    void Start()
    {
        parentObject = GameObject.Find("Way").transform;
        CreatingLevel();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private Vector3 spawnPos;

    void CreatingLevel()
    {
        for (int i = 0; i < 7; i++)
        {
            spawnPos = Vector3.zero + new Vector3(0, 0, i * 14);

            if (i <= 0)
            {
                CreatingObject(coin[Random.Range(0, coin.Count)], spawnPos);
            }
            else
            {
                if (Random.Range(0, 100) < 20)
                {
                    CreatingObject(coin[Random.Range(0, coin.Count)], spawnPos);
                }
                else
                {
                    CreatingObject(obstacle[Random.Range(0, obstacle.Count)], spawnPos);
                }
            }
        }

        CreatingObject(finish, spawnPos + new Vector3(0, 0, 10));
    }

    void CreatingObject(GameObject obj, Vector3 pos)
    {
        Instantiate(obj, pos, Quaternion.identity, parentObject);
    }
}