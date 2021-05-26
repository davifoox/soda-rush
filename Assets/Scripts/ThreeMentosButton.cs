using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThreeMentosButton : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    [SerializeField] Button button;
    [SerializeField] Image image;

    private int currentSprite = 0;

    private void Start()
    {
        button.onClick.AddListener(() => { ButtonPressed(); });
    }

    private void OnEnable()
    {
        currentSprite = 0;
        image.sprite = sprites[currentSprite];
    }

    void ButtonPressed()
    {
        currentSprite++;
        if (currentSprite == 3)
            this.gameObject.SetActive(false);
        else
            image.sprite = sprites[currentSprite];
    }
}
