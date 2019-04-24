using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    //private GameObject _player;
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
            Debug.Log("Player Left");
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
                player.GetComponent<PlayerScript>().Health -= 1;
            }
            yield return new WaitForSecondsRealtime(1f);
        }
    }
}
