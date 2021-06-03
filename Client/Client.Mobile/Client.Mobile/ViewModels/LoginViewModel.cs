using Client.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Client.Mobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public UserRequest UserModel { get; set; }
        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            UserModel = new UserRequest() { Username = "", Password = "" };
            LoginCommand = new Command(async () => await OnLoginClicked());
        }

        private async Task OnLoginClicked()
        {
            try
            {
                if (UserModel == null) return;
                if (UserModel.Username.Length < 1 || UserModel.Password.Length < 1)
                {
                    await Application.Current.MainPage.DisplayAlert("Login", "Kullanıcı Adı veya Parola Boş Olamaz.", "OK");
                    return;
                }


                var data = await LoadData(UserModel);

                if (data != null)
                {
                    // Giriş işleminden sonra kullanıcı bilgileri SecureStorage'a set ediliyor.
                    // Daha sonraki işlemlerde bu kullanıcı bilgileri ile apiye istekte bulunacağız.
                    await SecureStorage.SetAsync("id", data.Id.ToString());
                    await SecureStorage.SetAsync("username", UserModel.Username);
                    await SecureStorage.SetAsync("password", UserModel.Password);

                    App.Current.MainPage = new MainPage();
                }
                else
                    await Application.Current.MainPage.DisplayAlert("Login", "Kullanıcı bulunamadı", "OK");

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Uyarı", "Bir hata oluştu", "Tamam");
            }
        }

        public async Task<User> LoadData(UserRequest user)
        {
            try
            {
                IsBusy = true;

                var userData = await LoginDataStore.LoginAsync(user);

                return userData;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
