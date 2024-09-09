using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    [SerializeField] GameObject triggerObject;
    bool openDoor = false;
    Vector3 openPosition;
    Vector3 closedPosition;

    // Start is called before the first frame update
    void Start()
    {
        openPosition = new Vector3(triggerObject.transform.position.x, 10f, triggerObject.transform.position.z);
        closedPosition = triggerObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (openDoor)
        {
            triggerObject.transform.position = Vector3.Lerp(triggerObject.transform.position, openPosition, 0.10f);
        }
        else
        {
            triggerObject.transform.position = Vector3.Lerp(triggerObject.transform.position, closedPosition, 0.10f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        openDoor = true;
    }
    private void OnTriggerExit(Collider other)
    {
        openDoor = false;
    }
}
