using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private bool isPause;

    public GameObject panelMenuPause;
    public GameObject panelPlayerGUI;
    public GameObject panelGameEnd;

    // Start is called before the first frame update
    void Start()
    {
        panelPlayerGUI.SetActive(true);
        panelMenuPause.SetActive(false);        
        panelGameEnd.SetActive(false);

        isPause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            OnPause();
        }
    }



    public void OnPause()
    {
        Time.timeScale = isPause ? 1 : 0;
        isPause = !isPause;

        Cursor.visible = isPause;
        panelMenuPause.SetActive(isPause);
        //panelPlayerGUI.SetActive(!isPause);
        //controllerState = ControllerState.PlayerController;
    }
}
