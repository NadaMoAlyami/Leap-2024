using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
 
    public Color defaultColor;
    public Color selectedColor;

    private Button previousButton;

    void Start()
    {
        // Set default color for all buttons at start
        Button[] buttons = GetComponentsInChildren<Button>();
        foreach (Button button in buttons)
        {
            ResetButtonColor(button);
        }
    }

    // Method to change the color of the button
    public void ChangeButtonColor(Button button)
    {
        if (button != null)
        {
            // Reset color of the previous button
            if (previousButton != null && previousButton != button)
            {
                ResetButtonColor(previousButton);
            }

            // Change color of the current button
            SetButtonColor(button, selectedColor);

            // Update the previousButton
            previousButton = button;
        }
        else
        {
            Debug.LogWarning("Button is null.");
        }
    }

    // Method to reset the color of a button
    private void ResetButtonColor(Button button)
    {
        SetButtonColor(button, defaultColor);
    }

    // Method to set the color of a button
    private void SetButtonColor(Button button, Color color)
    {
        ColorBlock CB = button.colors;
        CB.normalColor = color;
        CB.highlightedColor = color;
        CB.pressedColor = color;
        button.colors = CB;
    }
}








