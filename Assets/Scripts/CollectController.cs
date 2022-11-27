using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollectController : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Collectable"))
        {
            other.transform.SetParent(transform.parent);
            other.transform.tag = "Collected";
            Vector3 newPos = transform.parent.GetChild(1).transform.localPosition;
            other.transform.localPosition =
                new Vector3(0, newPos.y, newPos.z + (transform.parent.childCount - 2) * - 0.4f);
            other.AddComponent<Follow>();
        }

        BounceEffect();
    }

    void BounceEffect()
    {
        transform.parent.GetChild(0).GetComponent<Animator>().enabled = true;
    }

    public void EndAnim()
    {
        _animator.enabled = false;
    }

    public void PlayNextAnim()
    {
        if (transform.GetSiblingIndex()+1 >= transform.parent.childCount)
        {
            return;
        }

        transform.parent.GetChild(transform.GetSiblingIndex() + 1).GetComponent<Animator>().enabled = true;
    }
}