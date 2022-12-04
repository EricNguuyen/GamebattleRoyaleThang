using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlayer : MonoBehaviour
{
    private Rigidbody rb;
    public int maxHealth = 100;
    public int curHealth;
    public int damage = 20;
    public float attackSpeech = 1f;
    public float countAttackTime;
    public HealthBar healthBar;
    public Enemy enemy;
    bool Attack= false;
    public Animator anima;
    void Start()
    {
        //player = FindObjectOfType<Player>();
        rb = this.GetComponent<Rigidbody>();
        curHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        anima = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        countAttackTime -= Time.deltaTime;
        if (countAttackTime <= 0 && Attack)
        {
            
            towerAttack();

        }
        if (enemy.curHealth <= 0)
        {
           // player.anima.SetBool("attack", false);
            Attack = false;
           // return;
            
        }
    }
    public void TakeDamage(int damage)
    {
        curHealth -= damage;
        healthBar.SetHealth(curHealth);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player" && enemy.curHealth > 0)
        {
            Attack = true;
            enemy.anima.SetBool("Gethit", true);
        }
    }
  
    void towerAttack()
    {
        countAttackTime = attackSpeech;
        if (enemy.curHealth > 0)
        {
            enemy.TakeDamage(damage);
        }
    }
}
