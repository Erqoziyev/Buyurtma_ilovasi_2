using Buyurtma_ilovasi_2.Entities.orders;
using System;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Buyurtma_ilovasi_2.Components;

/// <summary>
/// Interaction logic for OrderedMealUserControl.xaml
/// </summary>
public partial class OrderedMealUserControl : UserControl
{

    public Action<Order> DeleteOrder { get; set; }

    public Order OrderClon { get; set; }
    public OrderedMealUserControl()
    {
        InitializeComponent();
    }


    public void SetData(Order orders)
    {
        OrderClon = orders;
        lblCount.Content=orders.food_count.ToString();
        lblName.Content=orders.food_name.ToString();
        lblPrice.Content=orders.food_price.ToString();
    }

    private void btndelete_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        DeleteOrder(OrderClon);
    }
}
