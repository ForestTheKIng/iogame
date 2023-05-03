using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;
using Fusion;

public class Sword : Melee
{
   public Transform attackPoint;
   public LayerMask enemyLayers;
   public ItemHandler lp;
   private bool _canAttack = true;
   [Networked] public int health = 100;

   public override void Use()
   {
      if (_canAttack)
      {
         lp.animator.SetTrigger("attack");
         Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position,
            ((MeleeInfo)lp.items[lp.itemIndex].itemInfo).range, enemyLayers);
         foreach (Collider2D enemy in hitEnemies)
         {
            Debug.Log("hit");
            // Change to fit new enemy structure
            // enemy.GetComponent<Enemy>().TakeDamage(((MeleeInfo)lp.items[lp.itemIndex].itemInfo).damage);
         }
         StartCoroutine(SlashCooldown());
      } 
   }

   private IEnumerator SlashCooldown()
   {
      _canAttack = false;
      yield return new WaitForSeconds(((MeleeInfo)lp.items[lp.itemIndex].itemInfo).slashDelay);
      _canAttack = true;
   }

   void OnDrawGizmosSelected(){
      if (attackPoint == null){
         return;
      }
      Gizmos.DrawWireSphere(attackPoint.position, ((MeleeInfo)lp.items[lp.itemIndex].itemInfo).range);
   }
}
