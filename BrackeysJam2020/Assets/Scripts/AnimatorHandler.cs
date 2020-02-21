using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorHandler : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null) { Debug.Log("Rigidbody2D in Player is null"); }
        anim = GetComponent<Animator>();
        if (rb == null) { Debug.Log("Animator in Player is null"); }

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("VelocityX", rb.velocity.x);
        anim.SetFloat("VelocityY", rb.velocity.y);
    }
}
