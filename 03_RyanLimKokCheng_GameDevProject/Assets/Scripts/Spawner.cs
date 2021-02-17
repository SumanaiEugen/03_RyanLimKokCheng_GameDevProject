using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public float Timeintervals;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitAndSpawn(Timeintervals));
    }

    // Update is called once per frame
    void Update()
    {

    }
    private IEnumerator WaitAndSpawn(float Waittime)
    {
        while (true)
        {
            yield return new WaitForSeconds(Waittime);

            Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
        }
    }
}

