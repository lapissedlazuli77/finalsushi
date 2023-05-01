using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public int currentcost = 0;
    public Camera cam;
    public StateMachine stateMachine;
    [SerializeField]
    string SelectedUnit;
    string SelectedLane;
    string iconSelected;

    public GameObject HamachiUnit;
    public GameObject IkuraUnit;
    public GameObject SabaUnit;

    public bool isPicking = false;

    [SerializeField]
    TextMeshProUGUI costdisplay;

    private float timer = 0;
    private float timertrigger = 0.39f;

    void AssembleStateMachine()
    {
        stateMachine = new StateMachine(PickUnit, PickLane);
        stateMachine.ChangeState("PickUnit");
    }

    // Start is called before the first frame update
    private void Awake()
    {
        AssembleStateMachine();
    }

    // Update is called once per frame
    private void Update()
    {
        this.stateMachine.Execute();

        costdisplay.text = currentcost.ToString();
        if (timer >= timertrigger)
        {
            timer = 0;
            currentcost++;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    #region states
    void PickUnit()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseSelect(cam);
        }
    }

    void PickLane()
    {
        isPicking = true;
        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            ClearSelection();
            stateMachine.ChangeState("PickUnit");
        }
        if (Input.GetMouseButtonDown(0))
        {
            MousePick(cam);
        }
    }

    #endregion
    //this one is for picking a unit
    void MouseSelect(Camera camera)
    {
        RaycastHit2D hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        hit = Physics2D.Raycast(ray.origin, ray.direction);
        //if we do click something
        if (hit.transform != null)
        {
            Transform objectHit = hit.transform;
            if (objectHit.tag == "UnitSelect")
            {
                string iconname = hit.transform.name;
                int boundary = iconname.IndexOf("_");
                SelectedUnit = iconname.Substring(0, boundary);
                stateMachine.ChangeState("PickLane");
                Debug.Log(SelectedUnit);
            }
        }
    }
    //this one is for picking a lane
    void MousePick(Camera camera)
    {
        RaycastHit2D hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        hit = Physics2D.Raycast(ray.origin, ray.direction);
        //if we do click something
        if (hit.transform != null)
        {
            Transform objectHit = hit.transform;
            if (objectHit.tag == "Lane")
            {
                string lanename = hit.transform.name;
                char charlane = lanename[lanename.Length - 1];
                SelectedLane = charlane.ToString();
                Debug.Log(SelectedLane);
                PlayUnit(SelectedLane);
            }
        }
    }

    void PlayUnit(string lane)
    {
        int unitcost = 0;
        float laneToPlay = float.Parse(lane);

        float truepos = (2 - laneToPlay * 0.8f);
        if (SelectedUnit == "Hamachi") unitcost = 10;
        else if (SelectedUnit == "Ikura") unitcost = 20;
        else if (SelectedUnit == "Saba") unitcost = 40;
        else if (SelectedUnit == "Fugu") unitcost = 60;
        if (currentcost >= unitcost)
        {
            Debug.Log("Sending " + SelectedUnit);
            if (SelectedUnit == "Hamachi")
            {
                GameObject newHamachi = Instantiate(HamachiUnit);
                newHamachi.transform.position = new Vector3(-5, truepos, 0);
            }
            else if (SelectedUnit == "Ikura")
            {
                GameObject newIkura = Instantiate(IkuraUnit);
                newIkura.transform.position = new Vector3(-5, truepos, 0);
            }
            else if (SelectedUnit == "Saba")
            {
                GameObject newSaba = Instantiate(SabaUnit);
                newSaba.transform.position = new Vector3(-5, truepos, 0);
            }
            currentcost -= unitcost;
            ClearSelection();
            stateMachine.ChangeState("PickUnit");
        }
        else
        {
            Debug.Log("You don't have enough for that.");
            ClearSelection();
            stateMachine.ChangeState("PickUnit");
        }
    }

    void ClearSelection()
    {
        SelectedUnit = "";
        SelectedLane = "";
        isPicking = false;
    }
}
