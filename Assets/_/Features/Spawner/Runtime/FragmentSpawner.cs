using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FragmentSpawner.Runtime
{
    public class FragmentSpawner : MonoBehaviour
    {
        #region Publics
        #endregion


        #region Unity API
        private void Awake()
        {
            InitPoolFragment();
            StartCoroutine("FragmentSpawnerCoroutine");
        }
        private void Update()
        {

        }
        #endregion


        #region Main Methods

        #endregion


        #region Utils

        private void InitPoolFragment()
        {
            for(int i = 0; i< _fragmentsCount; i++)
            {
                GameObject fragment = Instantiate(_fragment);
                fragment.name = _fragment.name;
                fragment.transform.parent = _poolContainer;
                fragment.transform.position = _poolContainer.position;
                fragment.SetActive(false);
                _fragments.Add(fragment);
            }
        }
        private GameObject GetAvalaibleFragment()
        {
            if(_fragments.Count > 0)
            {
                return _fragments[0];
            }
            else
            {
                InitPoolFragment();
                return GetAvalaibleFragment();
            }
                
        }
        IEnumerator FragmentSpawnerCoroutine()
        {
            while (true)
            {
                GameObject fragment = GetAvalaibleFragment();
                fragment.SetActive(true);
                _fragments.Remove(fragment);
                fragment?.GetComponent<Rigidbody2D>().AddForce(Vector2.left * _fragmentVelocity, ForceMode2D.Impulse);
                yield return new WaitForSeconds(_fragmentSpawnDelay);
            }
        }
        
        #endregion


        #region Private & Protected

        [SerializeField] GameObject _fragment;
        [SerializeField] Transform _poolContainer;
        [SerializeField] float _fragmentVelocity;
        [SerializeField] float _fragmentSpawnDelay;
        List<GameObject> _fragments = new List<GameObject>();
        int _fragmentsCount = 500;

        #endregion
    }
}

