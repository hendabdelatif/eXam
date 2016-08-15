using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;
using System.Reflection;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;
using Plugin.Connectivity;

namespace eXam
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class App : Application
    {

        public static Game CurrentGame { get; private set; }
        public static IFileHelper FileHelper { get; private set; }

        public App()
        {

            MainPage = new NavigationPage(new HomePage());
            FileHelper = DependencyService.Get<IFileHelper>();
        }

        protected override async void OnStart()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                Debug.WriteLine("Connection exists");
            }
            else
            { 
                Debug.WriteLine("Connection does not exist");
            }
            
            List<QuizQuestion> questions = null;
            string result = await FileHelper.LoadLocalFileAsync("cachedquestions.xml");
            if (result == null)
            {
                StreamReader stream = new StreamReader(typeof(App).GetTypeInfo()
                                 .Assembly.GetManifestResourceStream("eXam.Data.questions.xml"));
                result = stream.ReadToEnd();
            }
            await FileHelper.SaveLocalFileAsync("cachedquestions.xml", result);
            questions = QuizQuestionXmlSerializer.Deserialize(result);
            CurrentGame = new Game(questions);
        }
         
        protected override void OnSleep()
        { 
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
