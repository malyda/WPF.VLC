using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace WPF.VLC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var currentAssembly = Assembly.GetEntryAssembly();
            var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;
            // Default installation path of VideoLAN.LibVLC.Windows
            var libDirectory = new DirectoryInfo(Path.Combine(currentDirectory, "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));
            vlcPlayer.MediaPlayer.VlcLibDirectory = libDirectory;
            vlcPlayer.MediaPlayer.EndInit();
            vlcPlayer.MediaPlayer.Play(new Uri("http://download.blender.org/peach/" +
                "bigbuckbunny_movies/big_buck_bunny_480p_surround-fix.avi"));
        }

        private void PlayStopButton_Click(object sender, RoutedEventArgs e)
        {
            if (vlcPlayer.MediaPlayer.IsPlaying)
            {
                vlcPlayer.MediaPlayer.Pause();
                PlayStopButton.Content = "Play";
            }
            else
            {
                vlcPlayer.MediaPlayer.Play();
                PlayStopButton.Content = "Pause";
            }
        }

        private void Next5Secs_Click(object sender, RoutedEventArgs e)
        {
            vlcPlayer.MediaPlayer.Time += 5000;
        }
    }
}
