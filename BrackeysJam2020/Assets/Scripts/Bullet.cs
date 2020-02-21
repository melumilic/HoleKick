using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float _damage = 1f;
    [SerializeField]
    private GameObject _expEffect;
    [SerializeField]
    private string _tagName;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float _speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("KillSelf", 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
        rb.AddForce(transform.localPosition.normalized * _speed,ForceMode2D.Impulse);
    }
    void KillSelf()
    {
        Instantiate(_expEffect, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            KillSelf();
        }
        Damageable dm = collision.GetComponent<Damageable>();
        if (dm != null&&collision.tag==_tagName)
        {
            dm.Damage(_damage);
            KillSelf();
        }
    }
}
