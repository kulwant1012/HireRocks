using PS.Tracker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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


namespace PS.Tracker.View
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml/// </summary>
    public partial class LoginPage : Page
    {

        public LoginPage()
        {
            InitializeComponent();

        }
    }
}
    //    private async void Test()
    //    {
    //        try
    //        {
    //            client.BaseAddress = new Uri("http://localhost:46867/");
    //            client.DefaultRequestHeaders.Accept.Add(
    //                new MediaTypeWithQualityHeaderValue("application/json"));
    //            var response = await client.GetAsync("api/AuthenticateUser/AuthenticateUser");

    //            response.EnsureSuccessStatusCode(); // Throw on error code.

    //            var data = await response.Content.ReadAsAsync<LoginModel>();

    //        }
    //        catch (Newtonsoft.Json.JsonException jEx)
    //        {
    //            // This exception indicates a problem deserializing the request body.
    //            MessageBox.Show(jEx.Message);
    //        }
    //        catch (HttpRequestException ex)
    //        {
    //            MessageBox.Show(ex.Message);
    //        }
    //        finally
    //        {
    //        }
    //    }
    //}


 
