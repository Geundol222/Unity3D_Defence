using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] float speed;

    private EnemyController enemy;
    private Vector3 targetPosition;
    private int damage;

    public void SetTarget(EnemyController enemy)
    {
        this.enemy = enemy;
        targetPosition = enemy.transform.position;
        StartCoroutine(ArrowRoutine());
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    IEnumerator ArrowRoutine()
    {
        while (true)
        {
            if (enemy != null)
                targetPosition = enemy.transform.position;

            // Vector3 vector = (enemy.transform.position - transform.position);
            // Vector3 dir = vector.normalized;
            // 
            // transform.Translate(dir * speed * Time.deltaTime, Space.World);
            transform.LookAt(targetPosition);
            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);

            if (Vector3.Distance(targetPosition, transform.position) < 0.1f)
            {
                if (enemy != null)
                    Attack(enemy);
                GameManager.Resource.Destroy(gameObject);
                yield break;
            }

            yield return null;
        }
    }

    public void Attack(EnemyController enemy)
    {
        enemy.TakeDamage(damage);
    }
}
