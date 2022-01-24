using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game.UI.Cutscene
{
    public class CutsceneBehaviour : MonoBehaviour
    {
        [SerializeField]
        private CutsceneFrame _cutsceneFrame;

        private List<Frame> _frames;
        private Frame _currentFrame;

        [SerializeField]
        private Image _uiImage;

        [SerializeField]
        private GameObject _nextButton;

        [SerializeField]
        private GameObject _textObject;

        [SerializeField]
        private string _nextSceneName;

        private Text _textComponent;
        private TypewriterEffect _typewriter;

        private void Start()
        {
            _frames = _cutsceneFrame.Frames;
            _currentFrame = _frames.FirstOrDefault();
            _textComponent = _textObject.GetComponent<Text>();
            _textComponent.text = "";
            _typewriter = GetComponent<TypewriterEffect>();
            _nextButton.SetActive(true);

            UpdateFrame();
        }

        public void NextFrame()
        {
            if (!_typewriter.IsTyping)
            {
                var index = _frames.IndexOf(_currentFrame);
                if (index < _frames.Count - 1)
                {
                    _currentFrame = _frames[index + 1];
                }
                else
                {
                    if (!string.IsNullOrEmpty(_nextSceneName))
                    {
                        SceneManager.LoadScene(_nextSceneName);
                    }
                    else
                    {
                        _nextButton.SetActive(false);
                    }
                }
            }
            UpdateFrame();
        }

        private void UpdateFrame()
        {
            _typewriter.Run(_currentFrame.Text, _textComponent);
            _uiImage.sprite = _currentFrame.Image;
        }
    }
}