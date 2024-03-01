using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class VRSoundButton : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource AB;
    private XRController controller;
    void Start()
    {
        controller = GetComponent<XRController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool selectButtonValue)&&selectButtonValue)
        {
            Debug.Log("select button pressed");
            AB.Play();
        }
    }
}
