using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PlatformAdapter
{
    /// <summary>
    /// we should use a real dependency injection framework/implementation or MEF.  This is a hack
    /// </summary>
    public class Platform
    {
        #region Static Implementation

        private static readonly Platform current = new Platform(new SimpleServiceLocator());
        
        public static Platform Current
        {
            get
            {
                return Platform.current;
            }
        }

        public static T Resolve<T>()
        {
            return Platform.current.locator.Resolve<T>();
        }

        public static IBackgroundAudio BackgroundAudio
        {
            get
            {
                if (null == Platform.current.backgroundAudio)
                {
                    Platform.current.backgroundAudio = Platform.Resolve<IBackgroundAudio>();
                }
                return Platform.current.backgroundAudio;
            }
        }

        #endregion

        private Platform(IServiceLocator locator)
        {
            this.Locator = locator;
        }

        private IBackgroundAudio backgroundAudio;
        private IServiceLocator locator;

        public IServiceLocator Locator
        {
            get
            {
                return this.locator;
            }
            set
            {
                if (null == value)
                {
                    throw new InvalidOperationException("Can't set the locator to null");
                }

                this.locator = value;
            }
        }

        
    }
}
