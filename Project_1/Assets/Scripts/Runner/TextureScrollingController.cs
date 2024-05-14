using UnityEngine;

namespace Runner
{
    public class TextureScrollingController : MonoBehaviour
    {
        public void StopScrolling()
        {
            TextureScrolling[] scrollingObjects = FindObjectsOfType<TextureScrolling>();

            foreach (TextureScrolling i in scrollingObjects)
            {
                i.isScrolling = false;
            }
        }
    }
}

