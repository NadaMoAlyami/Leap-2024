using UnityEngine;
using UnityEngine.UI;

public class MonitorsWindow : MonoBehaviour
{
    public Canvas mainCanvas;
    public string childPanelNameToFind = "Panel"; // Update the panel name here

    public RectTransform fixedRectTransform;

    void OnTriggerEnter(Collider other)
    {
        // Check if the triggering object has a Canvas component
        Canvas otherCanvas = other.GetComponentInChildren<Canvas>();

        if (otherCanvas != null && mainCanvas != null)
        {
            // Find the child panel GameObject by name
            Transform childPanelTransform = otherCanvas.transform.Find(childPanelNameToFind);

            if (childPanelTransform != null)
            {
                // Set the child panel as a child of the main canvas
                childPanelTransform.SetParent(mainCanvas.transform);

                // Optionally, you can adjust the position of the moved panel as needed
                childPanelTransform.localPosition = Vector3.zero;

                // Set the RectTransform of the child panel to the fixed RectTransform from the Inspector
                RectTransform childRectTransform = childPanelTransform.GetComponent<RectTransform>();
                if (childRectTransform != null && fixedRectTransform != null)
                {
                    // Set the RectTransform of the child panel to match the fixed RectTransform
                    childRectTransform.sizeDelta = fixedRectTransform.sizeDelta;
                    childRectTransform.anchoredPosition = fixedRectTransform.anchoredPosition;
                    childRectTransform.localRotation = fixedRectTransform.localRotation;

                    // Adjust the scale of the child panel
                    childPanelTransform.localScale = fixedRectTransform.localScale;
                }

                // Destroy the triggering object's GameObject
                Destroy(other.gameObject);

                // Find the "DetachButton" in the child panel and enable it
                Button detachButton = childPanelTransform.Find("DetachButton")?.GetComponent<Button>();
                if (detachButton != null)
                {
                    detachButton.interactable = true;
                }
                else
                {
                    Debug.Log("DetachButton not found in the child panel.");
                }
            }
            else
            {
                Debug.Log("Child panel with name '" + childPanelNameToFind + "' not found in the triggering canvas.");
            }
        }
    }
}
