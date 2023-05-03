using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OldEnemy : MonoBehaviour
{
    public int monsterID;
    public float health;
    public Slider slider; 
    public int state = 1;
    private float timeLeft;
    public float accelerationTime = 2f;
    private Vector2 movement;
    public Rigidbody2D rb;
    public float moveSpeed;
    public Pathfinding.AIPath ai;


    void Start(){
        if (monsterID == 1){
            health = 100;
            slider.maxValue = health;
            slider.value = health;
            moveSpeed = 1f;
        }
    }

    void Update(){  
        if (health <= 0){
            Destroy(gameObject);
        }
        slider.value = health;
        if (state == 1){
            // Search
            ai.enabled = false;
            timeLeft -= Time.deltaTime;
            if(timeLeft <= 0)
            {
                movement = new Vector2(Random.Range(-1, 1f), Random.Range(-1, 1f));
                timeLeft += accelerationTime;
            }
            

        } else if (state == 2){
            // Follow
            ai.enabled = true;
        }
    }

    void FixedUpdate()
    {
        if (state == 1){
            rb.AddForce(movement * moveSpeed);
        }
    }

    public void TakeDamage(float damage){
        health -= damage;
    }
}