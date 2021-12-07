using UnityEngine;

namespace Laskka.Tools.PopMessage.Scripts
{
    public class PopMessage : MonoBehaviour, IPopMessage
    {
        [SerializeField] private AnimationCurve _movingCurve;
        [SerializeField] private AnimationCurve _fadeCurve;
        [SerializeField, Range(0, 5f)] private float duration = 1f;
        [SerializeField] private float _distance = 10;

    
        private float _time = 0;
        private Vector3 _dir;

        private IText _text; 
    
        public void Init()
        {
            _text = new Text(this);
            gameObject.SetActive(false);
        }

        public void ToPool()
        {
            _time = 0;
            gameObject.SetActive(false);
        }

        public void Used(string text)
        {
            _time = 0;
            _text.WriteText(text);
            gameObject.SetActive(true);
        }

        public bool Move()
        {
            if (_time >= 1)
                return false;
            _text.Fade(_fadeCurve.Evaluate(_time));
            _dir.y = _movingCurve.Evaluate(_time) * _distance;
            _time += Time.deltaTime / duration;
            transform.localPosition = _dir;

            return true;
        }
    }
}