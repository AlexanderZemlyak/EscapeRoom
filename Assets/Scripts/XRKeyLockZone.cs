using UnityEngine;

[RequireComponent(typeof(Collider))]
public class XRKeyLockZone : MonoBehaviour
{
    [SerializeField] private AN_DoorScript Door;

    bool used;

    void Awake()
    {
        GetComponent<Collider>().isTrigger = true;

        if (Door == null)
        {
            Door = GetComponentInParent<AN_DoorScript>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (Door == null || used) return;

        var key = other.GetComponentInParent<AN_DoorKey>();
        if (key == null) return;

        bool matches = (key.isRedKey && Door.RedLocked) || (!key.isRedKey && Door.BlueLocked);
        if (!matches) return;

        used = true;
        
        if (key.isRedKey) Door.RedLocked = false;
        else Door.BlueLocked = false;

        Destroy(key.gameObject);
        
        if (!Door.isOpened) Door.Action();
    }
}
