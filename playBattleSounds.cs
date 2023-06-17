using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playBattleSounds : MonoBehaviour
{
    [SerializeField] AudioSource[] bgm;

    private int randomBGM;
    private void Awake()
    {
        randomBGM = Random.Range(0, 3);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log(randomBGM);
            bgm[randomBGM].Play();
        }
    }
}
