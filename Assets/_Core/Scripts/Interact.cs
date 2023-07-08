using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Interact
{
    public bool IsInteractable();
    
    public void Interaction(GameObject _object);
}
