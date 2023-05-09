using UnityEngine;

public interface Iinteractable
{
    bool isInteractable { get; set; }
    void Interact(GameObject gameInteraction);

}
