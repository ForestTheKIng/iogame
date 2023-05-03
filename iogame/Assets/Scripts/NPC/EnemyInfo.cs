using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "NPCs/New Enemy")]
public class EnemyInfo : NPCInfo
{
    public float health;
    public float accelerationTime;
    public float moveSpeed;

}