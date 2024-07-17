using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameManagement.Runtime
{
    public class GameManager : MonoBehaviour
    {
        #region Unity Api

        private void Update()
        {
            if(_audioReceiver.Count > 0)
            {
                _currentVictoryReceiver = 0;
                foreach (GameObject audioItem in _audioReceiver)
                {
                    AudioSource audioComponent = audioItem.GetComponent<AudioSource>();
                    if (audioComponent.volume >= 0.92f)
                    {
                        _currentVictoryReceiver += 1;
                    }

                }
                if (_currentVictoryReceiver == _audioReceiver.Count)
                {
                    SceneManager.LoadScene(_victoryNextScene);
                }
            }
           
        }

        #endregion


        #region Utils

        #endregion

        #region Main Methods
        public void LoadSceneManager(int sceneNumber)
        {
            SceneManager.LoadScene(sceneNumber);
        }
        public void QuitApplication()
        {
            Application.Quit();
        }
        #endregion

        #region Private & Protected

        int _currentVictoryReceiver = 0;
        [SerializeField] List<GameObject> _audioReceiver = new List<GameObject>();
        [SerializeField] int _victoryNextScene;
        #endregion
    }
}
