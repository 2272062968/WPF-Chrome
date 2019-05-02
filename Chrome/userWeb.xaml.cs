using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Chrome
{
    /// <summary>
    /// userWeb.xaml 的交互逻辑
    /// </summary>
    public partial class userWeb : UserControl
    {
        #region 初始化变量
        //网页链接、标题
        public static string urlN;
        public static string WebTitle = "";
        //传递参数到主窗口，UIL和标题
        public static EventHandler Changed;
        public static EventHandler ChangedTitle;
        #endregion

        public userWeb()
        {
            InitializeComponent();
            border.Width = Width;
        }

        //前进
        private void ForwardButton_Click(object sender, RoutedEventArgs e)
        {
            try { web.GoForward(); }
            catch (System.Runtime.InteropServices.COMException) { }
        }
       
        //后退
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            try { web.GoBack(); }
            catch (System.Runtime.InteropServices.COMException) { }

        }
        
        //刷新
        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            web.Refresh();
        }

        //添加收藏夹
        private void Btn_shoucang(object sender, RoutedEventArgs e)
        {
            try
            {
                string title = ((dynamic)web.Document).Title;
                var w = Window.GetWindow(btn_shoucang);
                if (!MainWindow.btnTitle.Contains(title))
                {
                    Button button = new Button();

                    button.Content = title;
                    button.Height = 26;
                    button.Width = 100;

                    button.Margin = MainWindow.thick;

                    button.Background = (System.Windows.Media.Brush)MainWindow.myBrush;

                    //button.Background = null;
                    button.BorderBrush = null;
                    button.Click += Btn_ShouCang;

                    MainWindow.btnTitle.Add(title);
                    MainWindow.btnUrl.Add(Url.Text);
                    shoucang.Children.Add(button);

                    //MessageBox.Show(btnUrl[0] + btnTitle[0]);
                }
            }
            catch (System.NotSupportedException)
            {
                MessageBox.Show("很抱歉，未获取到当前网页标题，请尝试刷新网页;等待网页加载完成后再尝试此操作");
            }
            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException)
            {
                MessageBox.Show("很抱歉，未获取到当前网页标题，请尝试刷新网页;等待网页加载完成后再尝试此操作");
            }
        }
        
        //给添加的收藏按钮加跳转事件
        private void Btn_ShouCang(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int idx = MainWindow.btnTitle.FindIndex(x => x == button.Content.ToString());
            if (idx != -1)
            {
                string szTmp = MainWindow.btnUrl[idx];
                Uri uri = new Uri(szTmp);
                web.Navigate(uri);
            }
        }

        //网页加载完成时通知主窗口修改标题
        private void Web_LoadCompleted(object sender, NavigationEventArgs e)
        {
            WebTitle = ((dynamic)web.Document).Title;
            ChangedTitle?.Invoke(this, new EventArgs()); //通知主窗口更改数据
        }

        //通知主窗口修改链接
        private void BrowserControl_Navigated(object sender, NavigationEventArgs e)
        {
            urlN = web.Source.ToString();
            Url.Text = urlN;
            Changed?. Invoke(this, new EventArgs());
        }

        private void Url_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                var url = Url.Text;
                try
                {
                    web.Navigate(url);
                }
                catch (System.UriFormatException)
                {

                }
            }
        }

    }
}
