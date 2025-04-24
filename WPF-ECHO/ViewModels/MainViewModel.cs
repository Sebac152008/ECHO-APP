using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_ECHO.View;

namespace WPF_ECHO.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _currentChildView;

        public ViewModelBase CurrentChildView
        {
            get { return _currentChildView; }
            set { _currentChildView = value; 
            OnPropertyChanged(nameof(CurrentChildView)); }
        }

        //Commands

        public ICommand ShowInicioViewCommand { get; }
        public ICommand ShowAcercaDeCommand { get; }
        public ICommand ShowMenuNavCommand { get; }

        public ICommand ShowCalendarioCommand { get; }
        public ICommand ShowDestacadoViewCommand { get; }

        public MainViewModel()
        {
            //Initialize commands
            ShowInicioViewCommand = new ViewModelCommand(ExecuteShowInicioViewCommand);
            ShowDestacadoViewCommand = new ViewModelCommand(ExecuteShowDestacadoViewCommand);
            ShowAcercaDeCommand = new ViewModelCommand(ExecuteShowAcercaDeCommand);
            ShowMenuNavCommand = new ViewModelCommand(ExecuteShowMenuNavCommand);
            ShowCalendarioCommand = new ViewModelCommand(ExecuteShowCalendarioCommand);

            //Defaul view

            ExecuteShowInicioViewCommand(null);
        }

        private void ExecuteShowCalendarioCommand(object obj)
        {
            CurrentChildView = new CalendarioView();
        }

        private void ExecuteShowMenuNavCommand(object obj)
        {
            CurrentChildView = new MenuNav();
        }

        private void ExecuteShowAcercaDeCommand(object obj)
        {
            CurrentChildView = new AcercaDeView();
        }

        private void ExecuteShowInicioViewCommand(object obj)
        {
            CurrentChildView = new InicioView();
        }
        private void ExecuteShowDestacadoViewCommand(object obj)
        {
            CurrentChildView = new DestacadoView();
        }
    }
}
