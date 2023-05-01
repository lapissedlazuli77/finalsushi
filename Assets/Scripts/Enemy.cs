using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject KeganiUnit;
    public GameObject KurageUnit;

    private float timer = 0;
    private float timertrigger = 2.0f;

    int summoncount = 1;

    // Update is called once per frame
    void Update()
    {
        if (timer >= timertrigger)
        {
            timer = 0;
            ConsiderSummoning();
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    void ConsiderSummoning()
    {
        int threshold = 4 - summoncount;
        int choosesummon = Random.Range(1, threshold);
        if (choosesummon <= 1)
        {
            SummonUnit();
            summoncount = 1;
        }
    }
    void SummonUnit()
    {
        int whichlane = Random.Range(1, 4);
        float laneToPlay = (float)whichlane;

        float truepos = (2 - laneToPlay * 0.8f);
        int whichunit = Random.Range(1, 5);
        if (whichunit <= 3)
        {
            GameObject newKegani = Instantiate(KeganiUnit);
            newKegani.transform.position = new Vector3(5, truepos, 0);
        }
        if (whichunit >= 4)
        {
            GameObject newKurage = Instantiate(KurageUnit);
            newKurage.transform.position = new Vector3(5, truepos, 0);
        }
    }
}
