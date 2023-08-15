using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy,IDamageable
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
        if (CanAttack)
        {
            health--;
            anim.SetTrigger("Hit");
            isHit = true;
            CanAttack = false;
            anim.SetBool("InCombat", true);
            StartCoroutine(HitCooldown());
        }
        

        if (health<=0)
        {
            isDead = true;
            anim.SetTrigger("Death");
        }
    }
    IEnumerator HitCooldown()
    {
        yield return new WaitForSeconds(0.5f);
        CanAttack=true;
    }
}
