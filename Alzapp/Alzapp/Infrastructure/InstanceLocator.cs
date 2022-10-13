//Es para tener una unica clase MainViewModel y poder llegar a todos lados desde ahi 

namespace Alzapp.Infrastructure
{
    using Alzapp.ViewModels;

    public class InstanceLocator
    {
        public MainViewModel Main { get; set; }
        public InstanceLocator()
        {
            Main = new MainViewModel();
        }
    }
}