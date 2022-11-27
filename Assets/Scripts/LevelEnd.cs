using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    private Button btn;


    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn?.onClick.AddListener(() => NextLevel());
    }

    void NextLevel()
    {
        SceneManager.LoadScene(0);
    }
}