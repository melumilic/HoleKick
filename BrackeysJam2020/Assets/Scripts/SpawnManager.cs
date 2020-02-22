using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private bool stop = false;
    [SerializeField]
    private Transform[] _spawnPoints = new Transform[5];
    [SerializeField]
    private GameObject _potHolePrefab;
    [SerializeField]
    private GameObject _enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
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
                Instantiate(_enemyPrefab, _spawnPoints[spawnOne].position, Quaternion.identity);
                yield return new WaitForSeconds(.5f);
                Instantiate(_potHolePrefab, _spawnPoints[spawnTwo].position, Quaternion.identity);
                yield return new WaitForSeconds(Random.Range(1, 4));
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
        stop = true;
    }
}
