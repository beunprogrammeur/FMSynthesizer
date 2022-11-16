using FMSynthesizer.WPF.Audio;
using FMSynthesizer.WPF.Shared.Models;

namespace FMSynthesizer.WPF.MVVM.Models
{
    internal class SoundModel : BaseModel
    {
        private AudioPlayer _player;
        public SoundModel(ISampleSource source)
        {
            _player = AddDisposable(new AudioPlayer(source));
        }

        public void Start()
        {
            _player.Play();
        }

        public void Stop()
        {
            _player.Stop();
        }
    }
}
