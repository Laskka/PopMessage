using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Laskka.Tools.PopMessage.Scripts
{
    public class PopMessageManager : MonoBehaviour
    {
        [SerializeField] private int _pool = 5;
        [SerializeField] private global::Laskka.Tools.PopMessage.Scripts.PopMessage _prefab;
    
        [Space] [SerializeField] private bool _doDontDestroyOnLoad = false;
    
        private List<IPopMessage> _pools;
        private List<IPopMessage> _useingPools = new List<IPopMessage>(5);
        private bool _doAnimating = false;

        private IPopMessage _itemCash;

        private void Awake()
        {
            if (_prefab == null)
                throw new NotImplementedException("Don't set Prefab in PopMessageManager");
            
            _pools = new List<IPopMessage>();
            for (int i = 0; i < _pool; i++)
            {
                InitItem();
            }

            if (_doDontDestroyOnLoad)
            {
                DontDestroyOnLoad(gameObject);
            }
        }
        
        public void ShowMassage(string text)
        {
            if (_pools.Count <= 0)
            {
                InitItem();
                ShowMassage(text);
            }
            else
            {
                _pools.FirstOrDefault().Used(text);
                _useingPools.Add(_pools.FirstOrDefault());
                _pools.Remove(_pools.FirstOrDefault());
            
                if (_doAnimating == false)
                {
                    StartCoroutine(AnimTicker());
                }
            }
        }
        
        private void InitItem()
        {
            _pools.Add(CreateItem());
            _pools.Last().Init();
        }

        private IPopMessage CreateItem()
        {
            return Instantiate(_prefab, Vector3.zero, Quaternion.identity, transform);
        }


        IEnumerator AnimTicker()
        {
            _doAnimating = true;
            while (_useingPools.Count != 0)
            {
                for (int i = 0; i < _useingPools.Count; i++)
                {
                    if (_useingPools[i].Move() == false)
                    {
                        _useingPools[i].ToPool();
                        _pools.Add(_useingPools[i]);
                        _useingPools.Remove(_useingPools[i]);
                        i--;
                    }
                }
                yield return new WaitForEndOfFrame();
            }

            _doAnimating = false;
        }
    }
}

