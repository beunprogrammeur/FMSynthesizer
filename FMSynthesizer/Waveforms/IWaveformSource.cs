using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMSynthesizer.Waveforms
{
    internal interface IWaveformSource : ISampleSource
    {
        /// <summary>
        /// The offset of the starting point of the waveform
        /// </summary>
        float Phase { get; set;  }
        /// <summary>
        /// The amount of repetitions per second
        /// </summary>
        float Frequency { get; set; }
        /// <summary>
        /// The loudness of the waveform
        /// </summary>
        float Amplitude { get; set; }

    }
}
