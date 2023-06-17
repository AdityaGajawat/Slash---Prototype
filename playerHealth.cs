using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    private SoundManager sound;
    private GameObject enemy;
    public int health;
    public bool isDead = false;
    private int currentHealth;
    private Animator animator;
    [SerializeField] GameObject hitEffect;
    [SerializeField] GameObject deathEffect;
    [SerializeField] Transform hitEffectPos;

    private void Start()
    {
        sound = gameObject.GetComponent<SoundManager>();
        enemy = GameObject.FindWithTag("Enemy");
        animator = GetComponent<Animator>();
        currentHealth = health;
    }
    private void Update()
    {
     if(health < currentHealth)
        {
            sound.hitSound();
            Instantiate(hitEffect, hitEffectPos.position, Quaternion.identity);
            currentHealth = health;
            Debug.Log(currentHealth);
        }
        if (currentHealth <= 0)
        {
            sound.hitSound();
            enemy.GetComponent<Enemy_behaviour>().inRange = false;
            Instantiate(deathEffect, hitEffectPos.position, Quaternion.identity);
            animator.SetTrigger("isDead");
            gameObject.SetActive(false);
            Invoke("resetScene", 3f);
        }
    }
    void resetScene() => SceneManager.LoadScene(0);
}
