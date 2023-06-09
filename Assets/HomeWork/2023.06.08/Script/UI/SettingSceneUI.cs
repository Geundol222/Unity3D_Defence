using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HomeWork0608
{
    public class SettingSceneUI : SceneUI
    {
        protected override void Awake()
        {
            base.Awake();

            buttons["InfoButton"].onClick.AddListener(OpenInfoWindowUI);
            buttons["VolumeButton"].onClick.AddListener(() => { Debug.Log("VOLUME"); });
            buttons["SettingButton"].onClick.AddListener(OpenPausePopUpUI);
        }

        public void OpenInfoWindowUI()
        {
            GameManager.UI.OpenWindowUI<WindowUI>("0608/UI/InfoWindowUI");
        }

        public void OpenPausePopUpUI()
        {
            GameManager.UI.OpenPopUpUI<PopUpUI>("0608/UI/SettingPopUpUI");
        }
    }
}