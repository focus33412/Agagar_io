using UnityEngine;

public class DeleteObjectOnClick : MonoBehaviour
{
    void Update()
    {
        // Проверяем, была ли нажата левая кнопка мыши на текущем объекте
        if (Input.GetMouseButtonDown(0))
        {
            // Получаем позицию клика мыши в мировых координатах
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Проверяем, был ли произведен клик на текущем объекте
            Collider2D collider = Physics2D.OverlapPoint(clickPosition);
            if (collider != null && collider.gameObject == gameObject)
            {
                // Удаляем текущий объект из сцены
                Destroy(gameObject);
            }
        }
    }
}
