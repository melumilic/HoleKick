using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance; 
    private GameObject _player;
    public List<AudioClip> audioClips = new List<AudioClip>();
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
        //DontDestroyOnLoad(this);
    }
    void Start()
    {
        _player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playSound(int index)
    {
        AudioSource.PlayClipAtPoint(audioClips[index],_player.transform.position);
    }
}
