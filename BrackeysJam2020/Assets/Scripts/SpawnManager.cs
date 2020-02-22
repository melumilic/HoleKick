using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;
    [SerializeField]
    private bool stop = false;
    [SerializeField]
    private Transform[] _spawnPoints = new Transform[5];
    [SerializeField]
    private GameObject _potHolePrefab;
    [SerializeField]
    private GameObject _enemyPrefab;
    private GameObject _delete;
    private List<GameObject> remover = new List<GameObject>();
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
        StartCoroutine(SpawnRoutine());
        _delete = GameObject.Find("Cleaner");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator SpawnRoutine()
    {
        while (true)
        {
            if (!stop)
            {
                int spawnOne = Random.Range(0, 5);
                int spawnTwo = Random.Range(0, 5);
                while (spawnOne == spawnTwo)
                {
                    spawnTwo = Random.Range(0, 5);
                }
                var temp = Instantiate(_enemyPrefab, _spawnPoints[spawnOne].position, Quaternion.identity);
                remover.Add(temp);
                yield return new WaitForSeconds(.5f);
                var temp1 = Instantiate(_potHolePrefab, _spawnPoints[spawnTwo].position, Quaternion.identity);
                remover.Add(temp1);
                yield return new WaitForSeconds(Random.Range(1, 3));
            }
            else
            {
                Debug.Log("Stopped");
                yield return new WaitForSeconds(10f);
            }
        }
    }
    public void EndSpawning()
    {
        foreach (var item in remover)
        {
            if (item != null)
            {
                Destroy(item.gameObject);
            }
        }
        stop = true;
    }
}
