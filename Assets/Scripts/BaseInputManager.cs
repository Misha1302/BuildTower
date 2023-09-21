using System;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro.EditorUtilities;
using UnityEngine;

public abstract class BaseInputManager : MonoBehaviour
{
    protected Action actions;

    public void SubscribeToClick(Action onClicked)
    {
        actions += onClicked;
    }

    public void UnSubscribeToClick(Action onClicked)
    {
        actions -= onClicked;
    }
}