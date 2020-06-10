using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    [System.Obsolete]
    private void Update()
    {
        if (health > numOfHearts) {
            health = numOfHearts;
        }
        if (health < 1)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
                hearts[i].sprite = fullHeart;
            else
                hearts[i].sprite = emptyHeart;
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

         if (collision.gameObject.tag == "Enemy") { 
                health--;
        }
    }
}
