using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPositionController : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 1);
    }



}
