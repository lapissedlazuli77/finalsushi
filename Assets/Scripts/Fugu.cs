using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fugu : MonoBehaviour
{
    public int health = 4;
    public float damage = 30f;
    Rigidbody2D myBody;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        myBody.AddForce(transform.right * 100f);
    }
    void OnEnable()
    {
        GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("PlayerUnit");

        foreach (GameObject obj in playerObjects)
        {
            Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        GameObject[] projectiles = GameObject.FindGameObjectsWithTag("Projectile");

        foreach (GameObject proj in projectiles)
        {
            Physics2D.IgnoreCollision(proj.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= 4f)
        {
            Destroy(gameObject);
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "EnemyUnit")
        {
            if ((other.GetComponent("Kegani") as Kegani) != null)
            {
                health--;
                other.GetComponent<Kegani>().Damaged(damage);
            }
            else if ((other.GetComponent("Kurage") as Kurage) != null)
            {
                health--;
                other.GetComponent<Kurage>().Damaged(damage);
            }
        }
    }
}
