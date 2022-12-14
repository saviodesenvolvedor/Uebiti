using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlSound : MonoBehaviour
{
    private bool estadoSom = true;
    [SerializeField] private AudioSource fundoMuscial;

    [SerializeField] private Sprite somligadoSprite;
    [SerializeField] private Sprite somdesligadoSprite;

    [SerializeField] private Image muteImage;

    public void LigarDesligarSom()
    {
        estadoSom = !estadoSom;
        fundoMuscial.enabled = estadoSom;

        if (estadoSom)
        {
            muteImage.sprite = somligadoSprite;
        }
        else
        {
            muteImage.sprite = somdesligadoSprite;
        }
    }

    public void volumeMuscial(float value)
    {
        fundoMuscial.volume = value;
    }
}
