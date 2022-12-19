using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Tower : MonoBehaviour
{
    private Rigidbody rb;
    public int maxHealth = 100;
    public int curHealth;
    public int damage = 20;
    public float attackSpeech = 1f;
    public float range;
    public float countAttackTime;
    public HealthBar healthBar;
    public Player player;
    bool Attack= false;
    public Animator anima;
    private Transform target;
    private Player targetPlayer;
    public GameObject danprefab;
    public Dan dan;
    public Transform shootingpoint;
    
    void Start()
    {
        //player = FindObjectOfType<Player>();
        rb = this.GetComponent<Rigidbody>();
        //dan1 = dan1.GetComponent<Rigidbody>();
       // dan1 = dan1.GetComponent<Dan>();
        curHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        anima = gameObject.GetComponent<Animator>();
        countAttackTime = attackSpeech;
    }

    void Update()
    {
        
        //float Dis = Vector3.Distance(transform.position,player.transform.position);
        countAttackTime -= Time.deltaTime;
        if (countAttackTime <= 0 && Attack)
        {
            
            towerAttack();

        }

        if (player.curHealth <= 0)
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
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player newPlayer= other.gameObject.GetComponent<Player>();
            player = newPlayer;
           // player = other.gameObject.GetComponent<Player>();
        }
        if ((other.gameObject.tag == "Player") && player.curHealth > 0)
        {
            Attack = true;
            player.anima.SetBool("Gethit", true);
        }
    }
  
    void towerAttack()
    {
        countAttackTime = attackSpeech;
        if (player.curHealth > 0)
        {
            player.TakeDamage(damage);
        }
        //Dan newdan = dan.gameObject.GetComponent<Dan>();
        GameObject newdan = Instantiate(danprefab, shootingpoint.position, transform.rotation);
         //newdan.gameObject.SetActive(true);
       // newdan = dan.gameObject.GetComponent<Dan>();
    }
    //void UpdateTarget()
    //{
    //    GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
    //    float shortestDistance = Mathf.Infinity;
    //    GameObject nearestEnemy = null;
    //    foreach (GameObject player in players)
    //    {
    //        float distanceToEnemy = Vector3.Distance(transform.position, player.transform.position);
    //        if (distanceToEnemy < shortestDistance)
    //        {
    //            shortestDistance = distanceToEnemy;
    //            nearestEnemy = player;
    //        }
    //    }

    //    if (nearestEnemy != null && shortestDistance <= range)
    //    {
    //        target = nearestEnemy.transform;
    //        targetPlayer = nearestEnemy.GetComponent<Player>();
    //    }
    //    else
    //    {
    //        target = null;
    //    }

    //}
}
