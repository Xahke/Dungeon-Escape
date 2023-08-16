using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MossGiant : Enemy,IDamageable
{
    public int Health { get; set; }
    public bool CanAttack { get; set; }

    public override void Init()
    {
        base.Init();
        Health = health;
        CanAttack = true;
    }
    public void Damage()
    {
        if (isDead == true)
            return;
        if (CanAttack)
        {
            health--;
            isHit = true;
            anim.SetTrigger("Hit");
            CanAttack=false;
            anim.SetBool("InCombat", true);
            StartCoroutine(HitCooldown());
        }
        if (health<1)
        {
            Death();
        }
        

    }
    IEnumerator HitCooldown()
    {
        yield return new WaitForSeconds(0.5f);
        CanAttack = true;
    }
}
