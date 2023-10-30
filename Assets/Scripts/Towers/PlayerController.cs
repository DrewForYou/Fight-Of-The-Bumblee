using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public PlayerInput PlayerInputInstance;
    public WaveManager WaveManager;
    public GameManager GameManager;
 
    private InputAction leftClick;
    private InputAction rightClick;
    private InputAction space;
    private InputAction quit;
    private InputAction restart;
    private InputAction pause;

    public UpgradeButton UpgradeButton;
    //public GameObject Upgrades;
    public AudioClip waveStart;
    //private ArcherBeeTower selectedTower;
    void Start()
    {
        PlayerInputInstance = GetComponent<PlayerInput>();

        PlayerInputInstance.currentActionMap.Enable();      // turns on action map

        // finds the "LeftClick" action in the current action map
        leftClick = PlayerInputInstance.currentActionMap.FindAction("LeftClick");
        rightClick = PlayerInputInstance.currentActionMap.FindAction("RightClick");
        space = PlayerInputInstance.currentActionMap.FindAction("Space");
        quit = PlayerInputInstance.currentActionMap.FindAction("Quit");
        restart = PlayerInputInstance.currentActionMap.FindAction("Restart");
        pause = PlayerInputInstance.currentActionMap.FindAction("Pause");

        leftClick.performed += LeftClick_performed;
        rightClick.performed += RightClick_performed;
        space.performed += Space_performed;
        quit.performed += Quit_performed;
        restart.performed += Restart_performed;
        pause.performed += Pause_performed;
    }

    private void Pause_performed(InputAction.CallbackContext obj)
    {
        GameManager.Pause();
    }

    private void Restart_performed(InputAction.CallbackContext obj)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Quit_performed(InputAction.CallbackContext obj)
    {
        print("Quit");
        Application.Quit();
    }

    private void Space_performed(InputAction.CallbackContext obj)
    {
        WaveManager.TempStart = true;
        AudioSource.PlayClipAtPoint(WaveStart, Camera.main.transform.position);
    }

    private void OnDestroy()
    {
        leftClick.performed -= LeftClick_performed;
        rightClick.performed -= RightClick_performed;
        space.performed -= Space_performed;
        quit.performed -= Quit_performed;
        restart.performed -= Restart_performed;
        pause.performed -= Pause_performed;
    }

    public void RightClick_performed(InputAction.CallbackContext obj)
    {
        // detect tower the player is clicking
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

        if (hit.collider != null)
        {
            //selectedTower = hit.collider.GetComponent<UpgradeButton>();
            ArcherBeeTower tower = hit.collider.GetComponent<ArcherBeeTower>();
            //MageBeeCode tower = hit.collider.GetComponent<MageBeeCode>();
            
            if (tower != null)
            {
                UpgradeButton.Instance.SelectedTower(tower);
            }

        }
        if (hit.collider != null)
        {
            MageBeeCode tower = hit.collider.GetComponent<MageBeeCode>();

            if (tower != null)
            {
                UpgradeButton.Instance.SelectedTower(tower);
            }

        }

        if (hit.collider != null)
        {
            WarriorBeeCode tower = hit.collider.GetComponent<WarriorBeeCode>();

            if (tower != null)
            {
                UpgradeButton.Instance.SelectedTower(tower);
            }

        }

        if (hit.collider != null)
        {
            SniperBee tower = hit.collider.GetComponent<SniperBee>();

            if (tower != null)
            {
                UpgradeButton.Instance.SelectedTower(tower);
            }

        }

    }
    public void LeftClick_performed(InputAction.CallbackContext obj)
    {
        // finds the position of the player's mouse 
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        // this code makes it so the tower will snap to the grid - tower will be placed inside
        // the closest grid player is clicking on. without the + 0.5f & -0.5f the towers
        // instantiate on the middle lines of the grid - not in the middle of the grid square
        mousePosition.x = Mathf.Round(mousePosition.x + 0.5f) - 0.5f;
        mousePosition.y = Mathf.Round(mousePosition.y + 0.5f) - 0.5f;
        
        // instantiate the tower at the player's mouse position
        TowerPlacement.instance.PlaceTower(mousePosition);

        //Debug.Log("Player Clicked");        // let's us know the player is able
        // to click

        // detect tower the player is clicking
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

        if (hit.collider != null)
        {
            //selectedTower = hit.collider.GetComponent<UpgradeButton>();
            ArcherBeeTower tower = hit.collider.GetComponent<ArcherBeeTower>();
            //MageBeeCode tower = hit.collider.GetComponent<MageBeeCode>();

            if (tower != null)
            {
                UpgradeButton.Instance.SelectedTower(tower);
            }

        }
        if (hit.collider != null)
        {
            MageBeeCode tower = hit.collider.GetComponent<MageBeeCode>();

            if (tower != null)
            {
                UpgradeButton.Instance.SelectedTower(tower);
            }

        }

        if (hit.collider != null)
        {
            WarriorBeeCode tower = hit.collider.GetComponent<WarriorBeeCode>();

            if (tower != null)
            {
                UpgradeButton.Instance.SelectedTower(tower);
            }

        }

        if (hit.collider != null)
        {
            SniperBee tower = hit.collider.GetComponent<SniperBee>();

            if (tower != null)
            {
                UpgradeButton.Instance.SelectedTower(tower);
                
            }

        }
    }
    
   

}
