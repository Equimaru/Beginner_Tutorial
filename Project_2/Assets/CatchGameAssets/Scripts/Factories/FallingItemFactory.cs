using UnityEngine;

namespace Catch
{
    public abstract class FallingItemFactory : MonoBehaviour
    {
        public abstract FallingItem CreateFallingItem();

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
            Debug.LogError("There is no camera in scene.");
            return 0f;
        }
    }
}

