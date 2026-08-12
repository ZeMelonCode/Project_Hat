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
    [SerializeField]private bool hasObject;
    private GameObject pickups;
    
    [SerializeField] private BaseHero heroClass;
    [SerializeField] private Transform pickupSocket;

    private void Update()
    {
        if (!inputReader.InteractPressed) return;

        Debug.Log("trying to pickup");

        if (!hasObject)
        {
            Debug.Log("Picking up");
            pickups = Pickup();

            if (pickups != null)          // only set true if we actually got something
            {
                hasObject = true;
                Debug.Log("Successfully picked up: " + pickups.name);
            }
            else
            {
                Debug.Log("Pickup failed - nothing found");
            }
        }
        else
        {
            DropOff(pickups);
        }

        inputReader.ResetOneFrameInputs();
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
                Rigidbody rb = closestObject.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = true;
                }
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
        Rigidbody rb = objectToDrop.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false;
        }
        objectToDrop.transform.SetParent(null);
        hasObject = false;
        pickups = null;
    }
}
