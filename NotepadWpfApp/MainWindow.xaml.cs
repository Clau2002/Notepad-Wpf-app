using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Media;
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

namespace NotepadWpfApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo driveInfo in drives)
                treeView.Items.Add(CreateTreeItem(driveInfo));
        }

        private void CommonCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        public void TreeViewItem_Expanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = e.Source as TreeViewItem;
            if ((item.Items.Count == 1) && (item.Items[0] is string) && !(item.Tag is FileInfo))
            {
                item.Items.Clear();
                DirectoryInfo expandedDir = null;

                if (item.Tag is DriveInfo)
                    expandedDir = (item.Tag as DriveInfo).RootDirectory;
                
                if (item.Tag is DirectoryInfo)
                    expandedDir = (item.Tag as DirectoryInfo);

                try
                {
                    foreach (DirectoryInfo subDir in expandedDir.GetDirectories())
                    {
                        item.Items.Add(CreateTreeItem(subDir));
                    }
                    foreach(FileInfo file in expandedDir.GetFiles())
                    {
                        item.Items.Add(CreateTreeItem(file));
                    }
                }
                catch { }
            }
        }

        private TreeViewItem CreateTreeItem(object o)
        {
            TreeViewItem item = new TreeViewItem();
            if (o is FileInfo)
            {
                item.Header = o.ToString();
                item.Tag = o;
                item.MouseDoubleClick += new MouseButtonEventHandler(AddTabFromTreeView);
                
            }
            else
            {
                item.Header = o.ToString();
                item.Tag = o;
                item.Items.Add("Loading...");
            }

            return item;
        }

        private void AddTabFromTreeView(object sender, RoutedEventArgs e)
        {
            TabItem newTab = new TabItem();
            newTab.Header = ((TreeViewItem)sender).Header.ToString();
            TextBox textBox = new TextBox();
            textBox.AcceptsReturn = true;
            textBox.AcceptsTab = true;
            newTab.Content = textBox;
            newTab.IsSelected = true;
            TabControl.Items.Add(newTab);
            newTab.Tag = (((TreeViewItem)sender).Tag as FileInfo).FullName;
            textBox.Text = File.ReadAllText((((TreeViewItem)sender).Tag as FileInfo).FullName);
        }

        private void btnAddNewTab_Click(object sender, RoutedEventArgs e)
        {
            TabItem newTab = new TabItem();
            newTab.Header = "File";
            TextBox textBox = new TextBox();
            textBox.AcceptsReturn = true;
            textBox.AcceptsTab = true;
            newTab.Content = textBox;
            newTab.IsSelected = true;
            TabControl.Items.Add(newTab);
        }

        private void btnSaveAsFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text file (*.txt)|*.txt|C# file (*.cs)|*.cs";
            if (!TabControl.Items.IsEmpty)
            {
                if (saveFileDialog.ShowDialog() == true)
                {
                    File.WriteAllText(saveFileDialog.FileName, ((TextBox)((TabItem)TabControl.SelectedItem).Content).Text);
                    ((TabItem)TabControl.SelectedItem).Header = System.IO.Path.GetFileName(saveFileDialog.FileName);
                }
            }
        }

        private void btnAutoSave_Click(object sender, RoutedEventArgs e)
        {
            if (!TabControl.Items.IsEmpty)
            {
                TabItem selectedTab = (TabItem)TabControl.SelectedItem;
                File.WriteAllText(selectedTab.Tag.ToString(), (selectedTab.Content as TextBox).Text);
            }
        }

        private void btnCloseTab_Click(object sender, RoutedEventArgs e)
        {
            TabControl.Items.Remove(TabControl.SelectedItem);
        }

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
           
            if (openFileDialog.ShowDialog() == true)
            {
                TabItem newTab = new TabItem();
                newTab.Header = System.IO.Path.GetFileName(openFileDialog.FileName);
                TextBox textBox = new TextBox();
                textBox.AcceptsReturn = true;
                textBox.AcceptsTab = true;
                newTab.Content = textBox;
                newTab.IsSelected = true;
                TabControl.Items.Add(newTab);
                newTab.Tag = openFileDialog.FileName;
                textBox.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            MyGrid.Children.Clear();
            MyGrid.Children.Add(MyDockPanel);
            TextBox textBox = new TextBox();
            Button button = new Button();
            button.Content = "Find";
            button.Background = new SolidColorBrush(Colors.Red);
            button.Click += FindFunction;

            Grid.SetColumn(button, 0);
            Grid.SetRow(button, 1);
            Grid.SetColumnSpan(textBox, 2);
            Grid.SetColumn(textBox, 1);
            Grid.SetRow(textBox, 1);
            MyGrid.Children.Add(textBox);
            MyGrid.Children.Add(button);
        }

        private void FindFunction(object sender, RoutedEventArgs e)
        {
            TextBox tabItem = (TextBox)TabControl.SelectedContent;

            TextBox textBox = (TextBox)MyGrid.Children[1];
            if (!TabControl.Items.IsEmpty)
            {
                if (tabItem.Text.Contains(textBox.Text))
                {
                    int indexStart = tabItem.Text.IndexOf(textBox.Text);
                    int indexFinal = textBox.Text.Length;
                    tabItem.Focus();
                    tabItem.SelectionBrush = new SolidColorBrush(Colors.Red);
                    tabItem.Select(indexStart, indexFinal);
                }
            }
            MyGrid.Children.Clear();
            MyGrid.Children.Add(MyDockPanel);
        }

        private void btnReplace_Click(object sender, RoutedEventArgs e)
        {
            MyGrid.Children.Clear();
            MyGrid.Children.Add(MyDockPanel);
            TextBox textBox = new TextBox();
            TextBox replaceTextBox = new TextBox();
            Button button = new Button();

            button.Content = "Replace";
            button.Background = new SolidColorBrush(Colors.Red);
            button.Click += ReplaceFunction;
            Grid.SetColumn(replaceTextBox, 1);
            Grid.SetRow(replaceTextBox, 1);
            Grid.SetColumn(button, 0);
            Grid.SetRow(button, 1);
            Grid.SetColumn(textBox, 2);
            Grid.SetRow(textBox, 1);
            MyGrid.Children.Add(textBox);
            MyGrid.Children.Add(button);
            MyGrid.Children.Add(replaceTextBox);
        }

        private void ReplaceFunction(object sender, RoutedEventArgs e)
        {
            TextBox tabItem = (TextBox)TabControl.SelectedContent;
            TextBox inputTextBox = (TextBox)MyGrid.Children[3];
            TextBox replaceTextBox = (TextBox)MyGrid.Children[1];

            if (!TabControl.Items.IsEmpty)
            {
                if (tabItem.Text.Contains(inputTextBox.Text))
                {
                    int indexStart = tabItem.Text.IndexOf(inputTextBox.Text);
                    int indexFinal = inputTextBox.Text.Length;
                    tabItem.Focus();
                    tabItem.Text = tabItem.Text.Remove(indexStart, indexFinal);
                    tabItem.Text = tabItem.Text.Insert(indexStart, replaceTextBox.Text);
                }
            }
            MyGrid.Children.Clear();
            MyGrid.Children.Add(MyDockPanel);
        }

        private void btnReplaceAll_Click(object sender, RoutedEventArgs e)
        {
            MyGrid.Children.Clear();
            MyGrid.Children.Add(MyDockPanel);
            TextBox textBox = new TextBox();
            TextBox replaceTextBox = new TextBox();
            Button button = new Button();
            button.Content = "ReplaceAll";
            button.Background = new SolidColorBrush(Colors.Red);
            button.Click += ReplaceAllFunction;
            Grid.SetColumn(replaceTextBox, 1);
            Grid.SetRow(replaceTextBox, 1);
            Grid.SetColumn(button, 0);
            Grid.SetRow(button, 1);
            Grid.SetColumn(textBox, 2);
            Grid.SetRow(textBox, 1);
            MyGrid.Children.Add(textBox);
            MyGrid.Children.Add(button);
            MyGrid.Children.Add(replaceTextBox);
        }

        private void ReplaceAllFunction(object sender, RoutedEventArgs e)
        {
            TextBox tabItem = (TextBox)TabControl.SelectedContent;
            TextBox inputTextBox = (TextBox)MyGrid.Children[3];
            TextBox replaceTextBox = (TextBox)MyGrid.Children[1];

            if (!TabControl.Items.IsEmpty)
            {
                while (tabItem.Text.Contains(inputTextBox.Text))
                {
                    int indexStart = tabItem.Text.IndexOf(inputTextBox.Text);
                    int indexFinal = inputTextBox.Text.Length;
                    tabItem.Focus();
                    tabItem.Text = tabItem.Text.Remove(indexStart, indexFinal);
                    tabItem.Text = tabItem.Text.Insert(indexStart, replaceTextBox.Text);
                }
            }
            MyGrid.Children.Clear();
            MyGrid.Children.Add(MyDockPanel);
        }

        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            WindowFind windowFind = new WindowFind();
            windowFind.Show();
        }
    }
}
