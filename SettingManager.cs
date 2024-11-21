using UnityEngine; //Erina

public class SettingManager : MonoBehaviour
{
    public GameObject settingPanel;
    public GameObject instructionPanel;
    public GameObject soundPanel;

    // Called when the Setting button is clicked
    public void OnSettingButtonClicked()
    {
        Debug.Log("Setting Button Clicked");

       
       

        // Show the setting panel
        settingPanel.SetActive(true);
    }

    // Called when the Instruction button is clicked
    public void OnInstructionButtonClicked()
    {
        Debug.Log("Instruction Button Clicked");

       

        // Show the instruction panel
        instructionPanel.SetActive(true);
    }

    // Called when the Sound button is clicked
   

    // Called when the ExitInstructionButton is clicked
    public void OnExitInstructionButtonClicked()
    {
        Debug.Log("Exit Instruction Button Clicked");

        // Hide the instruction panel and show the setting panel
        instructionPanel.SetActive(false);
        settingPanel.SetActive(true);
    }

    // Called when the SoundExitButton is clicked
  

    // Called when the ExitSettingPanel button is clicked
    public void OnExitSettingPanelClicked()
    {
        Debug.Log("Exit Setting Panel Button Clicked");

        // Hide the setting panel (or optionally go to the main menu or do another action)
        settingPanel.SetActive(false);

        // Add your logic here if you want to go back to a main menu or another scene
    }
}
