using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public PlayerMovement playerScript;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI fruitText;

    // Update is called once per frame
    void Update()
    {
        livesText.text = "Lives: " + playerScript.lives;
        fruitText.text = "Fruit: " + playerScript.totalFruit;
    }
}
