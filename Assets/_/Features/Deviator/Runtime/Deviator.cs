using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Deviator.Runtime
{
    public class Deviator : MonoBehaviour
    {

        #region Unity Api

        private void Update()
        {
            if (_isMouseDragging) transform.position = new Vector2(ChangeObjectPosition().x, ChangeObjectPosition().y);
        }
        private void OnMouseDown()
        {
            _isMouseDragging = true;
        }
        private void OnMouseUp()
        {
            _isMouseDragging= false;
        }

        #endregion

        #region Utils

        private Vector3 ChangeObjectPosition()
        {
            return Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        #endregion


        #region Private & Protected
        [SerializeField] Texture2D _mouseTexture;
        bool _isMouseDragging = false;

        #endregion
    }
}
