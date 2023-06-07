using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HomeWork0607
{
    public class GameSceneUI : BaseUI
    {
        protected override void Awake()
        {
            base.Awake();

            buttons["InfoButton"].onClick.AddListener(() => { Debug.Log("INFO"); });
            buttons["VolumeButton"].onClick.AddListener(() => { Debug.Log("VOLUME"); });
            buttons["SettingButton"].onClick.AddListener(OpenPausePopUpUI);
        }

        private void OpenPausePopUpUI()
        {
            GameManager.UI.OpenPopUpUI<PopUpUI>("0607/SettingPopUpUI");
        }
    }
}