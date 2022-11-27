using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    private Button btn;

    public GameObject mainCoin;
    
    

    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn?.onClick.AddListener(() => StartGame());
    }

    void StartGame()
    {
        mainCoin.GetComponent<Coin>().enabled = true;
        transform.gameObject.SetActive(false);
    }

   
}