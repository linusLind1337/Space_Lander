using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour
{
    //BackToMenu Function
    #region BackToMenu
    public void backToMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
    #endregion

    //Retry Function
    #region Retry
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    #endregion

}
