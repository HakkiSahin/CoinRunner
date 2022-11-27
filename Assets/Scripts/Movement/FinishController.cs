using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine.Animations;

public class FinishController : MonoBehaviour
{
    public GameObject cineMachine;
    public GameObject followCineMachine;
    public GameObject canvas;

    private void Start()
    {
        followCineMachine = GameObject.Find("Cam");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cineMachine.SetActive(true);
            followCineMachine.SetActive(false);

            other.GetComponent<Coin>().enabled = false;
            StartCoroutine(CoinStack(other.transform.parent));
        }
    }


    IEnumerator CoinStack(Transform coins)
    {
        for (int i = 0; i < coins.childCount; i++)
        {
            if (i > 0)
            {
                coins.GetChild(i).GetComponent<Follow>().enabled = false;
            }


            Transform coin = coins.GetChild(i);
            coins.GetChild(i).DOLocalJump(transform.GetChild(i).position, 3f, 1, 0.3f).OnComplete(() =>
            {
                coin.GetComponent<Animator>().enabled = true;
                coin.GetComponent<Animator>().SetTrigger("isFlip");
            });

            yield return new WaitForSeconds(0.3f);
        }

        canvas.transform.GetChild(1).gameObject.SetActive(true);
    }
}