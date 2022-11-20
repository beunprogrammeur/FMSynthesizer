using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using System;
using System.Threading;
using System.Collections.ObjectModel;
using System.Windows.Input;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using FMSynthesizer.Waveforms;
using LiveChartsCore.Defaults;
using FMSynthesizer.Envelopes;
using FMSynthesizer.WPF.Shared.ViewModels;
using FMSynthesizer;

namespace WaveformVisualizer.MVVM.ViewModels
{
    internal class ChartViewModel : BaseViewModel
    {
        private ObservableCollection<ObservableValue> _synthSeries;
        private Timer _timer;
        private TimeInfo _time;
        SineOscillator _sine; 
        ADSREnvelope _env;    

        private const float _sampleRate = 22500.0f;
        public ISeries[] Series { get; set; }
        public Axis[][] Axes { get; }

        public ICommand ReloadCommand { get; }

        public ChartViewModel()
        {
            _synthSeries = new ObservableCollection<ObservableValue>();
            for(int i = 0; i < _sampleRate / 2; i++)
            {
                _synthSeries.Add(new ObservableValue(0));
            }

            _time = new TimeInfo();
            _sine = new SineOscillator(_time);
            _env  = new ADSREnvelope(_time);


            LiveCharts.Configure(config =>
            config.AddSkiaSharp()
            .AddDefaultMappers()
            .AddLightTheme());

            Axes = new Axis[][]
            {
                // X
                new Axis[]
                {
                    new Axis()
                    {
                        Name = "Time (ms)",
                        NamePaint = new SolidColorPaint(SKColors.Blue),
                        TextSize = 20,
                        UnitWidth = TimeSpan.FromSeconds(1.0f / _sampleRate).Ticks
                    }
                },

                // Y
                new Axis[]
                {
                    new Axis()
                    {
                        Name = "Amplitude",
                        NamePaint = new SolidColorPaint(SKColors.Blue),
                        TextSize = 20,
                        MaxLimit = 1.1f,
                        MinLimit = -1.1f
                    }
                }
            };

            Series = new ISeries[]
            {
                new LineSeries<ObservableValue>
                {
                    Values = _synthSeries,
                    Fill = null,
                    IsHoverable = false,
                    GeometrySize = 0,
                    GeometryFill = null,
                    GeometryStroke = null,
                    Stroke = new SolidColorPaint(SKColors.DarkBlue, 0.5f),
                    AnimationsSpeed = TimeSpan.FromMilliseconds(0.1),
                }      
            };

            const float dt = 1.0f / _sampleRate;
            int j = 0;

            _timer = new Timer((obj) =>
            {
                for(int k = 0; k < _synthSeries.Count / 100; k++)
                {
                    j = (j + 1) % (_synthSeries.Count - 1);
                    _time.Time += dt;
                    _synthSeries[j].Value = NextSample();
                }
            }, null, 1500, 1);



            _sine.Frequency = 440.0f;
            _env.Attack  = 0.1f;
            _env.Decay   = 0.1f;
            _env.Sustain = 0.5f;
            _env.Release = 0.2f;
        }

        private float NextSample()
        {
             return _sine.NextSample() * _env.NextSample();
        }
    }
}

