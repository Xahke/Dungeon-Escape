using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance==null)
            {
                Debug.Log("GameManager is NULL");
            }
            return _instance;
        }
    }
    public bool HasKey { get; set; }
    private void Awake()
    {
        _instance = this;
    }
}
