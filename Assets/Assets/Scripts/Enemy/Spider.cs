using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spider : Enemy,IDamageable
{
    public int Health { get; set; }
    public bool CanAttack { get; set; }

    public override void Init()
    {
        base.Init();
        Health = health;
    }
    public override void Update()
    {
        
    }

    public void Damage()
    {
        if (isDead == true)
            return;
        health--;
        if (health<1)
        {
            Death();
        }
    }
    public override void Movement()
    {
        
    }
}
