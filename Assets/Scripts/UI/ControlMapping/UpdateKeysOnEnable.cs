using UnityEngine;

namespace Game.UI
{
    public class UpdateKeysOnEnable : MonoBehaviour
    {
        [SerializeField]
        private ChangeAssociatedKey changeKeyScript;

        private void OnEnable()
        {
            changeKeyScript.UpdateButtonText();
        }
    }
}