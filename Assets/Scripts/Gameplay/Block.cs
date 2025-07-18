using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [Header("References")]
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject sparklesFX;
    [SerializeField] Sprite[] hitSprites;

    [Header("Config")]
    [SerializeField] int maxHit = 3;

    private int timesHit = 0;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // if the block is breakable then add it to level
    private void Start()
    {
        if (tag == "Breakable")
        {
            LevelManager.Instance.AddBreakableBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            timesHit++;
            if (timesHit >= maxHit)
            {
                AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position, PlayerPrefs.GetFloat("SfxVolume"));
                LevelManager.Instance.BlockDestroyed();
                GameManager.Instance.AddToScore();
                TriggerSparkles();
                Destroy(gameObject);
            }
            else
            {
                NextHitSprite();
            }
        }
    }

    // show next sprite of block after being hit
    private void NextHitSprite()
    {
        int counter = timesHit - 1;
        spriteRenderer.sprite = hitSprites[counter];
    }

    //show sparkles when the block breakes
    public void TriggerSparkles()
    {
        GameObject sparkles = Instantiate(sparklesFX, transform.position, transform.rotation);
        Destroy(sparkles, 2f);
    }

}
