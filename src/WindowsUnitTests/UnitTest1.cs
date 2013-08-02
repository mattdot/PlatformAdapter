using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using PlatformAdapter;
using Windows.UI.Xaml.Controls;

namespace WindowsUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            
            MediaElement me = new MediaElement();
            Platform.Current.Initialize();
            Platform.Current.Configure<IBackgroundAudio>(me);

            Assert.IsFalse( Platform.BackgroundAudio.IsPlaying);

            var track = Platform.BackgroundAudio.CreateAudioTrack();
            track.Source = new Uri("http://pd.npr.org/anon.npr-mp3/npr/blog/2012/07/20120713_blog_pmoney.mp3?dl=1");

            Platform.BackgroundAudio.CurrentTrack = track;
        }
    }
}
