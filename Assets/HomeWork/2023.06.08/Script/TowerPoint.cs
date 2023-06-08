using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HomeWork0608
{
    public class TowerPoint : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        [SerializeField] Color normal;
        [SerializeField] Color onMouse;

        private Renderer render;

        private void Awake()
        {
            render = gameObject.GetComponent<Renderer>();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
                Debug.Log("LeftClick");
            else
                return;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            render.material.color = onMouse;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            render.material.color = normal;
        }
    }
}