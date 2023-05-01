using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KurageBolt : MonoBehaviour
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
    void OnEnable() {
        GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("EnemyUnit");

        foreach (GameObject obj in enemyObjects)
        {
            Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
    void Update()
    {
        if (transform.position.x <= -4f)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);
        if (other.tag == "PlayerUnit")
        {
            Debug.Log("Hit");
            Destroy(gameObject);
        }
    }
}
