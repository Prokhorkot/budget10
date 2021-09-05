using GAIExam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAIExam.MVVM.ViewModel
{
    class MainViewModel: ObservableObject    
    {

        public RelayCommand HelloViewCommand { get; set; }

        public RelayCommand HomeViewCommand { get; set; }

        public GraphViewModel GraphVM { get; set; }

        public HelloViewModel HelloVM { get; set; }

        public HomeViewModel HomeVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set 
            { 
                _currentView = value;
                OnPropertyChange();
            }
        }


        public MainViewModel()
        {
            HelloVM = new HelloViewModel();
            HomeVM = new HomeViewModel();
            GraphVM = new GraphViewModel();
            CurrentView = HelloVM;

            HelloViewCommand = new RelayCommand( o =>
            {
                CurrentView = HelloVM;
            });

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });
        }
    }
}
