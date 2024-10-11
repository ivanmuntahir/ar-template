using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimulationManager : MonoBehaviour
{
    public List<SimulationStepHandler> steps;  // The collection of steps to execute
    private int currentStepIndex = 0;  // Track which step we are on

    private void Start()
    {
        // Start the first step
        if (steps.Count > 0)
        {
            StartStep(currentStepIndex);
        }
        else
        {
            Debug.LogError("No steps available in the simulation.");
        }
    }

    private void StartStep(int stepIndex)
    {
        // Ensure the index is within range
        if (stepIndex >= 0 && stepIndex < steps.Count)
        {
            // Get the current step handler
            SimulationStepHandler currentStep = steps[stepIndex];

            // Subscribe to the isDisabled event to know when the step is done
            currentStep.isDisabled.AddListener(OnStepComplete);

            // Trigger the isEnabled event to start the current step
            if (currentStep.isEnabled != null)
            {
                currentStep.isEnabled.Invoke();
            }

            Debug.Log($"Step {stepIndex + 1} started.");
        }
        else
        {
            Debug.LogError($"Step index {stepIndex} is out of range.");
        }
    }

    // This is called when a step completes (i.e., when isDisabled is triggered)
    public void OnStepComplete()
    {
        // Unsubscribe from the current step's isDisabled event
        if (currentStepIndex >= 0 && currentStepIndex < steps.Count)
        {
            steps[currentStepIndex].isDisabled.RemoveListener(OnStepComplete);
        }
        else
        {
            Debug.LogError("Current step index is out of range in OnStepComplete.");
            return;
        }

        // Move to the next step
        currentStepIndex++;

        // Start the next step if it's within range
        if (currentStepIndex < steps.Count)
        {
            StartStep(currentStepIndex);
        }
        else
        {
            Debug.Log("Simulation complete. All steps executed.");
        }
    }
}
