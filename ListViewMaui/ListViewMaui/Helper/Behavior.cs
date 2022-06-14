using Syncfusion.Maui.ListView;
using Syncfusion.Maui.ListView.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListViewMaui
{
    #region Behavior
    public class Behavior : Behavior<SfListView>
    {
        #region Fields

        ListViewScrollView scrollview;
        double previousOffset;
        public SfListView listView;
        BooksViewModel viewModel;
        #endregion

        #region Overrides
        protected override void OnAttachedTo(SfListView bindable)
        {
            listView = bindable as SfListView;
            viewModel = new BooksViewModel();
            listView.BindingContext = viewModel;
            scrollview = listView.GetScrollView();
            scrollview.Scrolled += Scrollview_Scrolled;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(SfListView bindable)
        {
            scrollview.Scrolled -= Scrollview_Scrolled;
            listView = null;
            viewModel = null;
            scrollview = null;
            base.OnDetachingFrom(bindable);
        }
        #endregion

        #region Callback
        private void Scrollview_Scrolled(object sender, ScrolledEventArgs e)
        {
            if (e.ScrollY == 0)
                return;

            if (previousOffset >= e.ScrollY)
            {
                // Up direction  
                viewModel.ScrollDirection = "Up Direction";
            }
            else
            {
                //Down direction 
                viewModel.ScrollDirection = "Down Direction";
            }

            previousOffset = e.ScrollY;
        }
        #endregion
    }
    #endregion
}
