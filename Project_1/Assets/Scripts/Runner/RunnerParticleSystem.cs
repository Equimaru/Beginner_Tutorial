using UnityEngine;

namespace Runner
{
    public class RunnerParticleSystem : MonoBehaviour
    {
        [SerializeField] private GameObject explosion;
        [SerializeField] private GameObject shine;


        public void DoShine(Vector3 pos)
        {
            Instantiate(shine, pos, Quaternion.identity);
        }
        
        public void DoExplosion(Vector3 pos)
        {
            Instantiate(explosion, pos, Quaternion.identity);
        }
    }
}