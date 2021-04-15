using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    private GameObject target = null;
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
        target = other.gameObject;
    }

    void Update()
    {
        if(target != null)
        {
            ShootTarget();
        }
    }

    void ShootTarget()
    {
        var targetScript = target.GetComponent<Enemy>();
        if(Time.time > fireRate + lastShot)
        {
            targetScript.TakeDamage(dmg);
            lastShot = Time.time;
        }
    }

}
