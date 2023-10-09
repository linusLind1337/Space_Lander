using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    [Header("Scene Number")]
    public int sceneNumber;

    //StartScene Function
    #region startScene
    public void StartScene()
    {
        Debug.Log("loading scene");
        SceneManager.LoadScene("Level" + sceneNumber.ToString());
    }
    #endregion

}
