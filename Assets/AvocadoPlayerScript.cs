using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvocadoPlayerScript : MonoBehaviour
{
    public GameObject FireGameobject;
    [SerializeField] private float _lerpSpeed;
    private Material _fireMaterial;

    private bool _startFireShader = false;
    // Start is called before the first frame update
    void Start()
    {
        _fireMaterial = FireGameobject.GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (_startFireShader)
            LerpFireShader();
        else
            ResetFireShader();

    }

    public void setBool()
    {
        _startFireShader = !_startFireShader;
    }

    public void LerpFireShader()
    {
        _fireMaterial.SetFloat("Vector1_E1258AB5", lerpValue(_fireMaterial.GetFloat("Vector1_E1258AB5"), 0));
    }

    public void ResetFireShader()
    {
        _fireMaterial.SetFloat("Vector1_E1258AB5", lerpValue(_fireMaterial.GetFloat("Vector1_E1258AB5"), .5f));
        if (_fireMaterial.GetFloat("Vector1_E1258AB5") > 0.49f)
            _fireMaterial.SetFloat("Vector1_E1258AB5", 1);
    }

    private float lerpValue(float lerpThis, float endValue)
    {
        lerpThis = Mathf.Lerp(lerpThis, endValue, Time.deltaTime * _lerpSpeed);
        return lerpThis;
    }
}
