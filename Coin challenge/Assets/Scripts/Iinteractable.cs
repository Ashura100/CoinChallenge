using UnityEngine;

public interface Iinteractable
{
    bool isInteractable { get; }
    void Interact(GameObject gameInteraction);

}
