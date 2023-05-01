using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saba : MonoBehaviour
{
    public float damage;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = transform.position;
        currentPosition.x += speed;
        transform.position = currentPosition;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyUnit")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
