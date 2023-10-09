using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour
{
    [Header("Boost Particles")]
    public ParticleSystem ps;

    private bool isLevelComplete;

    //OnCollisionEnter2D Fuction
    #region CollisionEnter2D
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && !isLevelComplete)
        {
            ps = GameObject.Instantiate(ps, transform.position, quaternion.identity);
            ps.Play();
            isLevelComplete = true;
            StartCoroutine(WaitTimer());
        }
    }
    #endregion

    //IEnumerator
    #region IEnumerator WaitTimer
    IEnumerator WaitTimer()
    {
        yield return new WaitForSeconds(1f);
    }
    #endregion

}
