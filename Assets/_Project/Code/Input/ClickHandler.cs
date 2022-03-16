using UnityEngine;
using UnityEngine.Events;

namespace SquareDino.RechkinTestTask.Input
{
    public class ClickHandler : MonoBehaviour
    {
        public event UnityAction<Vector3> Clicked;

        private void Update()
        {
            if (UnityEngine.Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
                Vector3 worldClickPosition;
                if (Physics.Raycast(ray, out RaycastHit hit))
                    worldClickPosition = hit.point;
                else
                    worldClickPosition =
                        Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition + Vector3.forward * 30f);
                Clicked?.Invoke(worldClickPosition);
            }
        }
    }
}