using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using Unity.Notifications.Android;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour
{
    /*
     * android ver. 7.1.1
     * 
     */
    public void PlayPressed()
    {
        //SceneManager.LoadScene("Level1");

        /*
        var notification = new AndroidNotification
        {
            Title = "Сообщение от SheepJumps",
            Text = "Вы нажали кнопку Play",
            FireTime = System.DateTime.Now.AddMinutes(1)
        };
        
        AndroidNotificationCenter.SendNotification(notification, "channel_id");
        */
        SceneManager.LoadScene("Level1");
    }

    public void ExitPressed()
    {
        //Debug.Log("Exit pressed!");
        Application.Quit();
    }
}
