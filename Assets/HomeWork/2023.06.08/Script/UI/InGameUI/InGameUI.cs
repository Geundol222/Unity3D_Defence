using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HomeWork0608
{
    public class InGameUI : BaseUI
    {
        private Transform target;
        private Vector2 offset;

        public TowerPoint towerPoint;

        private void LateUpdate()
        {
            if (target == null)
                GameManager.UI.CloseInGameUI<InGameUI>(this);

            if (target != null)
            {
                transform.position =Camera.main.WorldToScreenPoint(target.position) + (Vector3)offset;
            }
        }

        public void SetTarget(Transform target)
        {
            this.target = target;
            if (target != null)
            {
                transform.position = Camera.main.WorldToScreenPoint(target.position) + (Vector3)offset;
            }
        }

        public void SetOffset(Vector3 offset)
        {
            this.offset = offset;
            if (target != null)
            {
                transform.position = Camera.main.WorldToScreenPoint(target.position) + (Vector3)offset;
            }
        }
    }
}

