using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float SecondsToWait = 1f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(ActivePortalCount());
        other.gameObject.SetActive(false);
    }

    private IEnumerator ActivePortalCount()
    {
        yield return new WaitForSeconds(SecondsToWait);
        LoadNextLevel();
    }

    private void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void ResetLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
