using UnityEngine;

public class SortingLayerSetter : MonoBehaviour
{
    [SerializeField] private string sortingLayerName = "Default"; // Set your desired sorting layer name
    [SerializeField] private int orderInLayer = 1; // Set your desired order in layer value

    private void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.sortingLayerName = sortingLayerName;
            renderer.sortingOrder = orderInLayer;
        }
    }
}
