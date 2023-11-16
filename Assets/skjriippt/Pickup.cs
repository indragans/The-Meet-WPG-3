using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private LayerMask PickupLayer;
    [SerializeField] private float ThrowingForce;
    [SerializeField] private Camera PlayerCamera;
    [SerializeField] private float Pickuprange;
    [SerializeField] private Transform Hand;

    private Rigidbody CurrentObjectRigidbody;
    private Collider CurrentObjectCollider;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Ray Pickupray = new Ray(PlayerCamera.transform.position, PlayerCamera.transform.forward);
            if(Physics.Raycast(Pickupray, out RaycastHit hitinfo, Pickuprange, PickupLayer))
            {
                if(CurrentObjectRigidbody)
                {
                    CurrentObjectRigidbody.isKinematic = false;
                    CurrentObjectCollider.enabled = true;

                    CurrentObjectRigidbody = hitinfo.rigidbody;
                    CurrentObjectCollider = hitinfo.collider;

                    CurrentObjectRigidbody.isKinematic = true;
                    CurrentObjectCollider.enabled = false;
                }   
                else
                {
                    CurrentObjectRigidbody = hitinfo.rigidbody;
                    CurrentObjectCollider = hitinfo.collider;

                    CurrentObjectRigidbody.isKinematic = true;
                    CurrentObjectCollider.enabled = false;
                }

                return;
            }

            if(CurrentObjectRigidbody)
                {
                    CurrentObjectRigidbody.isKinematic = false;
                    CurrentObjectCollider.enabled = true;

                    CurrentObjectRigidbody = null;
                    CurrentObjectCollider = null;

                    
                } 
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(CurrentObjectRigidbody)
                {
                    CurrentObjectRigidbody.isKinematic = false;
                    CurrentObjectCollider.enabled = true;

                    CurrentObjectRigidbody.AddForce(PlayerCamera.transform.forward * ThrowingForce, ForceMode.Impulse);
                    CurrentObjectRigidbody = null;
                    CurrentObjectCollider = null;

                    
                }
        }
        if(CurrentObjectRigidbody)
        {
            CurrentObjectRigidbody.position = Hand.position;
            CurrentObjectRigidbody.rotation = Hand.rotation;

        }
        
    }
}
