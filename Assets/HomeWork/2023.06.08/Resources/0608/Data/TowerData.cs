using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HomeWork0608
{
    [CreateAssetMenu (fileName = "TowerData", menuName = "0608/Data/Tower")]
    public class TowerData : ScriptableObject
    {
        [SerializeField] TowerInfo[] towers;

        public TowerInfo[] Towers { get { return towers; } }

        [Serializable]
        public class TowerInfo
        {
            public Tower tower;

            public int damage;
            public float reload;
            public float range;

            public int buildTime;
            public int buildCost;
            public int sellCost;
        }
    }
}

