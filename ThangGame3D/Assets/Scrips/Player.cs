using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    
    private Rigidbody rb;
    public List<Transform> waypoints;
    public float moveSpeed = 2f;
    Vector3 targetPosition;
    int waypointIndex = 0;
    int index = 1;
    public Animator anima;
    public int maxHealth = 100;
    public int curHealth;
    public int damage = 10;
    public HealthBar healthBar;
    void Start()
    {
        rb= this.GetComponent<Rigidbody>();
        transform.position = waypoints[waypointIndex].position;
        UpdateTransform();
        anima = gameObject.GetComponent<Animator>();
        curHealth= maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        Vector3 direction = transform.position - targetPosition;

        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //Quaternion quaternion = Quaternion.AngleAxis(angle, Vector3.forward);
        //transform.rotation = Quaternion.Slerp(transform.rotation, quaternion, 1 * Time.deltaTime);
        float dist = Vector3.Distance(targetPosition, transform.position);
        if (dist <= 0.4f) { UpdateTransform(); }
        if (Input.GetKeyDown(KeyCode.Space)) { TakeDamage(20); }

    }
    private void UpdateTransform()
    {
        
            waypointIndex += index;
            targetPosition = waypoints[waypointIndex].position;
        
        
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag =="Tower")
        {
            anima.SetBool("attack", true);
           
        }

    }
    void TakeDamage(int damage)
    {
        curHealth-=damage;
        healthBar.SetHealth(curHealth);
    }    
}
