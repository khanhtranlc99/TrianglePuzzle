using UnityEngine;

public class SimpleVibrationTest : MonoBehaviour
{
    void Update()
    {
        // Nhấn V để test vibration
        if (Input.GetKeyDown(KeyCode.V))
        {
            Debug.Log("=== SIMPLE VIBRATION TEST ===");
            Debug.Log($"Platform: {Application.platform}");
            Debug.Log($"IsAndroid: {VibrationMng.IsAndroid()}");
            
            // Test vibration
            VibrationMng.Vibrate(500);
            
            // Test handheld vibration
            Debug.Log("Testing Handheld.Vibrate()...");
            Handheld.Vibrate();
        }
        
        // Nhấn C để test cancel vibration
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("Cancelling vibration...");
            VibrationMng.Cancel();
        }
    }
}
