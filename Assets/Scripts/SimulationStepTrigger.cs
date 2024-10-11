using UnityEngine;
using UnityEngine.UI;

public class SimulationStepTrigger : MonoBehaviour
{
    /*public Button completeStepButton;*/           // Reference to the button to complete the step
    public SimulationStepHandler stepHandler;   // Reference to the current step's handler
    public SimulationManager simulationManager; // Reference to the simulation manager

   /* private void Start()
    {
        // Ensure the button is linked to trigger the OnStepComplete function
        if (completeStepButton != null)
        {
            completeStepButton.onClick.AddListener(OnStepComplete);
        }
    }*/

    // Function called when the button is clicked
    public void OnStepComplete()
    {
        if (stepHandler != null)
        {
            // Notify the step handler to trigger its isDisabled event
            stepHandler.isDisabled.Invoke();
        }

        if (simulationManager != null)
        {
            // Notify the simulation manager that the step is complete, so it can move to the next step
            simulationManager.OnStepComplete();
        }
    }
}
