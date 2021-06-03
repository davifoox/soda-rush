using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsePowerUpButton : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    [SerializeField] Button button;
    [SerializeField] Image image;

    private int currentSprite = 0;
    public string currentMentosColor;

    private void Start()
    {
        button.onClick.AddListener(() => { ButtonPressed(); });
    }

    public void SetMentosProperties(int quantity, string mentosColor)
    {
        GetComponent<AudioSource>().Play();
        currentMentosColor = mentosColor;
        currentSprite = quantity -1;
        image.sprite = sprites[currentSprite];
    }

    void ButtonPressed()
    {
        currentSprite--;
        if (currentSprite == -1)
            this.gameObject.SetActive(false);
        else
            image.sprite = sprites[currentSprite];
    }
}
