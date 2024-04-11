using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

namespace USM
{
    public class UISGOption : MonoBehaviour
    {
        private static UISGOption instance;

        public Toggle uiMusicToggle;
        public Toggle uiSoundToggle;
        public Image Dialog;
        public GameObject musicOnObject;
        public GameObject musicOffObject;
        public GameObject soundOnObject;
        public GameObject soundOffObject;

        void Awake()
        {
            instance = this;
            gameObject.SetActive(false);
        }

        void Start()
        {
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Hide();
            }
        }

        void OnEnable()
        {
            uiMusicToggle.isOn = (BESetting.MusicVolume != 0) ? false : true;
            uiSoundToggle.isOn = (BESetting.SoundVolume != 0) ? false : true;
        }

        public void MusicToggled(bool value)
        {
            BEAudioManager.SoundPlay(0);
            Debug.Log("Music is " + (value ? "ON" : "OFF"));
            BESetting.MusicVolume = value ? 0 : 100;
            BESetting.Save();

            if (value)
            {
                BEAudioManager.MusicStop();
                musicOnObject.SetActive(false);
                musicOffObject.SetActive(true);
            }
            else
            {
                if (!BEAudioManager.MusicIsPlaying())
                    BEAudioManager.MusicPlay();
                musicOnObject.SetActive(true);
                musicOffObject.SetActive(false);
            }
        }

        public void SoundToggled(bool value)
        {
            BEAudioManager.SoundPlay(0);
            Debug.Log("Sound is " + (value ? "ON" : "OFF"));
            BESetting.SoundVolume = value ? 0 : 100;
            BESetting.Save();

            if (value)
            {
                soundOnObject.SetActive(false);
                soundOffObject.SetActive(true);
            }
            else
            {
                soundOnObject.SetActive(true);
                soundOffObject.SetActive(false);
            }
        }

        public void OnButtonMenu()
        {
            BEAudioManager.SoundPlay(0);
            SceneManager.LoadScene(0);
        }

        public void OnButtonContinue()
        {
            BEAudioManager.SoundPlay(0);
            //Hide();
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            SceneSlotGame.uiState = 0;
        }

        void _Show()
        {
            gameObject.transform.localPosition = Vector3.zero;
            gameObject.SetActive(true);
            SceneSlotGame.uiState = 1;
            StartCoroutine(BEUtil.instance.ImageScale(Dialog, Dialog.color, 1.0f, 1.1f, 1.0f, 0.1f, 0.0f));
        }

        public static void Show() { instance._Show(); }
    }
}
