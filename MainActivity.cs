using Android.App;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace FragmentActivityTest
{
    [Activity(Label = "FragmentActivityTest", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : FragmentActivity<MainActivityFragment>
    {
    }

    public class MainActivityFragment : FragmentBase
    {
        private int _count = 0;
        private Button _button;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.Main, container, attachToRoot: false);

            _button = view.FindViewById<Button>(Resource.Id.myButton);

            if (_count != 0)
            {
                UpdateButtonText();
            }

            _button.Click += delegate
                {
                    _count++;
                    UpdateButtonText();
                };

            return view;
        }

        private void UpdateButtonText()
        {
            _button.Text = string.Format("{0} clicks!", _count);
        }
    }
}
