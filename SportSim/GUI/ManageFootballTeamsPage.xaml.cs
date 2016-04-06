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
	/// Interaktionslogik für ManageFootballTeamsPage.xaml
	/// </summary>
	public partial class ManageFootballTeamsPage : Page
	{
		public ManageFootballTeamsPage()
		{
			InitializeComponent();
			_IsInNewMode = false;

#if !DEBUG
			DebugIDLabel.Visibility = Visibility.Collapsed;
#endif
		}

		private bool _IsInNewMode;

		public FootballTeam SelectedFootballTeam
		{
			get { return FootballTeamsList.SelectedItem as FootballTeam; }
			set
			{
				FootballTeamsList.SelectedItem = value;
				FootballTeamsList.ScrollIntoView(value);
				MarkAllValid();
				_IsInNewMode = false;
			}
		}

		private void ClearInputs()
		{
			MarkAllValid();

			DebugIDLabel.ClearValue(Label.ContentProperty);
			NameTextBox.Clear();
			LogoTextBox.Clear();
			StateComboBox.ClearValue(ComboBox.SelectedValueProperty);
			StadiumComboBox.ClearValue(ComboBox.SelectedValueProperty);
			GoalkeeperSlider.ClearValue(Slider.ValueProperty);
			DefenseSlider.ClearValue(Slider.ValueProperty);
			MidfieldSlider.ClearValue(Slider.ValueProperty);
			ForwardSlider.ClearValue(Slider.ValueProperty);
		}

		private bool ValidateInputs()
		{
			MarkAllValid();
			bool isAllValid = true;

			if(String.IsNullOrEmpty(NameTextBox.Text))
			{
				isAllValid = false;
				MarkWrongInput(NameTextBox);
			}

			if(StateComboBox.SelectedIndex < 0)
			{
				isAllValid = false;
				MarkWrongInput(StateComboBox);
			}

			if(StadiumComboBox.SelectedIndex < 0)
			{
				isAllValid = false;
				MarkWrongInput(StadiumComboBox);
			}

			return isAllValid;
		}

		private void SaveData()
		{
			SelectedFootballTeam.Name = NameTextBox.Text;
			SelectedFootballTeam.Logo = LogoTextBox.Text;
			SelectedFootballTeam.State= StateComboBox.SelectedItem as State;
			SelectedFootballTeam.Stadium = StadiumComboBox.SelectedItem as Stadium;
			SelectedFootballTeam.GoalkeeperStrength = (int) GoalkeeperSlider.Value;
			SelectedFootballTeam.DefenseStrength = (int) DefenseSlider.Value;
			SelectedFootballTeam.MidfieldStrength = (int) MidfieldSlider.Value;
			SelectedFootballTeam.ForwardStrength = (int) ForwardSlider.Value;
		}

		private void Create()
		{
			Settings.FootballTeams.Create(
				NameTextBox.Text,
				LogoTextBox.Text,
				(int) GoalkeeperSlider.Value,
				(int) DefenseSlider.Value,
				(int) MidfieldSlider.Value,
				(int) ForwardSlider.Value);

			_IsInNewMode = false;
			SelectedFootballTeam = Settings.FootballTeams.Last();
		}

		private void MarkAllValid()
		{
			NameTextBox.ClearValue(Control.StyleProperty);
			LogoTextBox.ClearValue(Control.StyleProperty);
			StateComboBox.ClearValue(Control.StyleProperty);
			StadiumComboBox.ClearValue(Control.StyleProperty);
		}

		private void MarkWrongInput(Control control)
		{
			control.Style = Application.Current.TryFindResource("InvalidInput") as Style;
		}

		private void DeleteButton_Click(object sender, RoutedEventArgs e)
		{
			Settings.FootballTeams.Remove(SelectedFootballTeam);
			MarkAllValid();
			_IsInNewMode = false;
		}

		private void NewButton_Click(object sender, RoutedEventArgs e)
		{
			ClearInputs();
			NameTextBox.Focus();
			_IsInNewMode = true;
		}

		private void SaveButton_Click(object sender, RoutedEventArgs e)
		{
			if(ValidateInputs())
			{
				if(_IsInNewMode)
					Create();
				else
					SaveData();

				MarkAllValid();
			}
		}

		private void FootballTeamsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			MarkAllValid();
			_IsInNewMode = false;
		}
	}
}
