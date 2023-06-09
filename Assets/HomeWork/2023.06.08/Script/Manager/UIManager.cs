using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HomeWork0608
{
    public class UIManager : MonoBehaviour
    {
        private EventSystem eventSystem;

        private Canvas popUpCanvas;
        private Stack<PopUpUI> popUpStack;

        private Canvas windowCanvas;

        private Canvas inGameCanvas;

        private void Awake()
        {
            eventSystem = GameManager.Resource.Instantiate<EventSystem>("0608/UI/EventSystem");
            eventSystem.transform.parent = transform;

            popUpCanvas = GameManager.Resource.Instantiate<Canvas>("0608/UI/Canvas");
            popUpCanvas.gameObject.name = "PopUpCanvas";
            popUpCanvas.sortingOrder = 100;
            popUpStack = new Stack<PopUpUI>();

            windowCanvas = GameManager.Resource.Instantiate<Canvas>("0608/UI/Canvas");
            windowCanvas.gameObject.name = "WindowCanvas";
            windowCanvas.sortingOrder = 50;

            inGameCanvas = GameManager.Resource.Instantiate<Canvas>("0608/UI/Canvas");
            inGameCanvas.gameObject.name = "InGameCanvas";
            inGameCanvas.sortingOrder = 0;
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

        public void ClosePopUpUI<T>() where T : PopUpUI
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

        public T OpenWindowUI<T>(T windowUI) where T : WindowUI
        {
            T ui = GameManager.Pool.GetUI(windowUI);
            ui.transform.SetParent(windowCanvas.transform, false);

            return ui;
        }

        public T OpenWindowUI<T>(string path) where T : WindowUI
        {
            T ui = GameManager.Resource.Load<T>(path);
            return OpenWindowUI(ui);
        }

        public void SelectWindowUI<T>(T windowUI) where T : WindowUI
        {
            windowUI.transform.SetAsLastSibling();
        }

        public void CloseWindowUI<T>(T windowUI) where T : WindowUI
        {
            GameManager.Pool.Release<T>(windowUI);
        }

        public T OpenInGameUI<T>(T inGameUI) where T : InGameUI
        {
            T ui = GameManager.Pool.GetUI<T>(inGameUI);
            ui.transform.SetParent(inGameCanvas.transform, false);

            return ui;
        }

        public T OpenInGameUI<T>(string path) where T : InGameUI
        {
            T ui = GameManager.Resource.Load<T>(path);
            return OpenInGameUI(ui);
        }

        public void CloseInGameUI<T>(T inGameUI) where T : InGameUI
        {
            GameManager.Pool.Release<T>(inGameUI);
        }
    }
}