using UnityEngine;

public class CoverPicker : MonoBehaviour
{
    public GameObject cam;
    public GameObject target1;
    public GameObject target2;
    public GameObject target3;
    public GameObject target4;


    // Start is called before the first frame update
    void Start()
    {
        // get stored book choice from previous scene
        int pickedCover = PlayerPrefs.GetInt("cover");

        // activate image target based on book choice
        if (pickedCover == 1)
        {
            target1.SetActive(true);
        }
        else if (pickedCover == 2)
        {
            target2.SetActive(true);
        }
        else if (pickedCover == 3)
        {
            target3.SetActive(true);
        }
        else
        {
            target4.SetActive(true);
        }

        // AR camera MUST be activated AFTER image target is enabled or tracking will not work
        cam.SetActive(true);
    }
}
