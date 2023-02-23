using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Iinteractable iinteractable = other.gameObject.GetComponent<Iinteractable>();
        if (iinteractable == null)
        {
            return;
        }
        if (iinteractable.isInteractable)iinteractable.Interact(this.gameObject);
    }
}
