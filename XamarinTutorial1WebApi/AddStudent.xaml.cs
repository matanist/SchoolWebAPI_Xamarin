using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamarinTutorial1WebApi.Models;

namespace XamarinTutorial1WebApi
{
	public partial class AddStudent : ContentPage
	{
		public AddStudent(Student student)
		{

			InitializeComponent();
			if (student != null)
			{
				entryName.Text = student.Name;
				entrySurname.Text = student.Surname;
				entryNumber.Text = student.Number.ToString();
				entryPhone.Text = student.Phone;
				btnSave.Text = "Update";
				btnSave.CommandParameter = student;
			}
		}
		async void BtnSave_Handle(object sender, EventArgs eventArgs)
		{
			if (btnSave.Text == "Save")
			{
				var name = entryName.Text;
				var surName = entrySurname.Text;
				var number = Convert.ToInt32(entryNumber.Text);
				var phone = entryPhone.Text;
				var newStudent = new Student
				{
					Name = name,
					Surname = surName,
					Number = number,
					Phone = phone
				};
				var result = await (new WebAPIService()).AddStudentAsync(newStudent);
				if (result == "Success")
				{
					await DisplayAlert("Status", "Success", "OK");
				}
			}
			else
			{
				//UpdateStudent
				var student = btnSave.CommandParameter as Student;
				var updatedStudent = new Student
				{
					Id = student.Id,
					Name = entryName.Text,
					Surname = entrySurname.Text,
					Number = Convert.ToInt32(entryNumber.Text),
					Phone = entryPhone.Text
				};
				await (new WebAPIService()).UpdateStudentAsync(updatedStudent);
			}

		}
	}
}
