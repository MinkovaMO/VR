using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARFaceManager))]

public class faceController : MonoBehaviour
{
    [SerializeField]
    private Button swapFaceToggle;
    private ARFaceManager arFaceManager;
    private bool faceTrackingOn = true;
    private int swapCounter = 0;

    [SerializeField]
    public faceMaterial[] materials;

    void Awake()
    {
        arFaceManager = GetComponent<ARFaceManager>();
        swapFaceToggle.onClick.AddListener(swapFaces);
        arFaceManager.facePrefab.GetComponent<MeshRenderer>().material = materials[0].Material;
    }

    void swapFaces()
    {
        swapCounter = swapCounter == materials.Length - 1 ? 0 : swapCounter + 1;

        foreach (ARFace face in arFaceManager.trackables)
        {
            face.GetComponent<MeshRenderer>().material = materials[swapCounter].Material;
        }

        swapFaceToggle.GetComponentInChildren<Text>().text = "Face Tracking (" + materials[swapCounter].Name + ")";
    }

    [System.Serializable]
    public class faceMaterial
    {
        public Material Material;
        public string Name;
    }
}
