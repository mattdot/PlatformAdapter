using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using PlatformAdapter.Phone7;
using System.Reflection;

namespace TestAppPhone7
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var dt = await AppInfo.RetrieveLinkerTimestampAsync(typeof(MainPage).Assembly);

            this.ContentPanel.Children.Add(new TextBlock() { Text = dt.ToString() });
        }
    }
}