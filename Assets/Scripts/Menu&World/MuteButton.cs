using UnityEngine;
using UnityEngine.UI;

namespace Menu_World
{
    public class MuteButton : MonoBehaviour
    {
        public bool isMuted;
        public Button muteButton;
        public Sprite muteSprite;
        public Sprite unMuteSprite;

        public void MutePress()
        {
            if (isMuted)
            {
                UnMute();
            }
            else
            {
                Mute();
            }
        }

        public void Mute()
        {
            muteButton.GetComponent<Image>().sprite = muteSprite;
            isMuted = true;
        }
        public void UnMute()
        {
            muteButton.GetComponent<Image>().sprite = unMuteSprite;
            isMuted = false;
        }
    }
}
