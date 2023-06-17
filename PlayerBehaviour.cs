using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    //Third Party Scripts
    [SerializeField] private SoundManager sound;
    //Common Declarations
    private Rigidbody2D rb;
    private Animator animator;

   

    //Collisions
    [SerializeField] Transform groundPos;
    [SerializeField] float groundPosRadius;
    private bool isGrounded;

    //LayerMask 
    [SerializeField] LayerMask whatisGround;

    //Player Settings
    private float horizontal;

    [Header("Player Settings")]
    [SerializeField] float playerSpeed = 0f;
    


    [Header("Attack Settings")]
    [SerializeField] private float comboTime = 0.3f;
    private float comboTimeCounter;
    private int comboCounter;
    private bool isAttacking;

    [Header("Attack on Enemy Settings")]
    [SerializeField] Transform damagePos;
    [SerializeField] float damagePosRadius;
    [SerializeField] LayerMask whatIsEnemy;
    [SerializeField] int damage;


    [Header("Defence Mechanism Settings")]
    [SerializeField] Transform defenceZone;
    [SerializeField] float defenceZoneRadius;
    [SerializeField] float forceForDefence;

    [Header("Effect")]
    [SerializeField] GameObject swingEffect;
    [SerializeField] Transform swingEffectPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        comboTimeCounter -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            if (comboTimeCounter < 0)
                comboCounter = 0;

            isAttacking = true;
            comboTimeCounter = comboTime;
        }
     
        checkCollisions();
        AnimatorController();
        JumpAttackMethod();
    }

    public void attackEffect()
    {
        int willAttack = Random.Range(0, 2);
        Debug.Log(willAttack);
        if(willAttack == 1)
        {
            Instantiate(swingEffect, swingEffectPos.position, Quaternion.identity);
        }
    }
    public void attackOver()
    {
        isAttacking = false;
        comboCounter++;
        if (comboCounter > 2)
            comboCounter = 0;
    }    
    private void JumpAttackMethod()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("isKicking");
        }
    }

    private void AnimatorController()
    {
        animator.SetFloat("speed", Mathf.Abs(horizontal));
        animator.SetFloat("veloctiyX", Mathf.Clamp(rb.velocity.x, 0, 1));     
        animator.SetBool("isGrounded", isGrounded);
        animator.SetFloat("velocityY", rb.velocity.y);    
        animator.SetBool("isAttacking", isAttacking);
        animator.SetInteger("comboCounter", comboCounter);
    }
    public void attackAnEnemy()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(damagePos.position, damagePosRadius, whatIsEnemy);
        foreach (Collider2D enemyGameObject in enemy) //foreach object with layermask whatIsEnemy represented by enemyGameObject
        {
            enemyGameObject.GetComponentInParent<EnemyHealth>().health -= damage;
        }
    }
    public void defenceFromEnemy()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(defenceZone.position,defenceZoneRadius, whatIsEnemy);
        foreach(Collider2D enemyGameObject in enemy)
        {
            enemyGameObject.GetComponentInParent<Enemy_behaviour>().Force();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * playerSpeed, rb.velocity.y);    
    }
    
    void checkCollisions()
    {
        isGrounded = Physics2D.OverlapCircle(groundPos.position, groundPosRadius, whatisGround);
    }

  
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundPos.position, groundPosRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(damagePos.position, damagePosRadius);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(defenceZone.position, defenceZoneRadius);
    }
}
