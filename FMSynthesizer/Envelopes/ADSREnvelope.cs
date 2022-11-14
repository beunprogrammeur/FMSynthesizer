namespace FMSynthesizer.Envelopes
{
    internal class ADSREnvelope : Envelope
    {
        private float _releasedTime;
        private bool _released;
        private bool _triggered;
        public float Attack   { get; set; }
        public float Decay    { get; set; }
        public float Sustain { get; set; }
        public float Release  { get; set; }
        public bool Released { get => _released; set { _released = value; if (value) { _releasedTime = Time; } } }

        public event EventHandler? EnvelopeEnded;

        protected override float CalculateAmplitude()
        {
            if (!Released && Time > Attack + Attack + Decay) Released = true; // temp
            if(Time < Attack)
            {
                return 1.0f / Attack * Time;
            }

            if(Time < Attack + Decay)
            {
                return 1.0f - (Sustain / Decay * (Time - Attack));
            }

            if(Time > Attack + Decay && !Released)
            {
                return Sustain;
            }

            float output = Sustain - (Sustain / Release * (Time - _releasedTime));
            if (output < 0)
            {
                if(!_triggered)
                {
                    OnEnvelopeEnded();
                }

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
