using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    public GameObject deathfx;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void killObject()
    {
        Instantiate(deathfx, transform.position, Quaternion.identity);
        SoundManager.instance.playSound(4);
        Destroy(this.gameObject);
    }
}
