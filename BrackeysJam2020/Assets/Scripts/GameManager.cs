using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject _player;
    public static GameManager instance;
    [SerializeField]
    public float maxHealth = 5;
    public float curHealth = 0;
    public float maxPavingMats = 1;
    public float pavingMats = 0;
    public int score = 0;
    private float lerping = 0;
    [SerializeField]
    private Canvas canvas;
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
    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
        _player = GameObject.Find("Player");
        UIManager.instance.fillSet(2, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(curHealth <= 0)
        {
            if (_player != null)
            {
                SpawnManager.instance.EndSpawning();
                canvas.gameObject.SetActive(true);
                _player.GetComponent<Destroyable>().killObject();
            }
        }
        
    }
    public void pave()
    {
        if (pavingMats < 1)
        {
            damage();
        }
        else
        {
            pavingMats--;
            UIManager.instance.fillSet(2, pavingMats / maxPavingMats);
            SoundManager.instance.playSound(2);
            scored();
        }
    }
    public void scored()
    {
        score++;
        UIManager.instance.setText(score+"");
        SoundManager.instance.playSound(5);
    }
    public void collect()
    {
        if (pavingMats < maxPavingMats)
        {
            pavingMats++;
            UIManager.instance.fillSet(2, pavingMats/maxPavingMats);

        }
        else if(pavingMats==maxPavingMats)
        {
            damage();
        }
    }
    private void damage()
    {
        curHealth--;
        Debug.Log(curHealth);
        UIManager.instance.fillSet(0, curHealth / maxHealth);
        SoundManager.instance.playSound(1);
    }
}
