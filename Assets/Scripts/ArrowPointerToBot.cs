using UnityEngine;

public class ArrowPointerToBot : MonoBehaviour
{
    public string targetTag = "Bot"; // Тег объектов, к которым стрелка должна указывать
    public Transform playerTransform; // Ссылка на трансформ игрока (должно быть присвоено через инспектор)

    private Transform closestBot; // Трансформ ближайшего объекта с тегом "Bot"

    void Update()
    {
        FindClosestBot(); // Находим ближайший объект с тегом "Bot"

        if (closestBot != null && playerTransform != null)
        {
            // Вычисляем направление к ближайшему объекту "Bot"
            Vector3 direction = closestBot.position - playerTransform.position;

            // Поворачиваем стрелку (изображение) в направлении ближайшего объекта "Bot"
            if (direction != Vector3.zero)
            {
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f); // Учитываем начальное положение стрелки
            }
        }
    }

    void FindClosestBot()
    {
        GameObject[] botObjects = GameObject.FindGameObjectsWithTag(targetTag);

        if (botObjects.Length > 0)
        {
            float closestDistance = Mathf.Infinity;

            foreach (var botObject in botObjects)
            {
                float distance = Vector3.Distance(playerTransform.position, botObject.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestBot = botObject.transform;
                }
            }
        }
        else
        {
            closestBot = null;
        }
    }
}
