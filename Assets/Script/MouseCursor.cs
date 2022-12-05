using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{

    [SerializeField] private GameObject deodorant;
    [SerializeField] private GameObject sTFlewOut;
    [SerializeField] private GameObject waterBeam;

    private Vector3 mousePosition;
    private Vector3 worldPosition;
    private Rigidbody bodySpray;
    private Camera cam;
    private bool isClicked;

    private void Awake() 
    {
        cam = Camera.main;
    }

    private void Start() 
    {
        isClicked = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            isClicked = true;
        }
        else
        {
            isClicked = false;
        }
    }

    private void FixedUpdate() 
    {
        if(isClicked == true)
        {
            posSpray();
            stFlewOut();
        }
    }

    private void posSpray()
    {
        mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.nearClipPlane + 2.2f;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        waterBeam.transform.position = new Vector3(worldPosition.x, worldPosition.y, worldPosition.z - 0.9f);
        deodorant.transform.position = new Vector3(worldPosition.x, worldPosition.y - 0.9f, worldPosition.z - 0.95f);
        sTFlewOut.transform.position = worldPosition;
    }

    private void stFlewOut()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            if(hit.collider != null)
            {
                sTFlewOut.SetActive(true);
            }
        }
        else
        {
            sTFlewOut.SetActive(false);
        }
    }
}
