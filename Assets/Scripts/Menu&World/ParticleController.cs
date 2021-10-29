using UnityEngine;

namespace Menu_World
{
    public class ParticleController : MonoBehaviour
    {
        public ParticleSystem redNote;
        public ParticleSystem blueNote;
        public ParticleSystem greenNote;
        public ParticleSystem yellowNote;
        
        public ParticleSystem miss;
        public ParticleSystem bad;
        public ParticleSystem good;
        public ParticleSystem perfect;

        public void RedNoteParticle()
        {
            redNote.Play();
        }
        public void BlueNoteParticle()
        {
            blueNote.Play();
        }
        public void GreenNoteParticle()
        {
            greenNote.Play();
        }
        public void YellowNoteParticle()
        {
            yellowNote.Play();
        }
        
        public void MissParticle()
        {
            miss.Play();
        }
        public void BadParticle()
        {
            bad.Play();
        }
        public void GoodParticle()
        {
            good.Play();
        }
        public void PerfectParticle()
        {
            perfect.Play();
        }
    }
}
