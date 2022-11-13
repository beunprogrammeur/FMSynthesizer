namespace FMSynthesizer.Envelopes
{
    internal class ASDREnvelope : IEnvelope
    {
        public float Attack   { get; set; }
        public float Decay    { get; set; }
        public float Sustaion { get; set; }
        public float Release  { get; set; }

        public float NextSample(float dt)
        {
            throw new NotImplementedException();
        }
    }
}
