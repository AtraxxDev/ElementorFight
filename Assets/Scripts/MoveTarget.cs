using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTarget : MonoBehaviour
{
    public float speed = 3;
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

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("HitEnemy");
        punchRef.PunchEnemy();
    }

   
}
