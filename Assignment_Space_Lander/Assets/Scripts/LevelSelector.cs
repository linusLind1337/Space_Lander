using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public int sceneNumber;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartScene()
    {
        Debug.Log("loading scene");
        SceneManager.LoadScene("Level" + sceneNumber.ToString());
    }
}
