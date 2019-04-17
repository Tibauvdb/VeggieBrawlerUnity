using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundColliderScript : MonoBehaviour {

    private HashSet<Collider> _col = new HashSet<Collider>();

    public bool isGrounded()
        {
        return _col.Count > 0;
        }

    private void OnTriggerEnter(Collider other)
        {
        if (!other.isTrigger && other.gameObject != transform.parent.gameObject)
            _col.Add(other);
        }

    private void OnTriggerExit(Collider other)
        {
        if (_col.Contains(other))
            _col.Remove(other);
        }
    }
