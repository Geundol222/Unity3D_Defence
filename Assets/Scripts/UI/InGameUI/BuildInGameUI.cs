using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildInGameUI : InGameUI
{
    public TowerPlace towerPlace;

    protected override void Awake()
    {
        base.Awake();

        buttons["Blocker"].onClick.AddListener(() => { GameManager.UI.CloseInGameUI<BuildInGameUI>(this); });
        buttons["ArcherButton"].onClick.AddListener(BuildArcherTower);
        buttons["CanonButton"].onClick.AddListener(BuildCanonTower);
    }

    public void BuildArcherTower()
    {
        TowerData archerTowerData = GameManager.Resource.Load<TowerData>("Data/ArcherTowerData");
        towerPlace.BuildTower(archerTowerData);
    }

    public void BuildCanonTower()
    {
        TowerData canonTowerData = GameManager.Resource.Load<TowerData>("Data/CanonTowerData");
        towerPlace.BuildTower(canonTowerData);
    }
}