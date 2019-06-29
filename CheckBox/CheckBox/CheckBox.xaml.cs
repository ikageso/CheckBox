using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CheckBox
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CheckBox : ContentView
    {
        #region BindableProperty
        public static readonly BindableProperty IsCheckedProperty = BindableProperty.Create(propertyName: nameof(IsChecked), returnType: typeof(bool), declaringType: typeof(CheckBox), defaultValue:false,
            propertyChanged: (bindable, oldValue, newValue) => { ((CheckBox)bindable).OnChecked((bool)newValue); });
        public static readonly BindableProperty TrueImageSourceProperty = BindableProperty.Create(propertyName: nameof(TrueImageSource), returnType: typeof(ImageSource), declaringType: typeof(CheckBox),
            propertyChanged: (bindable, oldValue, newValue) => { ((CheckBox)bindable).OnTrueImageSourceChanged((ImageSource)newValue); });
        public static readonly BindableProperty FalseImageSourceProperty = BindableProperty.Create(propertyName: nameof(FalseImageSource), returnType: typeof(ImageSource), declaringType: typeof(CheckBox),
            propertyChanged: (bindable, oldValue, newValue) => { ((CheckBox)bindable).OnFalseImageSourceChanged((ImageSource)newValue); });


        private void OnChecked(bool newValue)
        {
            this.checkOn.IsVisible = IsChecked;
            this.checkOff.IsVisible = !IsChecked;
        }
        private void OnTrueImageSourceChanged(ImageSource newValue)
        {
            this.checkOn.Source = newValue;
        }
        private void OnFalseImageSourceChanged(ImageSource newValue)
        {
            this.checkOff.Source = newValue;
        }

        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }
        public ImageSource TrueImageSource
        {
            get { return (ImageSource)GetValue(TrueImageSourceProperty); }
            set { SetValue(TrueImageSourceProperty, value); }
        }
        public ImageSource FalseImageSource
        {
            get { return (ImageSource)GetValue(FalseImageSourceProperty); }
            set { SetValue(FalseImageSourceProperty, value); }
        }
        #endregion

        public CheckBox()
        {
            InitializeComponent();

            this.checkOn.IsVisible = IsChecked;
            this.checkOff.IsVisible = !IsChecked;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            IsChecked = !IsChecked;
        }
    }
}