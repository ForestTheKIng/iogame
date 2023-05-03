using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Weapons/New Melee")]
public class MeleeInfo : ItemInfo
{
    public float damage;
    public float slashDelay;
    public float moveSpeed;
    public float range;
}