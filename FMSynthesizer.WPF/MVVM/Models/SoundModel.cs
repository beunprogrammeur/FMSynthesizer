using FMSynthesizer.WPF.Audio;
using FMSynthesizer.WPF.SampleSources;
using FMSynthesizer.WPF.Shared.Models;

namespace FMSynthesizer.WPF.MVVM.Models
{
    internal class SoundModel : BaseModel
    {
        private AudioPlayer _player;
        public ITime Time => _player.Time;
        public SoundModel(SynthesizerState state)
        {
            _player = AddDisposable(new AudioPlayer(state));
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
