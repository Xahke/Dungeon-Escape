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
    }

    public void Damage()
    {
       
    }
}
