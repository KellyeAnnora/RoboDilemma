using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickups : MonoBehaviour
{
    public int partCount = 0;

    Statkeeper keeper;

    private void Start()
    {
        keeper = GetComponent<Statkeeper>();
        partCount = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            Destroy(other.gameObject);
            partCount += 1;
            keeper.parts = partCount;
        }
    }
}
