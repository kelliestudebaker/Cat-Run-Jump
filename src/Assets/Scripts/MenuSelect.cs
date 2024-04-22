using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuSelect : MonoBehaviour
{
    public Text startGame;
    public Text controls;
    public Text erase;
    public Text credits;
    public Text quit;

    public GameObject ControlsPanel;
    public GameObject CreditsPanel;

    private int numberOfOptions = 5;
    private int selectedOption;

    public AudioSource source;
    public AudioClip clickSound;

    void Start()
    {
        selectedOption = 1;
        startGame.color = new Color32(255, 218, 0, 255);
        controls.color = new Color32(0, 0, 0, 255);
        erase.color = new Color32(0, 0, 0, 255);
        credits.color = new Color32(0, 0, 0, 255);
        quit.color = new Color32(0, 0, 0, 255);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        { //Input telling it to go up or down.
            selectedOption += 1;
            if (selectedOption > numberOfOptions) //If at end of list go back to top.
            {
                selectedOption = 1;
            }

            startGame.color = new Color32(0, 0, 0, 255);
            controls.color = new Color32(0, 0, 0, 255);
            erase.color = new Color32(0, 0, 0, 255);
            credits.color = new Color32(0, 0, 0, 255);
            quit.color = new Color32(0, 0, 0, 255);

            switch (selectedOption) //Set the color to yellow to indicate which option you are on.
            {
                case 1:
                    startGame.color = new Color32(255, 218, 0, 255);
                    break;
                case 2:
                    controls.color = new Color32(255, 218, 0, 255);
                    break;
                case 3:
                    erase.color = new Color32(255, 218, 0, 255);
                    break;
                case 4:
                    credits.color = new Color32(255, 218, 0, 255);
                    break;
                case 5:
                    quit.color = new Color32(255, 218, 0, 255);
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        { //Input telling it to go up or down.
            selectedOption -= 1;
            if (selectedOption < 1) //If at end of list go back to top.
            {
                selectedOption = numberOfOptions;
            }

            startGame.color = new Color32(0, 0, 0, 255);
            controls.color = new Color32(0, 0, 0, 255);
            erase.color = new Color32(0, 0, 0, 255);
            credits.color = new Color32(0, 0, 0, 255);
            quit.color = new Color32(0, 0, 0, 255);

            switch (selectedOption) //Set the color to yellow to indicate which option you are on.
            {
                case 1:
                    startGame.color = new Color32(255, 218, 0, 255);
                    break;
                case 2:
                    controls.color = new Color32(255, 218, 0, 255);
                    break;
                case 3:
                    erase.color = new Color32(255, 218, 0, 255);
                    break;
                case 4:
                    credits.color = new Color32(255, 218, 0, 255);
                    break;
                case 5:
                    quit.color = new Color32(255, 218, 0, 255);
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 0"))
        {
            Debug.Log("Option: " + selectedOption);

            switch (selectedOption) //Set the color to yellow to indicate which option you are on.
            {
                case 1:
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Go to level select scene.
                    break;
                case 2:
                    source.clip = clickSound;
                    source.Play();
                    ControlsPanel.SetActive(true); //Show the panel that explains the controls.
                    break;
                case 3:
                    source.clip = clickSound;
                    source.Play();
                    PlayerPrefs.DeleteAll();
                    break;
                case 4:
                    source.clip = clickSound;
                    source.Play();
                    CreditsPanel.SetActive(true); //Show the credits panel.
                    break;
                case 5:
                    source.clip = clickSound;
                    source.Play();
                    //UnityEditor.EditorApplication.isPlaying = false;
                    Application.Quit(); //Quit the game.
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown("joystick button 0"))
        {
            source.clip = clickSound;
            source.Play();
            ControlsPanel.SetActive(false); //Hide the controls panel when the esc key is pressed.
            CreditsPanel.SetActive(false); //Hide the credits panel when the esc key is pressed.
        }

    }
}