using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace Chrome
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        #region 初始化变量
        //添加收藏的url,标题,按钮间距,背景色
        public static List<string> btnUrl = new List<string>();
        public static List<string> btnTitle = new List<string>();
        public static Thickness thick = new Thickness(1, 0, 1, 0);
        public static SolidColorBrush myBrush = new SolidColorBrush(System.Windows.Media.Color.FromArgb(0xFF, 250, 250, 250));
        //添加标签页按钮内间距
        Thickness thickAdd = new Thickness(0, 0, 0, 0);
        //当前窗口是否为最大化
        private bool isMaxWindow = false;
        //标签页数量
        public static double itemLen = 1;
        double ItemLenName = 1;
        //标签是否被沾满
        Boolean itemsIsLong = false;
        //判断要关闭的标签序号
        string idxThis = "0";
        //判断当前选择的TabItem序号
        public static int ThisShowLabN = 0;
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            start();
            //添加参数改变时的触发事件
            userWeb.Changed += new EventHandler(userControl_Changed);
            userWeb.ChangedTitle += new EventHandler(userControl_ChangedTitle);   
        }

        //窗口打开时添加按钮(添加标签页的按钮)
        private void start()
        {
            tbcTitle.Width = Width;
            web.Width = this.Width;
            web.Height = this.Height - 110;
            border.Width = Width;
            Button button = new Button();
            button.Width = 26;
            button.Height = 26;
            button.Content = "+";
            button.Click += Button_Add;
            button.Name = "btnAdd";
            TabItem tci = new TabItem();
            tci.Name = "tbmAdd";
            tci.Padding = thickAdd;
            tci.Header = button;
            tbcTitle.Items.Add(tci);
            tbcTitle.RegisterName("tbmAdd", tci);

        }
        
        //鼠标移动窗口
        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            Point pp = e.GetPosition(this);
            if (pp.Y<30)
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    this.DragMove();
                }
            }
        }
       
        //双击顶部最大化
        private void Window_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Point pp = e.GetPosition(this);
            if (100 * (itemLen + 1) + 90 > Width)
            {
                if (pp.Y < 30 && pp.X > Width - 200 + 26)
                {
                    MaxWindow();
                }
            }
            else
            {
                if (pp.Y < 30 && pp.X > 100 * itemLen + 26)
                {
                    MaxWindow();
                }
            }
            tbcTitle.Width = Width;
            web.Width = this.Width;
            web.Height = this.Height - 110;
            border.Width = Width;
        }
        
        //最大化函数
        void MaxWindow()
        {
            if (isMaxWindow)
            {
                WindowState = WindowState.Normal;
                isMaxWindow = false;
            }
            else
            {
                WindowState = WindowState.Maximized;
                isMaxWindow = true;
            }
        }

        //添加标签页
        private void Button_Add(object sender, RoutedEventArgs e)
        {
            #region 先删除添加标签的按钮  
            TabItem tab = tbcTitle.FindName("tbmAdd") as TabItem;
            if (tab != null)
            {
                tbcTitle.Items.Remove(tab);
                tbcTitle.UnregisterName("tbmAdd");
            }
            #endregion

            #region 定义要在TabItem的Header中中添加的Grid
            Grid grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition());
            ColumnDefinition co1 = new ColumnDefinition();    //实例化一个Grid列
            ColumnDefinition co2 = new ColumnDefinition();
            co2.Width = new System.Windows.GridLength(26);
            grid.ColumnDefinitions.Add(co1);
            grid.ColumnDefinitions.Add(co2);
            Label label = new Label();
            label.Name = "lab" + ItemLenName.ToString();
            label.Content = "微软 Bing 搜索";
            Button buttonClose = new Button();
            buttonClose.Content = "x";
            buttonClose.Width = 20;
            buttonClose.Height = 20;
            buttonClose.BorderBrush = null;
            buttonClose.Background = null;
            buttonClose.Click += Btn_DeleteItem;
            buttonClose.Name = "btnCloseItem" + "_" + ItemLenName.ToString();
            grid.Children.Add(label);
            grid.Children.Add(buttonClose);
            Grid.SetColumn(label, 0);
            Grid.SetColumn(buttonClose, 1);
            //注册名字，以便以后同步标题使用
            tbcTitle.RegisterName("lab" + ItemLenName.ToString(), label);
            #endregion

            #region 将自定义的TabItem内容加入TabItem并加入Tabcontrol        
            TabItem tabItem = new TabItem();
            tabItem.Header = grid;
            tabItem.Width = 100;
            tabItem.Name = "tbm_" + ItemLenName.ToString();
            userWeb userWeb = new userWeb();
            userWeb.Height = Height;
            tabItem.Content = userWeb;
            tbcTitle.Items.Add(tabItem);
            #endregion

            tabItem.IsSelected = true;

            #region 定义添加标签的按钮 
            Button button = new Button();
            button.Width = 26;
            button.Height = 26;
            button.Content = "+";
            button.Click += Button_Add;
            button.Name = "btnAdd";
            #endregion

            #region 将添加按钮加入新的TabItem
            TabItem tci = new TabItem();
            tci.Name = "tbmAdd" + ItemLenName.ToString();
            tci.Padding = thickAdd;
            tci.Header = button;
            tbcTitle.Items.Add(tci);
            tbcTitle.RegisterName("tbmAdd", tci);
            ItemLenName++;
            itemLen++;
            #endregion

            //当标签页沾满时评分TabItem宽度
            if (100 * (itemLen + 1) + 90 > Width)
            {
                AvgItem();
                itemsIsLong = true;
            }
        }

        //usercontrol URL同步
        private void userControl_Changed(object sender, EventArgs e)
        {
            Label label = (Label)this.FindName("lab" + ThisShowLabN.ToString());
            label.Content = userWeb.urlN;

        }
        //usercontrol 网页加载完成后标题同步
        private void userControl_ChangedTitle(object sender, EventArgs e)
        {
            Label label = (Label)this.FindName("lab" + ThisShowLabN.ToString());
            label.Content = userWeb.WebTitle;
        }

        //平均分配每个tabitem
        private void AvgItem()
        {
            double i = 1;
            var temp = tbcTitle.Items;
            foreach (TabItem item in temp)
            {
                if (i == itemLen + 1)
                {
                    break;
                }
                double itemWidth = (this.Width - 200) / itemLen;
                if (itemWidth>100)
                {
                    item.Width = 100;
                }
                else
                {
                    item.Width = (this.Width - 200) / itemLen;
                }          
                i++;
            }
        }
        
        //关闭
        private void Btn_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //最大化
        private void Btn_MaxWindow(object sender, RoutedEventArgs e)
        {
            if (isMaxWindow)
            {
                WindowState = WindowState.Normal;
                isMaxWindow = false;
            }
            else
            {
                WindowState = WindowState.Maximized;
                isMaxWindow = true;
            }
            tbcTitle.Width = Width;
            web.Width = this.Width;
            web.Height = this.Height - 110;

            border.Width = Width;
            if (itemsIsLong)
            {
                AvgItem();
            }    
        }
        
        //最小化
        private void Btn_MinWindow(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;

        }

        //网页加载完成时同步标题
        private void Web_LoadCompleted(object sender, NavigationEventArgs e)
        {
            string title = ((dynamic)web.Document).Title;
            if (title.Length > 0)
            {
                ((Label)this.FindName("lab" + ThisShowLabN.ToString())).Content = title;
                title = "";
            }
        }
        //保持网址栏和当前网页同步
        private void BrowserControl_Navigated(object sender, NavigationEventArgs e)
        {
            string url = web.Source.ToString();
            Url.Text = url;
            ((Label)this.FindName("lab"+ThisShowLabN.ToString())).Content = url;
        }

        //窗口大小改变时调整控件大小
        private void Window_MouseLeave(object sender, MouseEventArgs e)
        {
            //当点击最小化按钮时也执行Height-110但不成立
            try
            {
                tbcTitle.Width = Width;
                web.Width = this.Width;
                web.Height = this.Height - 110;
                border.Width = Width;
                if (100 * (itemLen + 1) + 90 > Width)
                {
                    AvgItem();
                    itemsIsLong = true;
                }
            }
            catch (System.ArgumentException) { }        
        }
      
        //添加收藏夹
        private void Btn_shoucang(object sender, RoutedEventArgs e)
        {
            try
            {
                string title = ((dynamic)web.Document).Title;

                if (!btnTitle.Contains(title))
                {
                    Button button = new Button();
                    button.Content = title;
                    button.Height = 26;
                    button.Width = 100;
                    button.Margin = thick;
                    button.Background = (System.Windows.Media.Brush)myBrush;
                    button.BorderBrush = null;
                    button.Click += Btn_ShouCang;
                    btnTitle.Add(title);
                    btnUrl.Add(Url.Text);
                    shoucang.Children.Add(button);
                }
            }
            catch (System.NotSupportedException)
            {
                //MessageBox.Show("很抱歉，未获取到当前网页标题，请尝试刷新网页;等待网页加载完成后再尝试此操作");
            }
            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException)
            {
                //MessageBox.Show("很抱歉，未获取到当前网页标题，请尝试刷新网页;等待网页加载完成后再尝试此操作");
            }      
        }
       
        //给添加的收藏按钮加跳转事件
        private void Btn_ShouCang(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int idx = btnTitle.FindIndex(x => x == button.Content.ToString());
            if (idx != -1)
            {
                string szTmp = btnUrl[idx];
                Uri uri = new Uri(szTmp);
                web.Navigate(uri);
            } 
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
            try{ web.GoBack(); }
            catch (System.Runtime.InteropServices.COMException) { } 
        }
       
        //刷新
        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            web.Refresh();
        }

        //关闭标签
        void tbmClose(Button btnClose)
        {
            string[] sArray = Regex.Split(btnClose.Name, "_", RegexOptions.IgnoreCase);
            idxThis = sArray[1];
            string ItemName = "tbm_" + idxThis;
            //MessageBox.Show(ItemName);
            var temp = tbcTitle.Items;
            foreach (TabItem item in temp)
            {
                //MessageBox.Show(item.Name);
                if (item.Name == ItemName)
                {
                    tbcTitle.Items.Remove(item);
                    break;
                }
            }
            itemLen--;
        }

        //关闭事件
        private void Btn_DeleteItem(object sender, RoutedEventArgs e)
        {
            var btnClose = sender as Button;
            tbmClose(btnClose);
        }

        //在搜索栏中输入网址同步页面
        private void UrlTextBox_KeyDown(object sender, KeyEventArgs e)
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

        //切换TabItem时判断并计数
        private void TbcTitle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0 && e.AddedItems[0] is TabItem tbi)
            {
                try
                {
                    ThisShowLabN = int.Parse(Regex.Split(tbi.Name, "_", RegexOptions.IgnoreCase)[1]);
                }
                catch (System.IndexOutOfRangeException)
                {

                }    
            }
        }

    }
}
