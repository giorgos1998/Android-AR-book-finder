using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;

public class MenuButtonBehaviour : MonoBehaviour, IVirtualButtonEventHandler
{
    private float timer = 0f;
    private bool startTimer = false;
    private bool buttonPressed = false;
    private UnityEngine.UI.Image[] edges;
    private Sprite[] greenSprites;
    private Sprite[] redSprites;
    private int currentEdge = 0;

    public GameObject menuButton;
    public UnityEngine.UI.Image buttonImage;

    [Header("Edges images")]
    public UnityEngine.UI.Image topLeftEdge;
    public UnityEngine.UI.Image topRightEdge;
    public UnityEngine.UI.Image bottomLeftEdge;
    public UnityEngine.UI.Image bottomRightEdge;

    [Header("Green edges sprites")]
    public Sprite gTopLeft;
    public Sprite gTopRight;
    public Sprite gBottomLeft;
    public Sprite gBottomRight;

    [Header("Red edges sprites")]
    public Sprite rTopLeft;
    public Sprite rTopRight;
    public Sprite rBottomLeft;
    public Sprite rBottomRight;

    // Start is called before the first frame update
    void Start()
    {
        menuButton.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);

        // add edges and sprites to lists in clockwise order
        edges = new UnityEngine.UI.Image[] { topLeftEdge, topRightEdge, bottomRightEdge, bottomLeftEdge };
        greenSprites = new Sprite[] { gTopLeft, gTopRight, gBottomRight, gBottomLeft };
        redSprites = new Sprite[] {rTopLeft, rTopRight, rBottomRight, rBottomLeft};
    }

    

    // Update is called once per frame
    void Update()
    {
        if (startTimer)
        {
            // simple timer using frametime
            timer += Time.deltaTime;
        }

        // if button is pressed and timer is running
        if (buttonPressed && startTimer)
        {
            // for each 0.5 seconds
            if (timer > 0.5f)
            {
                // turn current edge red, reset timer and move marker to the next one
                edges[currentEdge].sprite = redSprites[currentEdge];
                timer = 0f;
                currentEdge++;
            }
            // if all edges are red (edges are 0-3)
            if (currentEdge == 4)
            {
                // stop timer and return to menu
                startTimer = false;
                Invoke("BackToMenu", 0.5f);
            }
        }
        // if button is released and timer is running
        else if (!buttonPressed && startTimer)
        {
            // for each 0.5 seconds
            if (timer > 0.5f)
            {
                // turn current edge green, reset timer and move marker to the previous one
                edges[currentEdge].sprite = greenSprites[currentEdge];
                timer = 0f;
                currentEdge--;
            }
            // if all edges are green (edges are 0-3)
            if (currentEdge == -1)
            {
                // stop timer and reset edge marker
                startTimer = false;
                currentEdge = 0;
            }
        }

        // if user pressed phone's back button
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BackToMenu();
        }
    }

    // called when virtual button is pressed
    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        // add click effect, reset and start hold timer and set button pressed flag
        buttonImage.color = new Color(0.7f, 0.7f, 0.7f, 1f);
        timer = 0f;
        buttonPressed = true;
        startTimer = true;
    }

    // called when virtual button is released
    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        // remove click effect, reset and start release timer and set button pressed flag
        buttonImage.color = new Color(1f, 1f, 1f, 1f);
        timer = 0f;
        buttonPressed = false;
        startTimer = true;
    }

    private void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
