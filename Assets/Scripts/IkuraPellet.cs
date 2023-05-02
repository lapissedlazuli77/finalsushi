using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IkuraPellet : MonoBehaviour
{
    public float damage = 50f;
    public float speed = 0.03f;
    Rigidbody2D myBody;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        myBody.AddForce(transform.right * -4f);
    }
    void OnEnable()
    {
        GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("PlayerUnit");

        foreach (GameObject obj in playerObjects)
        {
            Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
    void Update()
    {
        if (transform.position.x >= 4f)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "EnemyUnit")
        {
            if ((collision.gameObject.GetComponent("Kegani") as Kegani) != null)
            {
                collision.gameObject.GetComponent<Kegani>().Damaged(damage);
            }
            else if ((collision.gameObject.GetComponent("Kurage") as Kurage) != null)
            {
                collision.gameObject.GetComponent<Kurage>().Damaged(damage);
            }
        }
        Destroy(gameObject);
    }
}
