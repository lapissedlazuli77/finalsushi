using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KurageBolt : MonoBehaviour
{
    public float speed = 0.03f;
    Rigidbody2D myBody;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        myBody.AddForce(transform.right * -4f);
    }
}
