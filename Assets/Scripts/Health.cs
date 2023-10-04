using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 3;
    //[SerializeField] private GameObject _deadEffect,_hitEffect;
    public float _currentHealth;
    public Animator _animator;

    [SerializeField] private HealthBar _healthBar;

    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = _maxHealth;
        _healthBar.UpdateHealthBar(_maxHealth, _currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage()
    {
        if (_currentHealth <= 0)
        {
            _healthBar.UpdateHealthBar(_maxHealth, _currentHealth);
            // se instancia el efecto de muerte (Particle)
            // Active Ragdoll cuando muere 
            // se le activa o calcula la fuerza para que salga volando

            Destroy(gameObject,5);
        }

        else
        {
            _healthBar.UpdateHealthBar(_maxHealth, _currentHealth); // Se va actualizando la vida mediante el da�o
            // se pone efecto de hit damage (Particle)
            StartCoroutine("changeAnim");
        }
    }

    IEnumerator changeAnim() 
    {
        _animator.SetBool("_Hit2", true); // manda la animacion _HIt
        yield return new WaitForSeconds(0.5f);
        _animator.SetBool("_Hit2", false); // manda la animacion _HIt


    }

}
