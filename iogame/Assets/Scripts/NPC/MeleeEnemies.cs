using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MeleeEnemies : Enemy
{
    public Slider slider; 
    public int state = 1;
    private float _timeLeft;
    private Vector2 _movement;
    public Rigidbody2D rb;
    public Pathfinding.AIPath ai;
    public float currentHealth;



    private void Start()
    {
        // CHANGE FOR MULTIPLE STATES LATER
        state = 2;
        currentHealth = ((EnemyInfo)npcInfo).health;
        slider.maxValue = currentHealth;
        slider.value = currentHealth;
    }

    public override void UseItem()
    {
        // add attack code
    }

    private void Update(){   
        if (currentHealth <= 0){
            Destroy(gameObject);
        }
        slider.value = currentHealth;
        switch (state)
        {
            case 1:
                // Search
                ai.enabled = false;
                _timeLeft -= Time.deltaTime;
                if (_timeLeft <= 0)
                {
                    _movement = new Vector2(Random.Range(-1, 1f), Random.Range(-1, 1f));
                    _timeLeft += ((EnemyInfo)npcInfo).accelerationTime;
                }
                break;
        
            case 2:
                // Follow
                ai.enabled = true;
                break;
        
            default:
                // Handle other states
                break;
        }
    }

    private void FixedUpdate()
    {
        if (state == 1){
            rb.AddForce(_movement * ((EnemyInfo)npcInfo).moveSpeed);
        }
    }

    public void TakeDamage(float damage){
        currentHealth -= damage;
    }
}