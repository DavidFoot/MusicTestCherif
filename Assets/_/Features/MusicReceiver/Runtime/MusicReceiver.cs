using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MusicReceiver.Runtime
{
    public class MusicReceiver : MonoBehaviour
    {
        #region Publics
        #endregion


        #region Unity Api

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _timeSinceLastDecrease = Time.time;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision != null)
            {
                _countFragment++;
                if (_countFragment % 5 == 0) _audioSource.volume += 0.1f;
                _timeOfLastFragmentReceive = Time.time;
            }
        }
        private void Update()
        {
            if(Time.time - _timeOfLastFragmentReceive > _timeAfterBeginingToDecrease)
            {
                if(Time.time - _timeSinceLastDecrease > _timeBetweenDecrease)
                {
                    _audioSource.volume -= 0.01f;
                    _timeSinceLastDecrease = Time.time;
                }
            }
            DisplayGradiation();

        }

        #endregion


        #region Utils

        public void DisplayGradiation()
        {
            if (_audioSource.volume > 0.75f)
            {
                ShowGradient(3);
            }
            else if(_audioSource.volume > 0.5f) {
                ShowGradient(2);
            }
            else if( _audioSource.volume > 0.25) {
                ShowGradient(1);
            }
            else if (_audioSource.volume > 0)
            {
                ShowGradient(0);
            }
            else
            {
                ShowGradient(-1);
            }
        }
        public void ShowGradient( int grade)
        {
            for(int i =0; i < _fillAmount.Length; i++)
            {
                if(i <= grade)
                    _fillAmount[i].SetActive(true);
                else
                {
                    _fillAmount[i].SetActive(false);
                }
            }
        }
        #endregion


        #region Private & Protected

        [SerializeField] GameObject[] _fillAmount = new GameObject[4];
        int _countFragment = 0;
        AudioSource _audioSource;
        float _timeAfterBeginingToDecrease = 0.5f;
        float _timeOfLastFragmentReceive;
        float _timeSinceLastDecrease;
        float _timeBetweenDecrease = 0.1f;

        #endregion
    }
}
