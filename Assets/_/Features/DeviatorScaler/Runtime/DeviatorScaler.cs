using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Deviator.Runtime;
public class DeviatorScaler : MonoBehaviour
{
    // Start is called before the first frame update
    #region Unity Api

    private void Awake()
    {
        _initialScale = transform.localScale;
    }
    private void Update()
    {
        if (_isMouseDragging) ChangeObjectScale();
    }
    private void OnMouseDown() => _isMouseDragging = true;

    private void OnMouseDrag() => _posCurrentPress = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    private void OnMouseUp() => _isMouseDragging = false;

    #endregion

    #region Utils

    private void ChangeObjectScale()
    {
        float distanceFromCenter = (_posCurrentPress - (Vector2) transform.position).magnitude;
        if(_minDragUnityValue < distanceFromCenter && distanceFromCenter < _maxDragUnityValue)
        {
            float minMaxDifference = _maxDragUnityValue - _minDragUnityValue;
            var newScaleAdditive = (distanceFromCenter / minMaxDifference)*2;
            transform.localScale = _initialScale + new Vector3(newScaleAdditive, newScaleAdditive, newScaleAdditive);
            //_myDeviator.GetComponent<AreaEffector2D>().forceMagnitude *= newScaleAdditive;
        }
    }

    #endregion


    #region Private & Protected

    [SerializeField] float _maxDragUnityValue;
    [SerializeField] float _minDragUnityValue;
    [SerializeField] Deviator.Runtime.Deviator _myDeviator;
    Vector3 _initialScale;
    bool _isMouseDragging = false;
    Vector2 _posCursorDown;
    Vector2 _posCurrentPress;

    #endregion
}
