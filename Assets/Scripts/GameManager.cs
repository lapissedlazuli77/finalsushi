using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Player player;
    public GameObject lane1;
    public GameObject lane2;
    public GameObject lane3;
    public GameObject lane4;

    public GameObject balanceicon;
    public float balance = 0;

    // Start is called before the first frame update
    void Start()
    {
        balance = 0;
    }

    // Update is called once per frame
    void Update()
    {
        balanceicon.transform.position = new Vector3(balance * 0.04f, 1.8f, 1);

        if (balance <= -100)
        {
            SceneManager.LoadScene("Lose");
        }
        if (balance >= 100)
        {
            SceneManager.LoadScene("Win");
        }

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
