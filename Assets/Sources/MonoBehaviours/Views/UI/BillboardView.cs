using UnityEngine;

namespace RustedGames
{
	public sealed class BillboardView : MonoBehaviour
	{
		private Transform cameraTransform = default;

        private void Start()
        {
            cameraTransform = Camera.main.transform;
        }

        private void LateUpdate()
        {
            if (cameraTransform == null) return;

            transform.LookAt(cameraTransform);
            transform.Rotate(0f, 180f, 0f);
        }
    }
}