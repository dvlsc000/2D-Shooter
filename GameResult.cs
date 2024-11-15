using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameResult : MonoBehaviour
{
    void Start()
    {
        UpdateResultText(); // Update the result text
    }

    void UpdateResultText()
    {
        // Check if the PlayerPrefs key exists 
        if (PlayerPrefs.HasKey("ResultText"))
        {
            // Retrieve the result text
            string resultText = PlayerPrefs.GetString("ResultText");
            
            // Find the text component with the "WinOrLose" tag and update its text
            Text resultTextComponent = GameObject.FindGameObjectWithTag("WinOrLose").GetComponent<Text>();
            
            if (resultTextComponent != null)
            {
                // Update the text of the text component
                resultTextComponent.text = resultText;
            }

            // Delete the PlayerPrefs key to avoid displaying the result again on restart
            PlayerPrefs.DeleteKey("ResultText");
        }
    }
}
