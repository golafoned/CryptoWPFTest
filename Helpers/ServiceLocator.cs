using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CryptoTest.Helpers
{
    public static class ServiceLocator
    {
       public static T GetService<T>() => (T)((App)Application.Current).Services.GetService(typeof(T));
    }
}
