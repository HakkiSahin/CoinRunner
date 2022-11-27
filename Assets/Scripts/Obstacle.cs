using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;

public class Obstacle : MonoBehaviour
{
    public ObstacleType obstacleType;

    private List<GameObject> destroyList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ObstacleAnim();
    }

    void ObstacleAnim()
    {
        switch (obstacleType)
        {
            case ObstacleType.Axe:
                break;
            case ObstacleType.Door:
                break;
            case ObstacleType.Prop:
                transform.Rotate(0, 0, 0.4f);
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collected"))
        {
            for (int i = other.transform.GetSiblingIndex(); i < other.transform.parent.childCount; i++)
            {
                destroyList.Add(other.transform.parent.GetChild(i).gameObject);
            }

            DestroyCoins();
        }
    }

    void DestroyCoins()
    {
        for (int i = 0; i < destroyList.Count; i++)
        {
            destroyList[i].transform.tag = "Untagged";
            destroyList[i].transform.SetParent(null);
            destroyList[i].transform.DOJump(Vector3.up, 3f, 1, 1f).OnComplete(() => { Destroy(destroyList[i]); });
        }
    }
}

public enum ObstacleType
{
    Axe,
    Door,
    Prop
}