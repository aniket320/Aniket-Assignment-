using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class Collector : MonoBehaviour
{
    public static Collector _collector;
    private float coins;
    public TMP_Text coinstxt;
    public bool boost, shield;
    public GameObject _Spawner;
    public GameObject[] Effects;


    void Awake()
    {
        _collector = this;
    }
    private void Start()
    {
        coins = PlayerPrefs.GetFloat("counter", coins);
    }

    void Update()
    {
        coinstxt.text = coins.ToString();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PlayerPrefs.SetFloat("counter", coins);
        }
    }

    [System.Obsolete]
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coins"))
        {
            coins++;
            Destroy(collision.gameObject);
            var Stareffect = Instantiate(Effects[0], transform.position, Quaternion.identity);
            Stareffect.transform.parent = gameObject.transform;
            Destroy(Stareffect, 1);
        }
       
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            if (!shield)
            {
                Destroy(gameObject);
                Destroy(_Spawner); 
                Menu.menu.failui();
            }

            transform.DOShakePosition(0.4f, 0.2f);
            var Expeffect = Instantiate(Effects[2], transform.position, Quaternion.identity);
            Expeffect.transform.parent = gameObject.transform;
            Destroy(Expeffect, 2);
            Destroy(collision.gameObject);
            PlayerPrefs.SetFloat("counter", coins);
        }
        
        if (collision.gameObject.CompareTag("Boost"))
        {
            boost = true;
            StartCoroutine(Boost());
            Destroy(collision.gameObject);
        }
        
        if (collision.gameObject.CompareTag("Shield"))
        {
            shield = true;
            StartCoroutine(shielddisable());
            Destroy(collision.gameObject);
        }
    }

    [System.Obsolete]
    IEnumerator Boost()
    {
        Effects[3].SetActive(true);
        Effects[4].GetComponent<ParticleSystem>().maxParticles = 9;
        yield return new WaitForSeconds(15);
        Effects[3].SetActive(false);
        Effects[4].GetComponent<ParticleSystem>().maxParticles = 2;
        boost = false;
    }
    IEnumerator shielddisable()
    {
        Effects[1].gameObject.SetActive(true);
        yield return new WaitForSeconds(10);
        Effects[1].gameObject.SetActive(false);
        shield = false;
    }
}
