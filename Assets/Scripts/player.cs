using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public float moveSpeed; // Скорость движения
    Rigidbody2D rb; // Компонент Rigidbody2D

    private Vector2 targetPosition; // Целевая позиция

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetPosition = rb.position; // Инициализация целевой позиции текущим положением
    }

    void Update()
    {
        // Обновляем целевую позицию при клике мыши
        if (Input.GetMouseButtonDown(0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    void FixedUpdate()
    {
        // Перемещение к целевой позиции
        if ((Vector2)rb.position != targetPosition)
        {
            Vector2 newPosition = Vector2.MoveTowards(rb.position, targetPosition, moveSpeed * Time.fixedDeltaTime);
            rb.MovePosition(newPosition);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Block")
        {
            SceneManager.LoadScene("Main");
        }
    }
}
