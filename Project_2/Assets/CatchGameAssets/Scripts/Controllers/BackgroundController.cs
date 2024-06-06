using Catch;
using UnityEngine;

namespace Catch
{
    public class BackgroundController : MonoBehaviour
    {
        [SerializeField] private BackgroundFactory backgroundFactory;
    
        private Background _currentBackground;

        public void ChangeBackground()
        {
            var newBackground = backgroundFactory.CreateBackground();
            if (_currentBackground != null)
            {
                while (newBackground.colour == _currentBackground.colour)
                {
                    Destroy(newBackground);
                    newBackground = backgroundFactory.CreateBackground();
                }
                Destroy(_currentBackground);
            }

            _currentBackground = newBackground;
        }
    }
}
