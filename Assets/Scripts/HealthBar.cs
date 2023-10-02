using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthbarSprite;
    [SerializeField] private float _reduceSpeed = 2 ;
    private float _target = 1;
    // Start is called before the first frame update
    public void UpdateHealthBar(float maxHealth, float currentHealth)
    {
        _target = currentHealth / maxHealth;
    }
    private void Update()
    {
        _healthbarSprite.fillAmount = Mathf.MoveTowards(_healthbarSprite.fillAmount, _target, _reduceSpeed * Time.deltaTime); // Reduce el fill de la vida como si fuera un lerp
    }
}
