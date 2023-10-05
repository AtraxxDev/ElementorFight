using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 3;
    public float _currentHealth;
    public Animator _animator;

    [SerializeField] private HealthBar _healthBar;

    // Configura estas variables seg�n tus necesidades.
    [SerializeField] private float forceMagnitude = 100f;
    [SerializeField] private float forceMagnitude2 = 20f;
    [SerializeField] private Vector3 forceDirection = -Vector3.forward; // Empujar� hacia atr�s en la direcci�n Z negativa.

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = _maxHealth;
        _healthBar.UpdateHealthBar(_maxHealth, _currentHealth);

        // Obt�n el componente Rigidbody del GameObject
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogWarning("El GameObject no tiene un Rigidbody adjunto.");
        }
    }

    public void Damage()
    {
        if (_currentHealth <= 0)
        {
            _healthBar.UpdateHealthBar(_maxHealth, _currentHealth);

            if (rb != null)
            {
                rb.AddForce(forceDirection * forceMagnitude, ForceMode.Impulse);
            }


            //_animator.enabled = false;


            Destroy(gameObject, 2.0f);
        }
        else
        {
            _healthBar.UpdateHealthBar(_maxHealth, _currentHealth); // Se va actualizando la vida mediante el da�o
            // Se pone efecto de hit damage (Particle)
            StartCoroutine("ChangeAnim");
            if (rb != null)
            {
                rb.AddForce(forceDirection * forceMagnitude2, ForceMode.Impulse);
            }
        }
    }

    IEnumerator ChangeAnim()
    {
        _animator.SetBool("_Hit2", true); // Manda la animaci�n _Hit
        yield return new WaitForSeconds(0.5f);
        _animator.SetBool("_Hit2", false); // Manda la animaci�n _Hit
    }
}