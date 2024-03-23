using UnityEngine;

public class CorrectSelectionMarkerPair : MonoBehaviour
{
    [SerializeField] CorrectSelectionMarker _correctMarkerImage1;
    [SerializeField] CorrectSelectionMarker _correctMarkerImage2;

    void Start()
    {
        _correctMarkerImage1.Init(this);
        _correctMarkerImage2.Init(this);
    }

    public void NotifySelected()
    {
        _correctMarkerImage1.MakeVisibleAndUnselectable();
        _correctMarkerImage2.MakeVisibleAndUnselectable();
    }
}
