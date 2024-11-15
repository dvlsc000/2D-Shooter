using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InfoBtn : MonoBehaviour
{
    public GameObject infoPanel; // Reference to info panel containg additional infromation
    public Button button; // Reference to infor button 
    private bool isInfoPanelVisible = false; // Track the visability of the panel
    
    void Start()
    {
        // Add a listener to button click event
        button.onClick.AddListener(OnButtonClick);
        infoPanel.SetActive(false);

    }

    void OnButtonClick()
    {
        // Toggle the visability of additional information 
        isInfoPanelVisible = !isInfoPanelVisible;
        // Set it according to the flag
        infoPanel.SetActive(isInfoPanelVisible);
    }


}
