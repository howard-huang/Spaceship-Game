using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{

    public GameObject EnemyPrefab;
    public float Width;
    public float Height;
    public float speed;

    private bool rigthMovement = true;
    private float xMax;
    private float xMin;

    
    void Start()
    {
        // distance between object and the camera(z axis) 
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftEnd = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
        Vector3 rightEnd = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
        xMax = rightEnd.x;
        xMin = leftEnd.x;

        CreationOfAllEnemies();
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position,new Vector3(Width,Height));
    }
    
    void Update()
    {
        if (rigthMovement)
        {
            // transform.position += speed * Vector3.right* Time.deltaTime;
            transform.position += new Vector3(speed*Time.deltaTime,0,0);
        }
        else
        {
            // ransform.position += speed * Vector3.left* Time.deltaTime;
            transform.position -= new Vector3(speed*Time.deltaTime,0,0);
        }

        float rightLimit = transform.position.x + 0.5f * Width;
        float leftLimit = transform.position.x - 0.5f * Width;

        if(rightLimit > xMax )
        {
            rigthMovement = false;
        }
        else if(leftLimit < xMin)
        {
            rigthMovement = true;
        }

        

        if(AllEnemiesDead())
        {
            CreationOfEnemy();
        }

    }

    private bool AllEnemiesDead()
    {
        foreach (Transform EnemyPositionController in transform)
        {
            if (EnemyPositionController.childCount > 0)
            {
                return false;
            }
        }
        return true;
    }

    void CreationOfAllEnemies()
    {
        foreach (Transform child in transform)
        {
            GameObject Enemy = Instantiate(EnemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
            Enemy.transform.parent = child;
        }
    }

    Transform NextAvaliablePosition()
    {
        foreach (Transform EnemyPositionController in transform)
        {
            if (EnemyPositionController.childCount == 0)
            {
                return EnemyPositionController;
            }
        }
        return null;
        
    }

    void CreationOfEnemy()
    {
        Transform AvaliablePosition = NextAvaliablePosition();

        if (AvaliablePosition)
        {
            GameObject Enemy = Instantiate(EnemyPrefab, AvaliablePosition.transform.position, Quaternion.identity) as GameObject;
            Enemy.transform.parent = AvaliablePosition;
        }

        if (NextAvaliablePosition())
        {
            Invoke("CreationOfEnemy",2f);
        }
    }

}
