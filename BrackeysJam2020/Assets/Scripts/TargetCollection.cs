using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCollection : MonoBehaviour
{
    public List<GameObject> targets = new List<GameObject>();
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            Debug.Log("Entered");
            targets.Add(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Debug.Log("Exited");
            targets.Remove(collision.gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Debug.Log("Entered");
            targets.Add(collision.gameObject);
        }
    }
}
