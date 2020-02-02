using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResetSystem : MonoBehaviour
{
    public GameObject deathScreen;

    public void DeathScreen()
    {
        deathScreen.SetActive(true);
    }

    public void Reboot()
    {
        SceneManager.LoadScene("GameScene_1");
    }
}
