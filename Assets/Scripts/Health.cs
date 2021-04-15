using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Health : MonoBehaviour
{

    private float currentHealth;
    [SerializeField] private float maxhealth = 100;

    private bool isDead = false;

    [SerializeField] private HealthDisplay healthDisplay;
    [SerializeField] private GameObject healthbar;

    private void Awake()
    {
        currentHealth = maxhealth;
        healthDisplay.updateHealthBar(currentHealth, maxhealth);
    }

    void Update()
    {
        if (isDead) return;

        currentHealth = Mathf.Max(currentHealth, 0);

        if (currentHealth > 0) return;

        OnDeath();
    }

    public bool isTargetDead()
    {
        return isDead;
    }

    private void OnDeath()
    {
        isDead = true;
        var ragdoll = GetComponent<RagdollHandler>();
        GetComponent<Enemy>().enabled = false;
        ragdoll.GoRagdoll(true);
        Destroy(healthbar);
        Destroy(gameObject, 2f);

    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;
        healthDisplay.updateHealthBar(currentHealth, maxhealth);
    }
}
