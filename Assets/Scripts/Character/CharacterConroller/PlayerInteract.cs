using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerInteract : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerInputReader inputReader;
    
    [Header("Parameters")]
    public float pickupRadius = 2.0f;
    public LayerMask interactableLayer;
    private bool hasObject;
    private GameObject pickups;
    [SerializeField] private Transform pickupSocket;

    private void Update()
    {
        if (inputReader.InteractPressed == true)
        {
            if (hasObject == false)
            {
                pickups = Pickup();
                hasObject = true;  
            }
            else if(hasObject == true)
            {
                DropOff(pickups);
            }
            inputReader.ResetOneFrameInputs();
        }
        //pickup logic here
    }

    private GameObject Pickup()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, pickupRadius, interactableLayer);

        if (hitColliders.Length > 0)
        {
            Transform closestObject = null;
            float minDistance = pickupRadius;

            // 2. Find the closest object
            foreach (Collider col in hitColliders)
            {
                float distance = Vector3.Distance(transform.position, col.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestObject = col.transform;
                }
            }

            // 3. Execute pickup logic
            if (closestObject != null)
            {
                closestObject.transform.SetPositionAndRotation(pickupSocket.position, pickupSocket.rotation);
                closestObject.transform.SetParent(pickupSocket);
                Debug.Log("Picked up: " + closestObject.name);
                return closestObject.gameObject;
            }
        }
        return null;
    }

    void DropOff(GameObject objectToDrop)
    {
        objectToDrop.transform.SetParent(null);
        hasObject = false;
        pickups = null;
    }
}
