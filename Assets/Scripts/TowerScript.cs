using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    private Health target = null;
    public float range = 15f;
    public float dmg = 20f;
    public float fireRate = 0.2f;

    private float lastShot = 0f;

    void Awake()
    {
        GetComponent<SphereCollider>().radius = range;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (target == null || target.isTargetDead())
        {
            target = other.gameObject.GetComponentInParent<Health>();
        }

    }

    void Update()
    {
        if (target != null)
        {
            ShootTarget();
        }
    }

    void ShootTarget()
    {
        if (Time.time > fireRate + lastShot)
        {
            target.TakeDamage(dmg);
            lastShot = Time.time;
        }
    }

}
