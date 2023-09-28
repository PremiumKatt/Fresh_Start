using UnityEngine;
using UnityEngine.UI;

public class PlayerUserInterfaceManager : MonoBehaviour
{
    public PlayerHealthManager playerHealth;
    public Image[] hearts;
    private void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].color = i < playerHealth.currentLives ? new Color(1, 1, 1, 1) : new Color(1, 1, 1, 0.1f);
        }

    }
}
