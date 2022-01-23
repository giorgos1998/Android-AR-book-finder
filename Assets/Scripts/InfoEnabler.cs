using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class InfoEnabler : MonoBehaviour, ITrackableEventHandler
{
    private TrackableBehaviour mTrackableBehaviour;
    private float timer = 0f;
    private bool startTimer = false;
    private bool itemSpawned = false;

    public GameObject infoCanvas;
    public GameObject menuButton;
    public UnityEngine.UI.Image buttonImage;

    // Start is called before the first frame update
    void Start()
    {
        // initialize image tracker
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer)
        {
            // simple timer using frametime
            timer += Time.deltaTime;
        }
    }

    // called when image target is lost or found
    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            // if target was found
            onTrackingFound();
        }
        else
        {
            // if target was lost
            onTrackingLost();
        }
    }

    // called when image target was found
    private void onTrackingFound()
    {
        // if book was lost for too long, disable canvas and re-enable it to play the animation
        if (timer > 2f && infoCanvas != null)
        {
            infoCanvas.SetActive(false);
            itemSpawned = false;
            buttonImage.gameObject.SetActive(false);
        }
        // book found, stop and reset the timer
        startTimer = false;
        timer = 0f;

        // if the item is disabled, enable it
        if (infoCanvas != null && !itemSpawned)
        {
            
            infoCanvas.SetActive(true);
            itemSpawned = true;
            // enable button a bit later
            Invoke("DisplayButton", 2f);
        }
    }

    // called when image target was lost
    private void onTrackingLost()
    {
        // if the book is lost, start counting for how long it's been lost
        startTimer = true;
    }

    private void DisplayButton()
    {
        buttonImage.gameObject.SetActive(true);
    }
}
