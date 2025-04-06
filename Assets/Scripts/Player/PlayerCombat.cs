using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public int attackDamage = 40;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attack();
                nextAttackTime = Time.time + 1f/attackRate;
            }
        }
    }

    void Attack()
    {
        if (animator == null)
        {
            Debug.LogError("Animator is not assigned!");
            return;
        }

        if (attackPoint == null)
        {
            Debug.LogError("AttackPoint is not assigned!");
            return;
        }

        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Enemy enemyScript = enemy.GetComponent<Enemy>();
            BossHealth bossScript = enemy.GetComponent<BossHealth>();

            if (enemyScript != null)
            {
                enemyScript.TakeDamage(attackDamage);
            }
            else if (bossScript != null)
            {
                bossScript.TakeDamage(attackDamage);
            }
            else
            {
                Debug.LogWarning("Enemy script missing on object: " + enemy.name);
            }
        }
    }



    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
