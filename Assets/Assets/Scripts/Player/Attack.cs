using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool _canAttack=true;
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Hit:" + col.name);

        IDamageable hit = col.GetComponent<IDamageable>();
        if (hit != null)
        {
            hit.Damage();
            _canAttack = false;
        }
    }
}
