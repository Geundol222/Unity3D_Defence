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
            {
                BuildInGameUI buildUI = GameManager.UI.OpenInGameUI<BuildInGameUI>("0608/UI/BuildInGameUI");
                buildUI.SetTarget(transform);
                buildUI.SetOffset(new Vector2(0, 200f));
                buildUI.towerPoint = this;
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            render.material.color = onMouse;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            render.material.color = normal;
        }

        public void BuildTower(TowerData data)
        {
            GameManager.Resource.Destroy(gameObject);
            GameManager.Resource.Instantiate(data.Towers[0].tower, transform.position, transform.rotation);
        }
    }
}