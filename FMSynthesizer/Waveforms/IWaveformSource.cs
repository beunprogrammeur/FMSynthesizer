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
    }
}
