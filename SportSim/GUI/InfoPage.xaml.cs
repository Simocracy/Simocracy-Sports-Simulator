﻿using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Simocracy.SportSim
{
	/// <summary>
	/// Interaktionslogik für InfoPage.xaml
	/// </summary>
	public partial class InfoPage : Page
	{
		public InfoPage()
		{
			InitializeComponent();
			Settings.LogPageOpened(this);
		}

		private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
		{
			try
			{
				var navigateUri = (sender as Hyperlink).NavigateUri.ToString();
				if(WikiHelper.CheckValidHttpUrl(navigateUri))
					System.Diagnostics.Process.Start(navigateUri);
			}
			catch { }
			e.Handled = true;
		}
	}
}
