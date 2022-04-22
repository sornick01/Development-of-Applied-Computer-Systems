using System.Windows.Input;
using System.Windows.Media;
using Sorokin.Wpf.MVVM.Core.Command;
using Sorokin.Wpf.MVVM.Core.ViewModel;

namespace WpfApp1.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private Brush _ellipseBrush = Brushes.Chartreuse;
    private bool? _color = false;
    private int _size = 50;
    private int countButtonClicked;
    
    public int Size
    {
        get =>
            _size;
        private set
        {
            _size = value;
            RaisePropertyChanged(nameof(Size));
        }
    }

    public bool? Color
    {
        get =>
            _color;

        set
        {
            _color = value;
            RaisePropertyChanged(nameof(Color));
        }
    }
    
    public Brush EllipseBrush
    {
        get 
            => _ellipseBrush;
        private set
        {
            _ellipseBrush = value;
            RaisePropertyChanged(nameof(EllipseBrush));
        }
    }

    #region Constructors

    public MainWindowViewModel()
    {
        ChangeColorCommand = new RelayCommand(_ => ChangeColor());
    }

    #endregion
    
    #region Commands
    
    public ICommand ChangeColorCommand { get; }  
    #endregion
    
    #region Methods
    
    private void ChangeColor()
    {
        countButtonClicked++;
    
        if (countButtonClicked % 2 == 1)
        {
            EllipseBrush = Brushes.Fuchsia;
            Size = 25;
        }
        else
        {
            EllipseBrush = Brushes.Gold;
            Size = 100;
        }
    }

    #endregion
    
}