using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [Header("REFERENCES")]
    [SerializeField] GameObject pauseUI;
    [SerializeField] Transform ballTransform;

    [Header("Config")]
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
    [SerializeField] float q = 16f;
  
    bool isAutoPlaying;

    private void Start()
    {
        isAutoPlaying = GameManager.Instance.AutoPlayEnabled();
    }

    void Update()
    {
        MovePaddle();
    }

    private void MovePaddle()
    {
      Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
      paddlePos.x = Mathf.Clamp(GetPosX(), minX, maxX);
      transform.position = paddlePos;
    }

    private float GetPosX()
    {
        if (isAutoPlaying)
        {
            return ballTransform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * q;
        }
    }
}
