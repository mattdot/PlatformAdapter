using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace PlatformAdapter.WindowsStore
{
    internal sealed class BackgroundAudio : IBackgroundAudio, IDisposable
    {
        MediaElement mediaElement;
        CoreDispatcher dispatcher;

        public BackgroundAudio(MediaElement mediaElement)
        {
            this.mediaElement = mediaElement;
            this.dispatcher = mediaElement.Dispatcher;
            this.mediaElement.CurrentStateChanged += OnCurrentStateChanged;
            
        }

        void OnCurrentStateChanged(object sender, global::Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (null != this.PlayStateChanged)
            {
                this.PlayStateChanged(this, EventArgs.Empty);
            }
        }

        public bool CanSeek
        {
            get
            {
                return this.mediaElement.CanSeek;
            }
        }

        public double BufferingProgress
        {
            get
            {
                return this.mediaElement.BufferingProgress;
            }
        }

        public bool CanPause
        {
            get
            {
                return this.mediaElement.CanPause;
            }
        }

        public double Volume
        {
            get
            {
                return this.mediaElement.Volume;
            }
            set
            {
                this.dispatcher.RunAsync(CoreDispatcherPriority.Normal, new DispatchedHandler(() => {
                    this.mediaElement.Volume = value;
                })).AsTask().Wait();
            }
        }

        
        public IAudioTrack CreateAudioTrack()
        {
            
            return new BackgroundAudioTrack();
        }

        public bool CanChangeRate
        {
            get { return true; }
        }

        public Task PlayAsync()
        {
            return this.dispatcher.RunAsync(CoreDispatcherPriority.Normal, new DispatchedHandler(() =>
            {
                this.mediaElement.Play();
            })).AsTask();
        }

        public Task PauseAsync()
        {
            return this.dispatcher.RunAsync(CoreDispatcherPriority.Normal, new DispatchedHandler(() =>
            {
                this.mediaElement.Pause();
            })).AsTask();
        }



        public event EventHandler PlayStateChanged;

        public bool IsPlaying
        {
            get { return MediaControl.IsPlaying; }
        }

        public IAudioTrack CurrentTrack
        {
            get
            {
                return new BackgroundAudioTrack
                {
                    AlbumArt = MediaControl.AlbumArt,
                    Artist = MediaControl.ArtistName,
                    Title = MediaControl.TrackName,
                    Source = this.mediaElement.Source
                };
            }
            set
            {
                MediaControl.AlbumArt = value.AlbumArt;
                MediaControl.ArtistName = value.Artist;
                MediaControl.TrackName = value.Title;
                this.dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    this.mediaElement.Source = value.Source;
                }).AsTask().ConfigureAwait(false);
            }
        }

        void IDisposable.Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool isDisposing)
        {
            this.mediaElement.CurrentStateChanged -= OnCurrentStateChanged;

            if(isDisposing)
            {
                GC.SuppressFinalize(this);
            }
        }

        ~BackgroundAudio()
        {
            Dispose(false);
        }
    }

    internal sealed class BackgroundAudioTrack : IAudioTrack
    {
        public string Title { get; set; }
        public string Album { get; set; }
        public string Artist { get; set; }
        public Uri Source { get; set; }
        public Uri AlbumArt { get; set; }

        public TimeSpan Duration
        {
            get { return TimeSpan.Zero; }
        }
    }
}