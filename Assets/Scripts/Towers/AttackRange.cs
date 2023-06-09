using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackRange : MonoBehaviour
{
    //public Tower tower;
    public LayerMask enemyMask;

    public UnityEvent<EnemyController> OnInRangeEnemy;
    public UnityEvent<EnemyController> OnOutRangeEnemy;

    private void OnTriggerEnter(Collider other)
    {
        // if (((1 << other.gameObject.layer) & enemyMask) != 0) { }

        if (enemyMask.IsContain(other.gameObject.layer))        // 확장메서드
        {
            EnemyController enemy = other.GetComponent<EnemyController>();
            //tower.AddEnemy(enemy);
            enemy.OnDied.AddListener(() => { OnOutRangeEnemy?.Invoke(enemy); });
            OnInRangeEnemy?.Invoke(enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (enemyMask.IsContain(other.gameObject.layer))
        {
            EnemyController enemy = other.GetComponent<EnemyController>();
            //tower.RemoveEnemy(enemy);
            OnOutRangeEnemy?.Invoke(enemy);
        }
    }
}
