using UnityEngine;

public class PanelController : MonoBehaviour
{
    public Animator panelBAnimator;
    private bool isPanelBVisible = false; // Track visibility state

    public void TogglePanelB()
    {
        if (isPanelBVisible)
        {
            // Hide Panel B
            panelBAnimator.SetTrigger("SlideOut");
        }
        else
        {
            // Show Panel B
            panelBAnimator.SetTrigger("SlideIn");
        }
        
        isPanelBVisible = !isPanelBVisible; // Toggle the state
    }
}
