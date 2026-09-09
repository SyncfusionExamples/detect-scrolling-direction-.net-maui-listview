# How to detect scrolling direction in .NET MAUI ListView(SfListView)?

Detect the scrolling direction in [.NET MAUI ListView](https://www.syncfusion.com/maui-controls/maui-listview) by using the **Scrolled** event of
the [ListViewScrollView](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.ListView.ListViewScrollView.html).

**XAML**

In the [SfListView.HeaderTemplate](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.ListView.SfListView.html#Syncfusion_Maui_ListView_SfListView_HeaderTemplate), bind the ViewModel property to show the scroll direction.
<listView:SfListView x:Name="listView" ItemsSource="{Binding BookInfo}" ItemSize="120" IsStickyHeader="True">
           
        <listView:SfListView.Behaviors>
            <local:Behavior/>
        </listView:SfListView.Behaviors>
            
        <listView:SfListView.HeaderTemplate>
            <DataTemplate>
                <StackLayout BackgroundColor="LightGray">
                    <Label Text="{Binding Path=BindingContext.ScrollDirection, Source={x:Reference listView}}" FontAttributes="Bold" HorizontalOptions="FillAndExpand" HorizontalTextAlignment="Center" VerticalOptions="FillAndExpand" VerticalTextAlignment="Center"/>
                </StackLayout>
            </DataTemplate>
        </listView:SfListView.HeaderTemplate>
    </listView:SfListView>
C#

Get
the **ListViewScrollView** by using the [ListView.GetScrollView](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.ListView.Helpers.SfListViewHelper.html#Syncfusion_Maui_ListView_Helpers_SfListViewHelper_GetScrollView_Syncfusion_Maui_ListView_SfListView_) helper method and update the **ScrollDirection** value based on the previous offset.

public class Behavior : Behavior<SfListView>
    {
        ListViewScrollView scrollview;
        double previousOffset;
        public SfListView listView;
        BooksViewModel viewModel;
     
        protected override void OnAttachedTo(SfListView bindable)
        {
            listView = bindable as SfListView;
            viewModel = new BooksViewModel();
            listView.BindingContext = viewModel;
            scrollview = listView.GetScrollView();
            scrollview.Scrolled += Scrollview_Scrolled;
            base.OnAttachedTo(bindable);
        }
     
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
    }
    

Download the complete sample on [GitHub](https://github.com/SyncfusionExamples/detect-scrolling-direction-.net-maui-listview)

**Conclusion**

I hope you enjoyed learning how to
detect the scrolling direction in .NET MAUI ListView.

You can refer to our [.NET MAUI ListView feature tour](https://www.syncfusion.com/maui-controls/maui-listview) page to learn about its other groundbreaking feature
representations. Explore our [documentation](https://help.syncfusion.com/maui/listview/getting-started) to understand how to create
and manipulate data.

For current customers, check out our components from the [License and Downloads](https://www.syncfusion.com/sales/teamlicense) page. If you are new to Syncfusion®, try our 30-day [free trial](https://www.syncfusion.com/downloads/maui)to check out our other controls.

Please let us know in the comments section below if you have any queries or require clarification. Contact us through our [support
forums](https://www.syncfusion.com/forums), [Direct-Trac](https://support.syncfusion.com/create), or [feedback portal.](https://www.syncfusion.com/feedback/maui?control=sflistview) We are always happy to assist you!
