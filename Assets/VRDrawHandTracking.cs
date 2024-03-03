using UnityEngine;
using UnityEngine.XR;
using System.Collections.Generic;

public class SimpleXRDrawHandTracking : MonoBehaviour
{
    public GameObject linePrefab; // Assign a prefab with a LineRenderer component
    private LineRenderer currentLineRenderer;
    public float lineWidth = 0.01f; // Set the desired line width
    public Material lineMaterial; // Assign the material for the line
    private bool isDrawing = false;
    private List<GameObject> lines = new List<GameObject>(); // Stores all drawn lines
    private InputDevice rightHandDevice;

    void Start()
    {
        // Attempt to get the right hand device at start
        rightHandDevice = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        StartDrawing();
    }

    void Update()
    {
        // Check if the right hand device is valid, if not, try to get it again
        if (!rightHandDevice.isValid)
        {
            rightHandDevice = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        }

        // Update drawing if isDrawing is true
        if (isDrawing)
        {
            UpdateDrawing();
        }
    }

    void StartDrawing()
    {
        isDrawing = true; // Start drawing immediately or based on your condition
        // Initialize a new line for drawing
        GameObject lineObj = new GameObject("DynamicLine");
        lineObj.AddComponent<LineRenderer>();
        currentLineRenderer = lineObj.GetComponent<LineRenderer>();
        currentLineRenderer.startWidth = lineWidth;
        currentLineRenderer.endWidth = lineWidth;
        currentLineRenderer.material = lineMaterial;
        currentLineRenderer.positionCount = 0;
        lines.Add(lineObj);
    }

    void UpdateDrawing()
    {
        // Only add new points if the hand is moving
        if (currentLineRenderer != null && isDrawing)
        {
            Vector3 currentPosition = GetDevicePosition(rightHandDevice);
            if (currentLineRenderer.positionCount == 0 || currentPosition != currentLineRenderer.GetPosition(currentLineRenderer.positionCount - 1))
            {
                currentLineRenderer.positionCount++;
                currentLineRenderer.SetPosition(currentLineRenderer.positionCount - 1, currentPosition);
            }
        }
    }

    Vector3 GetDevicePosition(InputDevice device)
    {
        device.TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 position);
        return position;
    }

    // Example method to toggle drawing on and off
    public void ToggleDrawing()
    {
        isDrawing = !isDrawing;
        if (isDrawing)
        {
            StartDrawing();
        }
    }
}
