using UnityEngine;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    [SerializeField] private int rayLenght = 5;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string excludeLayerName = null;
    private DoorController raycastedObj1;
    private PhoneController raycastedObj2;
    [SerializeField] private KeyCode interact = KeyCode.Mouse0;
    [SerializeField] private Image crosshair = null;
    private bool isCrosshairActive;
    private bool doOnce;
    private const string interactableTag = "InteractiveObject";
    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value;
        if(Physics.Raycast(transform.position, fwd, out hit ,rayLenght, mask))
        {
            if (hit.collider.CompareTag(interactableTag))
            {
                HandleInteraction(hit.collider);
            }
        }
        else
        {
            if(isCrosshairActive)
            {
                CrosshairChange(false);
                doOnce = false;
            }
        }

    }
    void HandleInteraction(Collider collider)
    {
        if (!doOnce)
        {
            if (collider.gameObject.layer == LayerMask.NameToLayer("Door"))
            {
                raycastedObj1 = collider.gameObject.GetComponent<DoorController>();
            }
            else if (collider.gameObject.layer == LayerMask.NameToLayer("Phone"))
            {
                raycastedObj2 = collider.gameObject.GetComponent<PhoneController>();
            }
            else if (collider.gameObject.layer == LayerMask.NameToLayer("Flashlight"))
            {
                //raycastedObj3 = collider.gameObject.GetComponent<FlashlightController>();
            }
            // Add additional else-if conditions for other layers and their corresponding components

            if (raycastedObj1 != null)
            {
                CrosshairChange(true);
            }
        }
        isCrosshairActive = true;
        doOnce = true;

        if (Input.GetKeyDown(interact))
        {
            if (raycastedObj1 != null)
            {
                raycastedObj1.PlayAnimation();
            }
        }
    }

    void CrosshairChange(bool active)
    {
        if (active && !doOnce)
        {
            crosshair.color = Color.red;
        }
        else
        {
            crosshair.color = Color.white;
            isCrosshairActive = false;
        }
    }
    

}
