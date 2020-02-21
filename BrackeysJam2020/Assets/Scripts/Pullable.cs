using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pullable : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pullApply(Vector3 pos, float force, bool instant)
    {

        Vector3 dir = (pos - transform.position).normalized;
        if (instant)
        {
            rb.AddForce(dir * force, ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(dir * force, ForceMode2D.Force);
        }
    }
}
