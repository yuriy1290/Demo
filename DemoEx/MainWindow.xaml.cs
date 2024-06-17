using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using DemoEx.Models;
using Microsoft.Win32;

namespace DemoEx
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadUsers();
            LoadRoles();
            LoadOffice();
        }

        private void LoadUsers()
        {
            ListCheck.Items.Clear();
            List<User> users = DataBase.GetUsers();
            foreach (var user in users)
            {
                user.Image = ConvertToAbsolutePath(user.Image);
                ListCheck.Items.Add(user);
            }
        }

        private void LoadRoles()
        {
            List<Role> roles = DataBase.GetRoles();
            RoleComboBox.ItemsSource = roles;
            RoleComboBox.DisplayMemberPath = "Title";
        }

        private void LoadOffice()
        {
            List<Office> office = DataBase.GetOffices();
            OfficeComboBox.ItemsSource = office;
            OfficeComboBox.DisplayMemberPath = "Tittle";
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string imagePath = SaveImageToFolder(ImageTextBox.Text);

            if (string.IsNullOrEmpty(imagePath))
            {
                MessageBox.Show("Error saving the image. User was not added.");
                return;
            }

            var user = new User
            {
                RoleID = (RoleComboBox.SelectedItem as Role)?.ID ?? 0,
                Email = EmailTextBox.Text,
                Pssword = PasswordTextBox.Password,
                FirstName = FirstNameTextBox.Text,
                LastName = LastNameTextBox.Text,
                OfficeID = (OfficeComboBox.SelectedItem as Office)?.ID ?? 0,
                BirthDate = BirthDatePicker.SelectedDate ?? DateTime.MinValue,
                Image = imagePath,
                Active = ActiveTextBox.Text
            };

            DataBase.AddUser(user);
            LoadUsers();
        }

        private string SaveImageToFolder(string imagePath)
        {
            if (File.Exists(imagePath))
            {
                try
                {
                    string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                    string destinationFolder = Path.Combine(projectDirectory, "images");

                    string fileName = Path.GetFileName(imagePath);
                    string destinationPath = Path.Combine(destinationFolder, fileName);

                    if (!Directory.Exists(destinationFolder))
                    {
                        Directory.CreateDirectory(destinationFolder);
                    }

                    File.Copy(imagePath, destinationPath, true);

                    return $"/images/{fileName}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error copying the image: {ex.Message}");
                    return string.Empty;
                }
            }
            else
            {
                MessageBox.Show("Image not found at the specified path.");
                return string.Empty;
            }
        }

        private string ConvertToAbsolutePath(string relativePath)
        {
            if (string.IsNullOrEmpty(relativePath))
                return string.Empty;

            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            return new Uri(Path.Combine(projectDirectory, relativePath.TrimStart('/'))).AbsoluteUri;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (ListCheck.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите пользователя для изменения.");
                return;
            }

            string imagePath = SaveImageToFolder(ImageTextBox.Text);

            if (string.IsNullOrEmpty(imagePath))
            {
                MessageBox.Show("Ошибка при сохранении изображения. Пользователь не был обновлен.");
                return;
            }

            User selectedUser = (User)ListCheck.SelectedItem;

            selectedUser.RoleID = (RoleComboBox.SelectedItem as Role)?.ID ?? 0;
            selectedUser.Email = EmailTextBox.Text;
            selectedUser.Pssword = PasswordTextBox.Password;
            selectedUser.FirstName = FirstNameTextBox.Text;
            selectedUser.LastName = LastNameTextBox.Text;
            selectedUser.OfficeID = (OfficeComboBox.SelectedItem as Office)?.ID ?? 0;
            selectedUser.BirthDate = BirthDatePicker.SelectedDate ?? DateTime.MinValue;
            selectedUser.Image = imagePath;
            selectedUser.Active = ActiveTextBox.Text;

            DataBase.UpdateUser(selectedUser);
            LoadUsers();
        }


        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (ListCheck.SelectedItem != null)
            {
                User selectedUser = (User)ListCheck.SelectedItem;

                // Показываем диалоговое окно с запросом подтверждения
                MessageBoxResult result = MessageBox.Show("Удалить выбранную запись?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    // Удаляем пользователя из базы данных
                    DataBase.DeleteUser(selectedUser.ID);
                    // Перезагружаем список пользователей
                    LoadUsers();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите пользователя для удаления.");
            }
        }


        private void ListCheck_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListCheck.SelectedItem != null)
            {
                User selectedUser = (User)ListCheck.SelectedItem;

                RoleComboBox.SelectedValue = selectedUser.RoleID;
                EmailTextBox.Text = selectedUser.Email;
                PasswordTextBox.Password = selectedUser.Pssword;
                FirstNameTextBox.Text = selectedUser.FirstName;
                LastNameTextBox.Text = selectedUser.LastName;
                OfficeComboBox.SelectedValue = selectedUser.OfficeID;
                BirthDatePicker.SelectedDate = selectedUser.BirthDate;
                ImageTextBox.Text = selectedUser.Image;
                ActiveTextBox.Text = selectedUser.Active;

                if (RoleComboBox.ItemsSource != null)
                {
                    foreach (Role role in RoleComboBox.ItemsSource)
                    {
                        if (role.ID == selectedUser.RoleID)
                        {
                            RoleComboBox.SelectedItem = role;
                            break;
                        }
                    }
                }
                if (OfficeComboBox.ItemsSource != null)
                {
                    foreach (Office office in OfficeComboBox.ItemsSource)
                    {
                        if (office.ID == selectedUser.OfficeID)
                        {
                            OfficeComboBox.SelectedItem = office;
                            break;
                        }
                    }
                }
            }
        }

        private void RoleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RoleComboBox.SelectedItem != null)
            {
                Role selectedRole = (Role)RoleComboBox.SelectedItem;
                RoleComboBox.Text = selectedRole.ID.ToString();
                RoleComboBox.Text = selectedRole.Title;
            }
        }

        private void OfficeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OfficeComboBox.SelectedItem != null)
            {
                Office selectedOffice = (Office)OfficeComboBox.SelectedItem;
                OfficeComboBox.Text = selectedOffice.ID.ToString();
                OfficeComboBox.Text = selectedOffice.Tittle;
            }
        }

        private void BrowseImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif; *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                string selectedImagePath = openFileDialog.FileName;
                ImageTextBox.Text = selectedImagePath;
            }
        }
    }
}
