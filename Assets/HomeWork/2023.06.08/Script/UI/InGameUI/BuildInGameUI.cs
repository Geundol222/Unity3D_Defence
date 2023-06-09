using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HomeWork0608
{
    public class BuildInGameUI : InGameUI
    {
        protected override void Awake()
        {
            base.Awake();

            buttons["Blocker"].onClick.AddListener(() => { GameManager.UI.CloseInGameUI<BuildInGameUI>(this); });
            buttons["BarrackButton"].onClick.AddListener(BuildBarrackTower);
        }

        public void BuildBarrackTower()
        {
            TowerData barrack = GameManager.Resource.Load<TowerData>("0608/Data/BarrackTowerData");
            towerPoint.BuildTower(barrack);
        }
    }
}

