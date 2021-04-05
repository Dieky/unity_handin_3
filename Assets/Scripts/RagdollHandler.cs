using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using UnityEngine.UI;

public class RagdollHandler : MonoBehaviour
{
    [SerializeField] private float deathforce = 5;
    public Canvas _canvas;
    void Start()
    {
        GoRagdoll(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            GoRagdoll(true);
        }
    }

    public void GoRagdoll(bool v)
    {
        if (v == true)
        {
            _canvas.enabled = false;
            // disable animator
            GetComponentInChildren<Animator>().enabled = false;
        }

        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rb in rigidbodies)
        {
            if (rb.gameObject != gameObject)
            {
                rb.useGravity = v;
                rb.isKinematic = !v;
            }
        }
        var rbp = GetComponent<Rigidbody>();
        rbp.useGravity = v;
        rbp.isKinematic = !v;
        if (v == true)
        {
            rbp.AddForce(transform.up * deathforce, ForceMode.VelocityChange);
        }



    }
}
