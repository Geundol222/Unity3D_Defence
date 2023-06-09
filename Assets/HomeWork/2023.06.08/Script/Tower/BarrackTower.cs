using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HomeWork0608
{
    public class BarrackTower : Tower
    {
        private void Awake()
        {
            data = GameManager.Resource.Load<TowerData>("0608/Data/BarrackTowerData");
        }
    }
}

