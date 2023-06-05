using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HomeWork0605
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] Transform spawnPoint;
        [SerializeField] float spawnTime;
        [SerializeField] GameObject spawnTarget;

        private void OnEnable()
        {
            StartCoroutine(SpawnRoutine());
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        IEnumerator SpawnRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(spawnTime);
                Instantiate(spawnTarget, spawnPoint.position, spawnPoint.rotation);
            }
        }
    }
}
