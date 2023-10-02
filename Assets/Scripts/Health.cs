using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 3;
    [SerializeField] private GameObject _deadEffect,_hitEffect;
    private float _currentHealth;

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
            // se instancia el efecto de muerte
            // anim muerte 
        }

        else
        {
            _healthBar.UpdateHealthBar(_maxHealth, _currentHealth);
            // se pone efecto de hit damage
        }
    }
}
