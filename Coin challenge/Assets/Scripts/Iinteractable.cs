using UnityEngine;

public interface Iinteractable
{
    //interface pour définir les interaction
    bool isInteractable { get; set; }
    void Interact(GameObject gameInteraction);

}
