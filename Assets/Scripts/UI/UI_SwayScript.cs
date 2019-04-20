using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_SwayScript : MonoBehaviour
    {
    [SerializeField] private Vector3 _amplitude;
    [SerializeField] private Vector3 _rotAmplitude;
    [SerializeField] private Vector3 _frequency;
    [SerializeField] private Vector3 _rotFrequency;
    [SerializeField] private int _offset;
    [SerializeField] private bool _multiplyOffsetByChildIndex;

    private RectTransform _rect;
    private Vector3 _startPosition;

    // Start is called before the first frame update
    void Start()
        {
        _rect = GetComponent<RectTransform>();
        _startPosition = _rect.anchoredPosition;

        if (_multiplyOffsetByChildIndex)
            {
            for (int i = 0; i < transform.parent.childCount; i++)
                {
                if (transform.parent.GetChild(i) == transform)
                    {
                    _offset *= i;
                    }
                }
            }
        }

    // Update is called once per frame
    void Update()
        {
        int offsetFramecount = FixedTime.fixedFrameCount + _offset;
        _rect.anchoredPosition = _startPosition + new Vector3(_amplitude.x * Mathf.Sin(offsetFramecount * _frequency.x), _amplitude.y * Mathf.Sin(offsetFramecount * _frequency.y), _amplitude.z * Mathf.Sin(offsetFramecount * _frequency.z));
        transform.eulerAngles = new Vector3(_rotAmplitude.x * Mathf.Sin(offsetFramecount * _rotFrequency.x), _rotAmplitude.y * Mathf.Sin(offsetFramecount * _rotFrequency.y), _rotAmplitude.z * Mathf.Sin(offsetFramecount * _rotFrequency.z));
        }
    }
