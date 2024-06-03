using UnityEngine;

namespace Catch
{
    public abstract class DroppableFactory : MonoBehaviour
    {
        public abstract Droppable CreateDroppable();

        protected float GetRandomXPos()
        {
            Vector3 position = transform.position;
            float gapAtBorder = 1f;
            if (Camera.main != null)
            {
                Vector2 screenSize = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
                float randomX = Random.Range(screenSize.x * -1 + gapAtBorder, screenSize.x - gapAtBorder);
                return randomX;
            }
            else
            {
                Debug.LogError("There is no camera in scene.");
                return 0f;
            }
        }
    }
}

