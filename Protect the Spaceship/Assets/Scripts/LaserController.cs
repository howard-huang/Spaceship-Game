using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{

    public static float damage = 10f;


    public void Start()
    {
        
    }

    public void Update()
    {
        
    }


    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    

    public static float Damage()
    {
        return damage;
    }
}
