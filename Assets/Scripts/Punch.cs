using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Punch : MonoBehaviour
{

    //[SerializeField] private Health _health; 
    public List<Health> Enemies=new List<Health> ();
    //[SerializeField] private Transform _targetHand;
    //[SerializeField] private Transform _targetEnemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        /*
        if (Input.GetKeyUp(KeyCode.C))
        {
            SeekEnemy();
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        //PunchEnemy();
    }

    /*
    private void SeekEnemy()
    {
        if (_targetEnemy != null)
        {
            float moveSpeed = 2;
            // Calcula la dirección hacia el objetivo
            Vector3 directionToTarget = _targetEnemy.position - _targetHand.position;

            // Mira siempre hacia el objetivo
            transform.LookAt(_targetEnemy);

            // Mueve al enemigo hacia el objetivo
            transform.position += directionToTarget.normalized * moveSpeed * Time.deltaTime;
        }
    }*/

    public void PunchEnemy()
    {

        foreach (Health enemy in Enemies)
        {
            Debug.Log("Pum Pum fan de la CQ");
            enemy._currentHealth -=1;
            enemy.Damage();
        }
    }
}
