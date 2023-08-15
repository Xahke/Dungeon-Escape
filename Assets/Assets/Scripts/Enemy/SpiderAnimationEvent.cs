using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpiderAnimationEvent : MonoBehaviour
{
    [SerializeField]
     private GameObject Acid;
    public void Fire()
    {
        Instantiate(Acid, new Vector3(-49.22f, 1.607f, 0), quaternion.identity);
    }
}
