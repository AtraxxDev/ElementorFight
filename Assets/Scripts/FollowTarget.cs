using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float moveSpeed = 5.0f;
    public Punch punchRef;


    void Update()
    {
        if (target != null)
        {
            // Calcula la direcci�n hacia el objetivo
            Vector3 directionToTarget = target.position - transform.position;

            // Mira siempre hacia el objetivo
            transform.LookAt(target);

            // Mueve al enemigo hacia el objetivo
            transform.position += directionToTarget.normalized * moveSpeed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("HitEnemy");
            punchRef.PunchEnemy();

        }

    }
}