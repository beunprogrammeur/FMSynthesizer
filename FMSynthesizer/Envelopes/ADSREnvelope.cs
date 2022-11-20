namespace FMSynthesizer.Envelopes
{
    public class ADSREnvelope : Envelope
    {
        private float _releasedTime;
        private bool _released;
        private bool _triggered;
        public float Attack   { get; set; }
        public float Decay    { get; set; }
        public float Sustain { get; set; }
        public float Release  { get; set; }
        public bool Released { get => _released; set { _released = value; if (value) { _releasedTime = Time.Time; } } }

        public event EventHandler? EnvelopeEnded;

        public ADSREnvelope(ITime time) : base(time)
        {
        }

        public override float NextSample()
        {
            if (!Released && Time.Time > Attack + Attack + Decay) Released = true; // temp
            if(Time.Time < Attack)                      return 1.0f / Attack * Time.Time;
            if(Time.Time < Attack + Decay)              return 1.0f - (Sustain / Decay * (Time.Time - Attack));
            if(Time.Time > Attack + Decay && !Released) return Sustain;

            float output = Sustain - (Sustain / Release * (Time.Time - _releasedTime));
            
            if (output < 0)
            {
                if(!_triggered) OnEnvelopeEnded();
                return 0;
            }

            return output;
        }

        private void OnEnvelopeEnded()
        {
            EnvelopeEnded?.Invoke(this, EventArgs.Empty);
        }
    }
}
