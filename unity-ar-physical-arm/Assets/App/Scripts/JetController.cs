using MRTKExtensions.QRCodes;
using UnityEngine;

public class JetController : MonoBehaviour
{
    [SerializeField]
    private QRTrackerController trackerController;

    private void Start()
    {
        trackerController.PositionSet += PoseFound;
    }

    private void PoseFound(object sender, Pose pose)
    {
        Vector3 myVector = new Vector3(0.0f, 0.2f, 0.0f);
        var childObj = transform.GetChild(0);
        childObj.SetPositionAndRotation(pose.position+myVector, pose.rotation);
        childObj.gameObject.SetActive(true);
    }
}