using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] CoinsHolder;

    float spawnrate;
    float nextspwn;

  
    void Start()
    {
        nextspwn = Time.time;
    }


    void Update()
    {
        if (Menu.menu.Gamestart == false)
        {
            if (Collector._collector.boost == true)
            {
                spawnrate = 0.9f;
            }
            else
            {
                spawnrate = Random.Range(1.5f,3);
            }
            if (nextspwn < Time.time)
            {
                GameObject _coins = Instantiate(CoinsHolder[Random.Range(0, CoinsHolder.Length)], transform.position, Quaternion.identity);
                Destroy(_coins, 8);
                nextspwn = Time.time + spawnrate;
            }
        }
    }
}
