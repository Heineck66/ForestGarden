using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;
    Rigidbody2D enemyRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (IsFacingRight())
        {
            enemyRigidbody.velocity = new Vector2(moveSpeed, 0f);
        }
        else
        {
            enemyRigidbody.velocity = new Vector2(-moveSpeed, 0f);
        }
    }

    private bool IsFacingRight()
    {
        return transform.localScale.x > 0;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(enemyRigidbody.velocity.x)), 1f);
    }
}
