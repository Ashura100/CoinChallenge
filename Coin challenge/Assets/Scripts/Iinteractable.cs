using UnityEngine;

public interface Iinteractable
{
    //interface pour d�finir les interaction
    bool isInteractable { get; set; }
    void Interact(GameObject gameInteraction);

}
