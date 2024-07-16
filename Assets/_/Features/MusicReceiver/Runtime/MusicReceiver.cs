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
        private void Update()
        {
            if(Time.time - _timeOfLastFragmentReceive > _timeAfterBeginingToDecrease)
            {
                if(Time.time - _timeSinceLastDecrease > _timeBetweenDecrease)
                {
                    _audioSource.volume -= 0.02f;
                    _timeSinceLastDecrease = Time.time;
                }
            }
        }

        #endregion


        #region Utils

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision != null) 
            {
                _countFragment++;
                if(_countFragment%75 == 0) _audioSource.volume += 0.05f;
                _timeOfLastFragmentReceive = Time.time;
            }
        }

        #endregion


        #region Private & Protected

        [SerializeField] float _volume = 0f;
        int _countFragment = 0;
        AudioSource _audioSource;
        float _timeAfterBeginingToDecrease = 0.5f;
        float _timeOfLastFragmentReceive;
        float _timeSinceLastDecrease;
        float _timeBetweenDecrease = 0.1f;

        #endregion
    }
}
