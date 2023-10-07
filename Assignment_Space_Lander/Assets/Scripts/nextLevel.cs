using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour
{
    public ParticleSystem ps;

    private bool isLevelComplete;

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

    IEnumerator WaitTimer()
    {
        yield return new WaitForSeconds(1f);
       //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
