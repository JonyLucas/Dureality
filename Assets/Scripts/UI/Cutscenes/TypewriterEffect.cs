using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.Cutscene
{
    public class TypewriterEffect : MonoBehaviour
    {
        [SerializeField]
        private float _typeSpeed = 50f;

        private bool _isTyping = false;

        public bool IsTyping
        { get { return _isTyping; } }

        public void Run(string textToType, Text textLabel)
        {
            if (!_isTyping)
            {
                textLabel.text = "";
                StartCoroutine(TypeText(textToType, textLabel));
            }
            else
            {
                StopWriting();
            }
        }

        public void StopWriting()
        {
            _isTyping = false;
        }

        private IEnumerator TypeText(string textToType, Text textLabel)
        {
            int charIndex = 0;
            var strBuilder = new StringBuilder();
            _isTyping = true;

            while (charIndex < textToType.Length && _isTyping)
            {
                strBuilder.Append(textToType[charIndex]);
                charIndex++;
                textLabel.text = strBuilder.ToString();

                yield return new WaitForSeconds(_typeSpeed);
            }

            textLabel.text = textToType;
            _isTyping = false;
        }
    }
}