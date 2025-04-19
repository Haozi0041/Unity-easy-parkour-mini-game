using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private Image circle;
    public int maxBullets { get; private set; }
    private Text bullet;
    public int bulletNumber { get; private set; }

    private void Awake()
    {
        circle = transform.GetChild(1).GetComponent<Image>();
        circle.enabled = false;
        bullet = transform.GetChild(3).GetComponent<Text>();
        maxBullets = 3;
    }
    public void AddCircleState(bool isEnough)
    {
        circle.enabled = isEnough ? true : false;
    }

    public void AddItem()
    {
        bulletNumber++;
        UpdateUI();
    }
    public void RemoveItem()
    {
        bulletNumber--;
        UpdateUI();
    }

    private void UpdateUI()
    {
        bullet.text = "X    "+bulletNumber;
    }

}
