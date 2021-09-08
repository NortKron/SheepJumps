using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using Unity.Notifications.Android;


public class MenuControls : MonoBehaviour
{
    /*
     * android ver. 7.1.1
     * 
     */
    public void PlayPressed()
    {
        //SceneManager.LoadScene("Level1");

        var notification = new AndroidNotification();
        notification.Title = "Сообщение от SheepJumps";
        notification.Text = "Вы нажали кнопку Play";
        notification.FireTime = System.DateTime.Now.AddMinutes(1);

        AndroidNotificationCenter.SendNotification(notification, "channel_id");
    }

    public void ExitPressed()
    {
        //Debug.Log("Exit pressed!");
        Application.Quit();
    }
}
