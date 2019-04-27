using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private int _healthLoss;
    private List<GameObject> _players = new List<GameObject>();
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //_player = other.gameObject;
            Debug.Log(other.gameObject.name);
            _players.Add(other.gameObject);
            StartCoroutine(BurnPlayer());
        }
    }

    void OnTriggerExit(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            _players.Remove(other.gameObject);
            if(_players.Count==0)
                StopAllCoroutines();
        }
    }

    private IEnumerator BurnPlayer()
    {
        while (_players.Count >= 1)
        {
            foreach (GameObject player in _players)
            {
                if(GetComponent<MeshRenderer>().material.GetFloat("Vector1_E1258AB5") <0.25f)
                    player.GetComponent<PlayerScript>().Health -= _healthLoss;
            }
            yield return new WaitForSecondsRealtime(1f);
        }
    }
}
