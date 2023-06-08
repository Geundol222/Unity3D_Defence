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

            buttons["Blocker"].onClick.AddListener(() => { GameManager.UI.CloseInGameUI<InGameUI>(this); });
        }

        public void BuildBarrackTower()
        {

        }
    }
}

