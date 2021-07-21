using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    float currentSpeed = 0f;
    [SerializeField] int damagePower = 5;
    GameObject currentTarget;
    Animator animator;

    public int GetDamage() { return damagePower; }

    private void Awake()
    {
        FindObjectOfType<LevelController>().AddAttackerAlive();
    }

    private void OnDestroy()
    {
        LevelController levelController = FindObjectOfType<LevelController>();
        if (levelController != null)
        {
            levelController.RemoveAttackerAlive();
        }
    }

    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        UpdateAnimationState();

    }

    private void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            animator.SetBool("isAttacking", false);
        }
    }

    public void SetMovimentSpeed(float value)
    {
        animator = GetComponent<Animator>();
        currentSpeed = value;

    }

    public void EnterAttackMode(GameObject target)
    {
        animator.SetBool("isAttacking", true);
        currentTarget = target;

    }

    public void StrikeCurrentAttack()
    {
        if (!currentTarget) { return; }
        HealthManager health = currentTarget.GetComponent<HealthManager>();
        if (health)
        {
            health.DealDamage(damagePower);
        }


    }
}
