using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using System.Linq;
using System;
using System.Threading;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WaveformVisualizer.MVVM.Utilities;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;

namespace WaveformVisualizer.MVVM.ViewModels
{
    internal class ChartViewModel : ViewModelBase
    {
        private ObservableCollection<float> _synthSeries;
        public ISeries[] Series { get; set; }
        public Axis[][] Axes { get; }

        public ICommand ReloadCommand { get; }

        public ChartViewModel()
        {
            _synthSeries = new ObservableCollection<float>();
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
                        UnitWidth = TimeSpan.FromSeconds(1.0f / 100).Ticks
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
                        MaxLimit = 1.0f,
                        MinLimit = -1.0f
                    }
                }
            };

            Series = new ISeries[]
            {
                new LineSeries<float>
                {
                    Values = _synthSeries,
                    Fill = null,
                    IsHoverable = false,
                    GeometrySize = 0,
                    GeometryFill = null,
                    GeometryStroke = null,
                    Stroke = new SolidColorPaint(SKColors.DarkBlue, 0.5f)
                }      
            };

            ReloadCommand = new RelayCommand(ReloadSeries);
        }

        private void ReloadSeries()
        {
            // TODO: query the synth, post the results in the series

            _synthSeries.Clear();

            float frequency   = 440.0f;
            float sample_rate = 44100.0f;
            float total_time  = 0.1f;
            float wave_length = 1.0f / frequency;
            float dt   = 1.0f / sample_rate;
            float time = 0;
            
            float duty_cycle = 0.25f;

            float amplitude = 0.2f;
            while ((time += dt) < total_time)
            {
                float num_waves = time / wave_length;
                float excess = num_waves - (float)Math.Truncate(num_waves);
                _synthSeries.Add(amplitude * (excess > 0.25f ? 1.0f : -1.0f));
            }
        }
    }
}

