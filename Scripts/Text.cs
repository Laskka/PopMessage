//#define POP_MESSAGE_TMPRO

using System;
using TMPro;
using UnityEngine;
#if POP_MESSAGE_TMPRO
#endif

namespace Laskka.Tools.PopMessage.Scripts
{
    public class Text : IText
    {
#if POP_MESSAGE_TMPRO
        private TextMeshProUGUI _textTMP;
#endif
        private UnityEngine.UI.Text _text;

        private Color _color;
        public Text(global::Laskka.Tools.PopMessage.Scripts.PopMessage popMessage)
        {
#if POP_MESSAGE_TMPRO
            if (popMessage.gameObject.TryGetComponent(out _textTMP))
            {
                _color = _textTMP.color;
            }
            else
#endif
            if (popMessage.gameObject.TryGetComponent(out _text))
            {
                _color = _text.color;
            }
            else
            {
                throw new NotImplementedException("A text component don't be found");
            }
        }

        public void WriteText(string text)
        {
#if POP_MESSAGE_TMPRO
            if (_textTMP != null)
            {
                _textTMP.text = text;
            }
            else 
#endif
            if (_text != null)
            {
                _text.text = text;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public void Fade(float alpha)
        {
            _color.a = alpha;
#if POP_MESSAGE_TMPRO
            if (_textTMP != null)
            {
                _textTMP.color = _color;
            }
            else
#endif
            if (_text != null)
            {
                _text.color = _color;
            }
            else
            {
                throw new NullReferenceException();
            }
        }
    }
}