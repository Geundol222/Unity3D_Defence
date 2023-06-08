using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Audio;

public class ConfigPopUpUI : PopUpUI
{
    protected override void Awake()
    {
        base.Awake();

        buttons["SaveButton"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI<PopUpUI>(); });
        buttons["ExitButton"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI<PopUpUI>(); });
    }
}
