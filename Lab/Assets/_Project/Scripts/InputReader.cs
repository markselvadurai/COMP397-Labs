using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static InputSystem_Actions;

namespace Platformer397
{
    [CreateAssetMenu(fileName = "InputReader", menuName = "Scriptable Objects/InputReader")]
    public class InputReader : ScriptableObject, IPlayerActions
    {
        public event UnityAction<Vector2> Move = delegate { };

        InputSystem_Actions input;
        private void OnEnable()
        {
            if(input == null)
            {
                input = new InputSystem_Actions();
                input.Player.SetCallbacks(this);
            }
        }
        public void EnablePlayerActions()
        {
            input.Enable();
        }
        
        public void OnMove(InputAction.CallbackContext context) {
            switch(context.phase)
            {
                case InputActionPhase.Performed:
                    Move?.Invoke(context.ReadValue<Vector2>());
                    break;
                case InputActionPhase.Canceled:
                    Move?.Invoke(Vector2.zero);
                    break;
                default:
                    Debug.Log("Not input handled");
                    break;
            }
            Move?.Invoke(context.ReadValue<Vector2>());
        }
        public void OnLook(InputAction.CallbackContext context) {

        }
        public void OnAttack(InputAction.CallbackContext context) {

        }
        public void OnInteract(InputAction.CallbackContext context) {

        }
        public void OnCrouch(InputAction.CallbackContext context) {

        }
        public void OnJump(InputAction.CallbackContext context) {

        }
        public void OnPrevious(InputAction.CallbackContext context) {

        }
        public void OnNext(InputAction.CallbackContext context) {

        }
        public void OnSprint(InputAction.CallbackContext context) {

        }
    }
}
