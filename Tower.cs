using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private Rigidbody rb;
    public int maxHealth = 100;
    public int curHealth;
    public int damage = 10;
    public HealthBar healthBar;
    Player player;
    bool isAttacked= false;
    void Start()
    {
        player= GetComponent<Player>();
        rb = this.GetComponent<Rigidbody>();
        curHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (isAttacked == true) { TakeDamage(player.damage); }
    }
    void TakeDamage(int damage)
    {
        curHealth -= damage;
        healthBar.SetHealth(curHealth);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "sword")
        {
            isAttacked= true;

        }
    }
}
