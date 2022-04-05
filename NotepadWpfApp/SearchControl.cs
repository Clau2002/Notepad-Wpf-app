using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace NotepadWpfApp
{
    class SearchControl : MainWindow
    {
        //public void FindFct(object sender, RoutedEventArgs e)
        //{
        //    MyGrid.Children.Clear();
        //    MyGrid.Children.Add(MyDockPanel);
        //    TextBox textBox = new TextBox();
        //    Button button = new Button();
        //    button.Content = "Find";
        //    button.Background = new SolidColorBrush(Colors.Red);
        //    button.Click += btn_FindButtonRepl;

        //    Grid.SetColumn(button, 0);
        //    Grid.SetRow(button, 1);
        //    Grid.SetColumnSpan(textBox, 2);
        //    Grid.SetColumn(textBox, 1);
        //    Grid.SetRow(textBox, 1);
        //    MyGrid.Children.Add(textBox);
        //    MyGrid.Children.Add(button);
        //}

        //public void btn_FindButtonRepl(object sender, RoutedEventArgs e)
        //{
        //    TextBox tabItem = (TextBox)TabControl.SelectedContent;

        //    TextBox textBox = (TextBox)MyGrid.Children[1];
        //    if (!TabControl.Items.IsEmpty)
        //    {
        //        if (tabItem.Text.Contains(textBox.Text))
        //        {
        //            int indexStart = tabItem.Text.IndexOf(textBox.Text);
        //            int indexFinal = textBox.Text.Length;
        //            tabItem.Focus();
        //            tabItem.SelectionBrush = new SolidColorBrush(Colors.Red);
        //            tabItem.Select(indexStart, indexFinal);
        //        }
        //    }
        //    MyGrid.Children.Clear();
        //    MyGrid.Children.Add(MyDockPanel);
        //}

        //public void btn_Replace(object sender, RoutedEventArgs e)
        //{
        //    MyGrid.Children.Clear();
        //    MyGrid.Children.Add(MyDockPanel);
        //    TextBox textBox = new TextBox();
        //    TextBox replaceTextBox = new TextBox();
        //    Button button = new Button();

        //    button.Content = "Replace";
        //    button.Background = new SolidColorBrush(Colors.Red);
        //    button.Click += btn_ReplaceButton;
        //    Grid.SetColumn(replaceTextBox, 1);
        //    Grid.SetRow(replaceTextBox, 1);
        //    Grid.SetColumn(button, 0);
        //    Grid.SetRow(button, 1);
        //    Grid.SetColumn(textBox, 2);
        //    Grid.SetRow(textBox, 1);
        //    MyGrid.Children.Add(textBox);
        //    MyGrid.Children.Add(button);
        //    MyGrid.Children.Add(replaceTextBox);
        //}

        //public void btn_ReplaceButton(object sender, RoutedEventArgs e)
        //{
        //    TextBox tabItem = (TextBox)TabControl.SelectedContent;
        //    TextBox inputTextBox = (TextBox)MyGrid.Children[3];
        //    TextBox replaceTextBox = (TextBox)MyGrid.Children[1];

        //    if (!TabControl.Items.IsEmpty)
        //    {
        //        if (tabItem.Text.Contains(inputTextBox.Text))
        //        {
        //            int indexStart = tabItem.Text.IndexOf(inputTextBox.Text);
        //            int indexFinal = inputTextBox.Text.Length;
        //            tabItem.Focus();
        //            tabItem.Text = tabItem.Text.Remove(indexStart, indexFinal);
        //            tabItem.Text = tabItem.Text.Insert(indexStart, replaceTextBox.Text);
        //        }
        //    }
        //    MyGrid.Children.Clear();
        //    MyGrid.Children.Add(MyDockPanel);
        //}

        //public void ReplaceAll_Func(object sender, RoutedEventArgs e)
        //{
        //    MyGrid.Children.Clear();
        //    MyGrid.Children.Add(MyDockPanel);
        //    TextBox textBox = new TextBox();
        //    TextBox replaceTextBox = new TextBox();
        //    Button button = new Button();

        //    button.Content = "ReplaceAll";
        //    button.Background = new SolidColorBrush(Colors.Red);
        //    button.Click += btn_ReplaceAll;
        //    Grid.SetColumn(replaceTextBox, 1);
        //    Grid.SetRow(replaceTextBox, 1);
        //    Grid.SetColumn(button, 0);
        //    Grid.SetRow(button, 1);
        //    Grid.SetColumn(textBox, 2);
        //    Grid.SetRow(textBox, 1);
        //    MyGrid.Children.Add(textBox);
        //    MyGrid.Children.Add(button);
        //    MyGrid.Children.Add(replaceTextBox);
        //}

        //public void btn_ReplaceAll(object sender, RoutedEventArgs e)
        //{
        //    TextBox tabItem = (TextBox)TabControl.SelectedContent;
        //    TextBox inputTextBox = (TextBox)MyGrid.Children[3];
        //    TextBox replaceTextBox = (TextBox)MyGrid.Children[1];

        //    if (!TabControl.Items.IsEmpty)
        //    {
        //        while (tabItem.Text.Contains(inputTextBox.Text))
        //        {
        //            int indexStart = tabItem.Text.IndexOf(inputTextBox.Text);
        //            int indexFinal = inputTextBox.Text.Length;
        //            tabItem.Focus();
        //            tabItem.Text = tabItem.Text.Remove(indexStart, indexFinal);
        //            tabItem.Text = tabItem.Text.Insert(indexStart, replaceTextBox.Text);
        //        }
        //    }
        //    MyGrid.Children.Clear();
        //    MyGrid.Children.Add(MyDockPanel);
        //}

        //public void Help_Btn(object sender, RoutedEventArgs e)
        //{
        //    WindowFind windowFind = new WindowFind();
        //    windowFind.Show();
        //    windowFind.btn_HelpClick(sender, e);
        //}
    }
}
