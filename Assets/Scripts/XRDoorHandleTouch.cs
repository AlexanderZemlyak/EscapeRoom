using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(XRSimpleInteractable))]
public class XRDoorHandleTouch : MonoBehaviour
{
    public AN_DoorScript Door;

    XRSimpleInteractable interactable;

    void Awake()
    {
        interactable = GetComponent<XRSimpleInteractable>();

        if (Door == null)
        {
            Door = GetComponentInParent<AN_DoorScript>();
        }
    }

    void OnEnable()
    {
        interactable.selectEntered.AddListener(OnSelect);
    }

    void OnDisable()
    {
        interactable.selectEntered.RemoveListener(OnSelect);
    }

    void OnSelect(SelectEnterEventArgs args)
    {
        if (Door != null) Door.Action();
    }
}
