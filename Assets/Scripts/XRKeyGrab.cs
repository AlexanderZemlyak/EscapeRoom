using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(XRGrabInteractable))]
public class XRKeyGrab : MonoBehaviour
{
    [SerializeField] private float Mass = 0.3f;

    void Awake()
    {
        var rb = GetComponent<Rigidbody>();
        rb.mass = Mass;
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
    }
}
