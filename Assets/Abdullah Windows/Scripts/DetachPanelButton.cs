using UnityEngine;
using UnityEngine.UI;

public class DetachPanel : MonoBehaviour
{
    public Button detachButton; // Reference to your UI Button
    public GameObject flyingWindowPrefab; // Reference to your prefab with a Canvas as a GameObject
    public Transform spawnPosition; // Reference to the specific transform for position

    void Start()
    {
        // Check if the parent of the current GameObject has a Canvas component
        Canvas parentCanvas = transform.parent?.GetComponent<Canvas>();

        // Check if the parent canvas is not null and has the tag "FixedWindow"
        if (parentCanvas != null && parentCanvas.CompareTag("FixedWindow"))
        {
            // Enable the button
            detachButton.interactable = true;
        }
        else
        {
            // Disable the button
            detachButton.interactable = false;
        }
    }

    // This method is directly called by the On Click event in the Unity Editor
    public void DetachPanelOnClick()
    {
        // Get the parent of the current GameObject
        Transform parentTransform = transform.parent;

        // Check if the parent is not null and is tagged as "FixedWindow"
        if (parentTransform != null && parentTransform.CompareTag("FixedWindow"))
        {
            // Detach the panel from its current parent
            transform.SetParent(null);

            // Instantiate the prefab with a canvas at the specified position
            GameObject instantiatedPrefab = Instantiate(flyingWindowPrefab, spawnPosition.position, Quaternion.identity);

            // Get the child canvas of the instantiated prefab
            Transform childCanvas = instantiatedPrefab.transform.Find("Canvas");

            if (childCanvas != null)
            {
                // Find the sample panel of the child canvas
                Transform samplePanelTransform = childCanvas.Find("SamplePanel");

                // Set the panel as a child of the child canvas
                transform.SetParent(childCanvas);

                // Optionally, you can adjust the position of the moved panel as needed
                transform.localPosition = Vector3.zero;

                if (samplePanelTransform != null)
                {
                    // Set the size of the panel to match the size of the sample panel
                    RectTransform panelRectTransform = GetComponent<RectTransform>();
                    RectTransform samplePanelRectTransform = samplePanelTransform.GetComponent<RectTransform>();

                    if (panelRectTransform != null && samplePanelRectTransform != null)
                    {
                        panelRectTransform.sizeDelta = samplePanelRectTransform.sizeDelta;

                        // Set the anchored position of the panel to match the sample panel
                        panelRectTransform.anchoredPosition = samplePanelRectTransform.anchoredPosition;

                        // Set the anchor presets of the panel to match the sample panel
                        panelRectTransform.anchorMin = samplePanelRectTransform.anchorMin;
                        panelRectTransform.anchorMax = samplePanelRectTransform.anchorMax;
                        panelRectTransform.pivot = samplePanelRectTransform.pivot;

                        // Set the local rotation of the panel to match the sample panel
                        panelRectTransform.localRotation = samplePanelRectTransform.localRotation;

                        // Adjust the scale of the panel
                        transform.localScale = samplePanelTransform.localScale;
                    }

                    // Disable the button
                    detachButton.interactable = false;
                }
                else
                {
                    Debug.Log("Sample panel not found in the child canvas.");
                }
            }
            else
            {
                Debug.Log("Child Canvas not found in the instantiated prefab.");
            }
        }
        else
        {
            Debug.Log("The parent is not tagged as 'FixedWindow' or doesn't exist.");
        }
    }
}
