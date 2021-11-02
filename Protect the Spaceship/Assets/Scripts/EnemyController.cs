using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float health = 50f;

    public GameObject Laser;
    private float LaserSpeed = -7f;

    public int KillScore = 100;
    public int DamageScore = 10;
    //public float LaserPerSecond = 0.35f;
    private ScoreControl scoreControl;

    public AudioClip LaserSound;
    public AudioClip DeathSound;


    // Start is called before the first frame update
    void Start()
    {
        scoreControl = GameObject.Find("Score").GetComponent<ScoreControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.value > 0.9950)
        {
            Fire();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Laser")
        {
            Destroy(collision.gameObject);
            health -= LaserController.Damage();
            scoreControl.IncreaseScore(DamageScore);
            if (health <= 0)
            {
                Destroy(gameObject);
                scoreControl.IncreaseScore(KillScore);
                AudioSource.PlayClipAtPoint(DeathSound, transform.position);
            }
        }
    }

    private void Fire()
    {
        Vector3 StartingPosition = transform.position;
        GameObject EnemyLaser = Instantiate(Laser, StartingPosition, Quaternion.identity) as GameObject;
        EnemyLaser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, LaserSpeed);
        AudioSource.PlayClipAtPoint(LaserSound, transform.position);
    }
}
