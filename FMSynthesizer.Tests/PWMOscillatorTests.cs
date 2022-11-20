using FMSynthesizer.Waveforms;

namespace FMSynthesizer.Tests
{
    [TestClass]
    public class PWMOscillatorTests
    {
        [TestMethod]
        [DataRow(0.0f, 0.0f, 0.0f)]
        [DataRow(0.0f, 1.0f, 1.0f)]
        [DataRow(0.0f, 0.5f, 1.0f)]
        [DataRow(0.49f, 0.5f, 1.0f)]
        [DataRow(0.50f, 0.5f, 1.0f)]
        [DataRow(0.51f, 0.5f, -1.0f)]
        public void DutyCycleWorks(float seconds, float duty, float expected)
        {
            var time = new TimeInfo() { Time = seconds };
            var oscillator = new PWMOscillator(time) { DutyCycle = duty, Frequency = 1.0f };

            Assert.AreEqual(expected, oscillator.NextSample());
        }
    }
}