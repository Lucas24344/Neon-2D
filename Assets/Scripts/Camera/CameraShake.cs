using UnityEngine;
using Unity.Cinemachine;
public class CameraShake : MonoBehaviour
{
    private CinemachineBasicMultiChannelPerlin cm;
    void Start()
    {
       cm = GetComponent<CinemachineCamera>().GetComponent<CinemachineBasicMultiChannelPerlin>();
       cm.AmplitudeGain = 0;
    }

    public void Shake(float intensity, float duration)
    {
        cm.AmplitudeGain = intensity;
        Invoke(nameof(ResetIntensity), duration);
    }
    void ResetIntensity()
    {
        cm.AmplitudeGain = 0;
    }
}
