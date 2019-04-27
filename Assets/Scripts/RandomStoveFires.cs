using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomStoveFires : MonoBehaviour
{
    public List<GameObject> PossibleFires = new List<GameObject>();
    public float WaitTimeBetweenFires;

    private int _activeFire;
    private float _timer;

    private bool _allowFireSpawning = true;

    private bool _lerpingFire = true;

    private float _currEndValue;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFire());
    }

    // Update is called once per frame
    void Update()
    {
        lerpFire(_currEndValue);
    }

    private void SpawnRandomFire()
    {
        _activeFire = Random.Range(0, PossibleFires.Count);

        PossibleFires[_activeFire].SetActive(true);
    }

    private void lerpFire(float endValue)
    {
        PossibleFires[_activeFire].GetComponent<MeshRenderer>().material.SetFloat("Vector1_E1258AB5", LerpOffset(PossibleFires[_activeFire].GetComponent<MeshRenderer>().material.GetFloat("Vector1_E1258AB5"), endValue));
    }

    private IEnumerator SpawnFire()
    {
        while (_allowFireSpawning)
        {
            yield return new WaitForSecondsRealtime(WaitTimeBetweenFires);
            _currEndValue = 0;
            SpawnRandomFire();
            yield return new WaitForSecondsRealtime(WaitTimeBetweenFires);
            _currEndValue = 0.5f;
            yield return new WaitForSecondsRealtime(WaitTimeBetweenFires);
            PossibleFires[_activeFire].SetActive(false);
        }
    }

    private float LerpOffset(float value,float endValue)
    {
        value = Mathf.Lerp(value, endValue, Time.deltaTime * 2);
        return value;
    }
}
