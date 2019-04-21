using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using RectTransform = UnityEngine.RectTransform;

public class RayShine : MonoBehaviour
{
    public float Speed;
    private RectTransform[] _rays;

    private List<RectTransform> _rayList = new List<RectTransform>();

    private List<float> _rayStartHeights = new List<float>();
    // Start is called before the first frame update
    void Start()
    {
        _rays = transform.GetComponentsInChildren<RectTransform>();
        Debug.Log(_rays.Length);
        _rayList = _rays.ToList();
   
        for (int i = 0; i < _rayList.Count; i++)
        {
            _rayStartHeights.Add(_rayList[i].rect.height);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < _rayList.Count; i++)
        {
            float height = _rayList[i].rect.height;
            height =_rayStartHeights[i] + Mathf.Abs(Mathf.Sin(Time.time) * Speed);
            _rayList[i].sizeDelta = new Vector2(_rayList[i].rect.width, height);
        }

        RotateCanvas();
    }

    private void RotateCanvas()
    {
        transform.Rotate(Vector3.forward,1);
    }
}
