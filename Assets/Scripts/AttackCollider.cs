using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AttackCollider : MonoBehaviour
{
    private PlayerScript _player;
    public PlayerScript Opponent { get; private set; }
    public Vector3 HitOrigin { get=> transform.position; }

    private void Start()
    {
        _player = transform.root.GetComponent<PlayerScript>(); //I know this is bad, shut up <3
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerScript hitPlayer = other.GetComponent<PlayerScript>();

        if(hitPlayer!=null && hitPlayer != _player)
        {
            Opponent = hitPlayer;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerScript hitPlayer = other.GetComponent<PlayerScript>();

        if (hitPlayer == Opponent)
        {
            Opponent = null;
        }
    }
}
