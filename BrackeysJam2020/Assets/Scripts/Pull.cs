using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pull : MonoBehaviour
{
    [SerializeField]
    private float _pullForceInitial = 3f;
    [SerializeField]
    private float _pullForce = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Pullable pullable = collision.GetComponent<Pullable>();
        if ( pullable != null)
        {
            pullable.pullApply(transform.position, _pullForceInitial, true);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Pullable pullable = collision.GetComponent<Pullable>();
        if (pullable != null)
        {
            pullable.pullApply(transform.position, _pullForce, false);
        }
    }
}
