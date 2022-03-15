using System;
using UnityEngine;
using UnityEngine.Events;

namespace SquareDino.RechkinTestTask.Input
{
    public class ClickHandler : MonoBehaviour
    {
        public event UnityAction<Vector3> Clicked;

        private void Update()
        {
            if (UnityEngine.Input.GetMouseButton(0))
            {
                Vector3 worldClickPosition = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
                Clicked?.Invoke(worldClickPosition);
            }
        }
    }
}