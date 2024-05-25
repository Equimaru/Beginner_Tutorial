using UnityEngine;

namespace Runner
{
    public class RunnerParticleSystem : MonoBehaviour
    {
        [SerializeField] private GameObject explosion;


        public void DoExplosion(Vector3 pos)
        {
            Instantiate(explosion, pos, Quaternion.identity);
        }
    }
}