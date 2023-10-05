using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTarget : MonoBehaviour
{
    [SerializeField] private float speed = 3;
    public Punch punchRef;

    private void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 movementDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));    

        transform.Translate(movementDirection.normalized*speed*Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.LogWarning("HitEnemy");
            punchRef.PunchEnemy();
        }
        
    }

   
}
