using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] AudioClip coinSFX = null;

    private void OnTriggerEnter2D(Collider2D other)
    {
        FindObjectOfType<GameSession>().AddCoin();
        AudioSource.PlayClipAtPoint(coinSFX, gameObject.transform.position);
        Destroy(gameObject);
    }

}
