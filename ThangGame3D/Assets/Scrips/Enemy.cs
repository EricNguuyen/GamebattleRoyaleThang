using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody rb;
    public List<Transform> waypoints;
    private Transform lastPosition => waypoints[waypoints.Count - 1];
    public float moveSpeed = 4f;
    Vector3 targetPosition;
    int waypointIndex = 0;
    int index = 1;
    public Animator anima;
    public int maxHealth = 100;
    public int curHealth;
    public int damage = 10;
    public float attackSpeech;
    float countAttackTime;
    bool attack = false;
    public HealthBar healthBar;
    public Transform targetTransform;
    public Tower tower;
    void Start()
    {
        countAttackTime = attackSpeech;
        rb = this.GetComponent<Rigidbody>();
        transform.position = waypoints[waypointIndex].position;
        UpdateTransform();
        anima = gameObject.GetComponent<Animator>();
        curHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()

    {
        countAttackTime -= Time.deltaTime;
        if (countAttackTime <= 0 && attack)
        {
            Attack();

        }
        if (tower.curHealth <= 0 || tower.gameObject == null)
        {
            anima.SetBool("attack", false);
            attack = false;
            Destroy(tower.gameObject);
            return;
        }
        if (curHealth <= 0)
        {
            //anima.SetBool("Die", true);
            anima.SetTrigger("Die 0");
            anima.SetBool("attack", false);
            attack = false;
        }

        if (lastPosition == targetTransform)
        {
            var distance = Vector3.Distance(targetPosition, transform.position);
            if (distance <= 1.5)
                return;
        }
        Vector3 direction = targetPosition - transform.position;
        transform.rotation = Quaternion.LookRotation(direction);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        float dist = Vector3.Distance(targetPosition, transform.position);
        if (dist <= 0.4f) { UpdateTransform(); }

    }
    private void UpdateTransform()
    {
        waypointIndex += index;
        if (waypointIndex > waypoints.Count)
            return;
        targetTransform = waypoints[waypointIndex];
        targetPosition = targetTransform.position;

    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Tower Player" && tower.curHealth > 0)
        {
            anima.SetBool("attack", true);
            attack = true;
        }

    }
    public void TakeDamage(int damage)
    {
        curHealth -= damage;
        healthBar.SetHealth(curHealth);
    }
    void Attack()
    {
        countAttackTime = attackSpeech;
        if (tower.curHealth > 0)
        {
            tower.TakeDamage(damage);
        }
    }
}
