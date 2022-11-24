using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsMovement : MonoBehaviour
{
    public static CoinsMovement Instance;
    float Speed = 5;

    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Menu.menu.Gamestart == false)
        {
            if (Collector._collector.boost == true)
            {
                Speed = 8;
            }
            else
            {
                Speed = 5;
            }
            transform.position = new Vector2(transform.position.x, transform.position.y - Speed * Time.deltaTime);
        }
        else
        {
            Speed = 0;
        }

    }
}
