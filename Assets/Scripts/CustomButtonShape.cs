using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public sealed class CustomButtonShape : MonoBehaviour
{
    [SerializeField] private float alpha = 0.1f;

    private void Awake()
    {
        GetComponent<Image>().alphaHitTestMinimumThreshold = alpha;
    }
}