using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShopEasy
{
    /// <summary>
    /// Interaction logic for ListSwapper.xaml
    /// </summary>
    public partial class ListSwapper : UserControl
    {
        List<ShoppingList> lists = new List<ShoppingList>();
        int currentListIndex = 0;
        public ListSwapper()
        {
            InitializeComponent();
            EnableOrDisableButtons();
        }

        void AddNewList(object sender, RoutedEventArgs e)
        {
            var list = new ShoppingList();
            currentListIndex = lists.Count;
            lists.Add(list);
            containerBorder.Child = list;
            EnableOrDisableButtons();
        }

        void PriorList(object sender, RoutedEventArgs e)
        {
            if (lists.Count == 0) return;
            currentListIndex--;
            if (currentListIndex < 0) currentListIndex = 0;
            containerBorder.Child = lists[currentListIndex];
            EnableOrDisableButtons();
        }

        void NextList(object sender, RoutedEventArgs e)
        {
            if (lists.Count == 0) return;
            currentListIndex++;
            if (currentListIndex > lists.Count - 1) currentListIndex = lists.Count - 1;
            containerBorder.Child = lists[currentListIndex];
            EnableOrDisableButtons();
        }

        void EnableOrDisableButtons()
        {
            if(lists.Count < 1)
            {
                priorButton.IsEnabled = false;
                nextButton.IsEnabled = false;
            }
            else if(currentListIndex == 0)
            {
                priorButton.IsEnabled = false;
                nextButton.IsEnabled = true;
            }
            else if(currentListIndex == lists.Count - 1)
            {
                priorButton.IsEnabled = true;
                nextButton.IsEnabled = false;
            }
            else
            {
                priorButton.IsEnabled = true;
                nextButton.IsEnabled = true;
            }
        }
    }
}
