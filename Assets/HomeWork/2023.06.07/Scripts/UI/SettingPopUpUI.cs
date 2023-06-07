using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HomeWork0607
{
    public class SettingPopUpUI : PopUpUI
    {
        protected override void Awake()
        {
            base.Awake();

            buttons["ContinueButton"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); });
            buttons["SettingButton"].onClick.AddListener(() => { GameManager.UI.OpenPopUpUI<PopUpUI>("0607/ConfigPopUpUI"); });
        }
    }
}