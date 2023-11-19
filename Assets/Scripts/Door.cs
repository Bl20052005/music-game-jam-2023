using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public string requiredItem;
    public Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        // Any initialization logic can be added here if needed
    }

    // Update is called once per frame
    void Update()
    {
        // Any per-frame logic can be added here if needed
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CheckAndOpenDoor();
    }

    private void CheckAndOpenDoor()
    {
        if (inventory != null && inventory.Contains(requiredItem))
        {
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        Destroy(gameObject);
        // Optionally, you can add any additional actions when the door is opened
    }
}
