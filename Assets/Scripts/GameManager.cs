using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public GameObject lane1;
    public GameObject lane2;
    public GameObject lane3;
    public GameObject lane4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isPicking == false)
        {
            lane1.SetActive(false);
            lane2.SetActive(false);
            lane3.SetActive(false);
            lane4.SetActive(false);
        } else if (player.isPicking == true)
        {
            lane1.SetActive(true);
            lane2.SetActive(true);
            lane3.SetActive(true);
            lane4.SetActive(true);
        }
    }
}
