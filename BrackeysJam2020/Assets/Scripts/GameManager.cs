using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject _player;
    public static GameManager instance;
    [SerializeField]
    public int health = 5;
    public int pavingMats = 0;
    public int score = 0;
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
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(health == 0)
        {

        }
    }
    public void pave()
    {
        if (pavingMats < 1)
        {
            health--;
        }
    }
    public void scored()
    {
        score++;
    }
    public void collect()
    {
        pavingMats++;
    }
}
