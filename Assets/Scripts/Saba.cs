using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saba : MonoBehaviour
{
    public float damage = 80f;
    Rigidbody2D myBody;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        myBody.AddForce(transform.right * 600f);
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
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyUnit")
        {
            if ((collision.gameObject.GetComponent("Kegani") as Kegani) != null)
            {
                Destroy(gameObject);
                collision.gameObject.GetComponent<Kegani>().Damaged(damage);
            }
            else if ((collision.gameObject.GetComponent("Kurage") as Kurage) != null)
            {
                Destroy(gameObject);
                collision.gameObject.GetComponent<Kurage>().Damaged(damage);
            }
        }
    }
}
