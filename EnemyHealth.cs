using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private EnemySoundManager sound;
    private SpriteRenderer sprRen;
    public int health = 150;
    public float currentHealth;
    private Animator animator;
    [SerializeField] GameObject hitEffect;
    [SerializeField] GameObject deathEffect;
    [SerializeField] Transform hitEffectSpawnPos;



    private void Start()
    {
        sound = GetComponentInParent<EnemySoundManager>();
        sprRen = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponent<Animator>();
        currentHealth = health;
    }
    IEnumerator hurt()
    {
        
        sprRen.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        sprRen.color = Color.white;
    }
    private void Update()
    {
        if(health < currentHealth)
        {
            sound.hitSound();
            Instantiate(hitEffect,transform.position,Quaternion.identity);
            currentHealth = health;
            StartCoroutine(hurt());
        }
        if(health <= 0)
        {
            sprRen.color = Color.black;
            Instantiate(deathEffect, hitEffectSpawnPos.position,Quaternion.identity);
            animator.SetTrigger("isDead");
            Destroy(gameObject, 0.5f);
        }
    }
}
