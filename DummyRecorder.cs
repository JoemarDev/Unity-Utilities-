using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class DummyRecorder : MonoBehaviour
{
    public Slider indicatorPeak;
    public Slider indicatorRMS;
    

    private void Update()
    {
        indicatorPeak.value = MicInput.MicLoudnessPeak ;
        indicatorRMS.value = MicInput.MicLoudnessRMS * MicSensivitiy;
    }

}