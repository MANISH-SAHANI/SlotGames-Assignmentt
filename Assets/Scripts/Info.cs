using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Info : MonoBehaviour
{
    public TMP_InputField inputField;
    public Button editButton;

    void Start()
    {
        // Add listener to the edit button
        editButton.onClick.AddListener(ActivateInputField);
    }

    void ActivateInputField()
    {
        print("Edit button clicked");
        // Enable the input field
        inputField.interactable = true;
        inputField.Select();
        inputField.ActivateInputField();
    }
}
