using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HomeWork0607
{
    public class UIManager : MonoBehaviour
    {
        private EventSystem eventSystem;

        private Canvas popUpCanvas;
        private Stack<PopUpUI> popUpStack;

        private void Awake()
        {
            eventSystem = GameManager.Resource.Instantiate<EventSystem>("0607/EventSystem");
            eventSystem.transform.parent = transform;

            popUpCanvas = GameManager.Resource.Instantiate<Canvas>("0607/Canvas");
            popUpCanvas.gameObject.name = "PopUpCanvas";
            popUpCanvas.sortingOrder = 100;
            popUpStack = new Stack<PopUpUI>();

        }

        public T OpenPopUpUI<T>(T popUpUI) where T : PopUpUI
        {
            if (popUpStack.Count > 0)
            {
                PopUpUI prevUI = popUpStack.Peek();
                prevUI.gameObject.SetActive(false);
            }

            T ui = GameManager.Pool.GetUI(popUpUI);
            ui.transform.SetParent(popUpCanvas.transform, false);

            popUpStack.Push(ui);

            Time.timeScale = 0f;

            return ui;
        }

        public T OpenPopUpUI<T>(string path) where T : PopUpUI
        {
            T ui = GameManager.Resource.Load<T>(path);
            return OpenPopUpUI(ui);
        }

        public void ClosePopUpUI()
        {
            PopUpUI ui = popUpStack.Pop();
            GameManager.Pool.Release<PopUpUI>(ui);

            if (popUpStack.Count > 0)
            {
                PopUpUI curUI = popUpStack.Peek();
                curUI.gameObject.SetActive(true);
            }

            if (popUpStack.Count == 0)
                Time.timeScale = 1f;
        }
    }
}