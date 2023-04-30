using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int currentcost = 0;
    public Camera cam;
    public StateMachine stateMachine;
    [SerializeField]
    string SelectedUnit;
    string SelectedLane;
    string iconSelected;

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
        if (Input.GetKeyDown(KeyCode.Backspace))
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
                stateMachine.ChangeState("PickUnit");
            }
        }
    }

    void ClearSelection()
    {
        SelectedUnit = "";
    }
}
