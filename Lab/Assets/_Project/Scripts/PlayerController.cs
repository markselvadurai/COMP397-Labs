using Unity.VisualScripting;
using UnityEngine;

namespace Platformer397
{
    public class PlayerController : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        [SerializeField] private InputReader input;
        private void Start()
        {
            Debug.Log("[START]");
            input.EnablePlayerActions();
        }
        private void OnEnable()
        {
            input.Move += GetMovement;
        }
        private void OnDisable()
        {
            input.Move -= GetMovement;
        }
        private void Destroy()
        {
            Debug.Log("[Destroy]");
        }
        private void GetMovement(Vector2 move)
        {
            Debug.Log("Input: " + move);
        }
    }
}
