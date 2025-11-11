using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragSystem : MonoBehaviour
{
    public static DragSystem Instance { get; private set; }
    public IDragObject Current { get; private set; }
    public event Action<IDragObject> OnDragCanceled;
    public event Action<IDragObject> OnDragEnded;

    private Canvas _canvas;
    private RectTransform _canvasRect;
    private Camera _camera => _canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : _canvas.worldCamera;
    private Transform _transform;
    private List<RaycastResult> _results = new();
    private IDragDropZone _dragDropZone;
    
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void OnBeforeSceneLoad()
    {
        if (FindObjectOfType<DragSystem>() == null)
        {
            GameObject self = new GameObject("DragSystem");
            Instance = self.AddComponent<DragSystem>();
            DontDestroyOnLoad(self);
        }
    }

    public void StartDrag(IDragObject target)
    {
        if (Current != null)
            CancelDrag();
        
        MonoBehaviour mono = target as MonoBehaviour;
        if (mono == null)
            throw new ArgumentException("Target must be MonoBehaviour");
        
        Current = target;
        _canvas = mono.gameObject.GetComponentInParent<Canvas>();
        if (_canvas == null)
            _canvas = mono.gameObject.GetComponent<Canvas>();
        _canvasRect = _canvas.GetComponent<RectTransform>();
        _transform = mono.gameObject.transform;
        _transform.SetParent(_canvas.transform, true);
    }

    public void CompleteDrag()
    {
        if (_dragDropZone == null)
        {
            CancelDrag();
        }
        else
        {
            EndDrag();
        }
    }

    public void EndDrag()
    {
        if (Current == null)
            return;
        
        OnDragEnded?.Invoke(Current);
        _dragDropZone.Accept(Current);
        Current = null;
        DestroyDragObject();
    }

    public void CancelDrag()
    {
        if (Current == null)
            return;
        
        OnDragCanceled?.Invoke(Current);
        OnDragEnded?.Invoke(Current);
        Current = null;
        DestroyDragObject();
    }

    private void DestroyDragObject()
    {
        if (_transform)
            Destroy(_transform.gameObject);
        _canvas = null;
        _canvasRect = null;
        ClearDropZone();
    }

    private void ClearDropZone()
    {
        if (_dragDropZone == null)
            return;
        
        _dragDropZone.EndAccepting();
        _dragDropZone = null;
    }

    private void Update()
    {
        if (Current == null || _canvas == null)
            return;
        
        RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvasRect, Input.mousePosition, _camera, out Vector2 localPoint);
        _transform.localPosition = localPoint;
        
        EventSystem.current.RaycastAll(new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition,
        }, _results);

        bool found = false;
        foreach (RaycastResult result in _results)
        {
            if (result.gameObject.GetComponent<IDragObject>() != null)
                continue;

            if (result.gameObject.TryGetComponent(out IDragDropZone dropZone))
            {
                if (dropZone.CanAccept(Current))
                {
                    if (dropZone != _dragDropZone)
                    {
                        ClearDropZone();
                    }
                    else
                    {
                        found = true;
                        break;
                    }

                    _dragDropZone = dropZone;
                    _dragDropZone.BeginAccepting(Current);
                    found = true;
                    break;
                }
                else
                {
                    continue;
                }
            }
            else
            {
                break;
            }
        }

        if (found == false)
        {
            ClearDropZone();
        }

        if (Input.GetMouseButtonUp(0))
        {
            CompleteDrag();
        }
    }
}