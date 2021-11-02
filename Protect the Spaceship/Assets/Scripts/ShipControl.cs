using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControl : MonoBehaviour
{

    private Rigidbody2D ShipBody;
    private float mySpeedX;
    private float mySpeedY;
    [SerializeField] float speed;
    public float health=250f;

    public GameObject Laser;
    public float LaserSpeed;
    private float AttackInterval=0.5f;

    public AudioClip LaserSound;
    public AudioClip DeathSound;

    private HealthControl HealthControl;
    
    


    // Start is called before the first frame update
    void Start()
    {
        ShipBody = GetComponent<Rigidbody2D>();
        HealthControl = GameObject.Find("Health").GetComponent<HealthControl>();

    }

    // Update is called once per frame
    void Update()
    {
        HealthControl.Health = (int)health;

        #region Movement

        mySpeedX = Input.GetAxis("Horizontal");

        

        ShipBody.velocity = new Vector2(mySpeedX * speed, mySpeedY * speed);



        #endregion

        #region LaserFire

        if (Input.GetKeyDown(KeyCode.Space))
        {

                InvokeRepeating(nameof(Fire), 0.001f, AttackInterval); //it repeats the function per 0.3 second after its called for once.
            
            
            
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("Fire");
        }
        #endregion


    }

    public void Fire()
    {
        GameObject shipLaser = Instantiate(Laser, transform.position, Quaternion.identity) as GameObject;

        shipLaser.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, LaserSpeed, 0f);

        AudioSource.PlayClipAtPoint(LaserSound, transform.position);

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyLaser")
        {
            Destroy(collision.gameObject);
            health -= LaserController.Damage();
            if (health <= 0)
            {
                HealthControl.Health = 0;
                Destroy(gameObject);
                AudioSource.PlayClipAtPoint(DeathSound, transform.position);
                Time.timeScale = 0;
            }
        }
    }
}