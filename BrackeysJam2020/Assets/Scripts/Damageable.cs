using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public float _maxHealth = 5;
    public float _health = 5;
    [SerializeField]
    private GameObject _deathEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_health <= 0)
        {
            Instantiate(_deathEffect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    public void Damage(float dmg) 
    {
        _health -= dmg;
    }
    public void addHealth(float amount)
    {
        _health += amount;
        if(_health > _maxHealth)
        {
            _health = _maxHealth;
        }
    }
}
