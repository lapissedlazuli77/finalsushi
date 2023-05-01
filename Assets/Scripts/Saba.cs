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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "EnemyUnit")
        {
            Destroy(other);
            Destroy(gameObject);
        }
    }
}
