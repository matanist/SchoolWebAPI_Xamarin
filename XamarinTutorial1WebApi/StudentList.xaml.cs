using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using XamarinTutorial1WebApi.Models;

namespace XamarinTutorial1WebApi
{
	public partial class StudentList : ContentPage
	{
		void MenuItemDetail_Clicked(object sender, EventArgs eventArgs)
		{
			var student = ((MenuItem)sender).CommandParameter as Student;
			if (student != null)
			{
				Navigation.PushModalAsync(new AddStudent(student));
			}
		}
		async void MenuItemDelete_Clicked(object sender, EventArgs eventArgs)
		{
			var student = ((MenuItem)sender).CommandParameter as Student;
			if (student != null)
			{
				var result = await DisplayAlert("Warning", "Are you sure?", "OK", "Cancel");
				if (result)
				{
					await (new WebAPIService()).DeleteStudentAsync(student.Id);
				}
			}
		}
		public StudentList()
		{
			InitializeComponent();
		}
		protected override async void OnAppearing()
		{
			base.OnAppearing();

			var result = await (new WebAPIService()).GetData();

			lstVStudent.ItemsSource = result;
		}


	}
}
