using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy; // enemy object
    public float health; // health amount
    public float damage; // damage amount

    public Slider slider; // health slider
    public Transform  floatingText, bloodParticle; // bullet and floating text
    public Transform[] waypoints; // array of waypoints for patrolling
    private int currentWaypointIndex = 0; // current waypoint index
    public float moveSpeed; // movement speed
    public Transform firePoint; // point from where bullets are fired
    public GameObject bulletPrefab; // bullet prefab
    public float bulletSpeed; // speed of the bullet
    public float fireRate; // rate of fire
    private float nextFireTime; // time until the next shot

    void Start()
    {
        slider.maxValue = health; // set max value of slider to health
        slider.value = health; // set current value of slider to health
    }

    void Update()
    {
        Patrol();
        TryToShoot();
    }

    private void Patrol()
    {
        if (waypoints.Length == 0) return;

        // Move towards the current waypoint
        Transform targetWaypoint = waypoints[currentWaypointIndex];
        transform.position = Vector2.MoveTowards(transform.position, targetWaypoint.position, moveSpeed * Time.deltaTime);

        // Check if the enemy reached the current waypoint
        if (Vector2.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }

    private void TryToShoot()
    {
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // collider interaction  && !colliderBusy
        if (collision.tag == "Player" )
        {
           
            collision.GetComponent<PlayerManager>().GetDamage(damage);
        }
        else if (collision.tag == "bullet")
        {
            GetDamage(collision.GetComponent<BulletManager>().bulletDamage);
            Destroy(collision.gameObject);
        }
    }

    public void GetDamage(float damage)
    {
        Instantiate(floatingText, transform.position, Quaternion.identity).GetComponent<TextMesh>().text = damage.ToString();
        // Show damage as text
        if ((health - damage) >= 0)
        {
            health -= damage;
        }
        else
        {
            health = 0;
        }
        slider.value = health;
        AmIDead();
    }

    void AmIDead()
    {
        if (health <= 0)
        {
            Destroy(Instantiate(bloodParticle, transform.position, Quaternion.identity), 3f);
            DataManager.Instance.EnemyKilled++;
            Destroy(gameObject); // Destroy the enemy game object
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // collider interaction
        if (collision.tag == "Player")
        {
           
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // collider interaction
        if (collision.tag == "Player")
        {
           
        }
    }
}
