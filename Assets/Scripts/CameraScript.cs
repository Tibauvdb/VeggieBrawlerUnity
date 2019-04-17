using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public static Transform MainCameraTransform { get; private set; }
    //tracking
    [SerializeField] private float _followSpeed;
    [SerializeField] private Vector3 _offset;
    public List<Transform> ObjectsToTrack = new List<Transform>();
    Bounds _bounds = new Bounds();
    private Vector3 _vel;

    //shake
    [SerializeField, Range(0, 20), Space] private float _shakeDampen; //arbitrary range, anything above 20 barely makes a difference
    private static float _shake;
    private Transform _cam;

    private void Start()
        {
        _cam = transform.Find("Camera");
        MainCameraTransform = _cam;
        }

    // Update is called once per frame
    void Update()
    {
        //tracking
        transform.position = Vector3.SmoothDamp(transform.position, GetBoundsCenter() + _offset, ref _vel, _followSpeed * Time.deltaTime);

        //shaking
        if (Time.timeScale > 0)
            {
            _cam.transform.localPosition = new Vector3(Random.Range(-_shake, _shake), Random.Range(-_shake, _shake), 0);
            _shake = Mathf.Lerp(_shake, 0, _shakeDampen * Time.deltaTime);
            }
    }

    public static void Shake(float power)
        {
        _shake = power;
        }

    private Vector3 GetBoundsCenter()
        {
        Bounds bounds = new Bounds(ObjectsToTrack[0].position, Vector3.zero);
        if (ObjectsToTrack.Count > 0)
            {
            foreach (Transform item in ObjectsToTrack)
                {
                if (item)
                    bounds.Encapsulate(item.position);
                }
            }
        return bounds.center;
        }
}
