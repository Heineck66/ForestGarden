using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    [SerializeField] float waitToLoad = 4f;
    [SerializeField] GameObject winLabel = null;
    [SerializeField] GameObject lostLabel = null;
    int attackerAlive = 0;
    bool islevelTimerOver = false;


    private void Start()
    {
        winLabel.SetActive(false);
        lostLabel.SetActive(false);
    }

    public void AddAttackerAlive()
    {
        attackerAlive++;
    }

    public void RemoveAttackerAlive()
    {
        attackerAlive--;
        if (islevelTimerOver && attackerAlive <= 0)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    private IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitToLoad);
        FindObjectOfType<SceneLoader>().LoadNextScene();

    }

    public void LevelTimerFinished()
    {
        StopSpawners();
        islevelTimerOver = true;
    }

    private static void StopSpawners()
    {
        var spawners = FindObjectsOfType<Spawner>();
        foreach (Spawner s in spawners)
        {
            s.StopSpawning();
        }
    }
}
