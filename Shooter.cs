using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile = null;
    private Spawner myLaneSpawner;
    Animator animator;
    GameObject projectParent;
    string PROJECTILE_PARENT_NAME = "Projectiles";

    private void Start()
    {
        animator = GetComponent<Animator>();
        SetLaneSpawner();
        SetProjectileParent();
    }

    private void SetProjectileParent()
    {
        projectParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectParent)
        {
            projectParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    private void Update()
    {
        if (IsAttackerInLane())
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }


    private void SetLaneSpawner()
    {
        Spawner[] spawners = FindObjectsOfType<Spawner>();

        foreach (Spawner spawner in spawners)
        {
            bool IsSameLane = (Mathf.Abs(transform.position.y - spawner.transform.position.y) <= Mathf.Epsilon);
            if (IsSameLane)
            {
                myLaneSpawner = spawner;
                break;
            }

        }
    }

    private bool IsAttackerInLane()
    {
        if (myLaneSpawner.gameObject.transform.childCount <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void Fire()
    {
        var gun = gameObject.transform.GetChild(0).GetChild(0);
        GameObject currentProjectile = Instantiate(projectile, gun.transform.position, transform.rotation) as GameObject;

        this.transform.parent = projectParent.transform;

    }


}
