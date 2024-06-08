using System.Drawing.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GFS
{
    public partial class Main : Form
    {
        Steuerung steuerung = new Steuerung();

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            setMenu();
        }
        private decimal totalCost = 0;
        private bool oredered = false;

        public void setTotalCost(decimal totalCost)
        {
            this.totalCost = totalCost;
        }
        public decimal getTotalCost() { return totalCost; }


        private void txt_Id_TextChanged(object sender, EventArgs e)
        {
            try
            {
                steuerung.setId(Convert.ToInt32(txt_Id.Text));
                steuerung.checkRegistered();
                if (steuerung.getRegistered())
                {
                    txt_status.Text = "Ok";

                    string balance = Steuerung.GetBalanceById(steuerung.getId()).ToString();
                    txt_bal.Text = balance + "€";
                }
                else
                {
                    txt_status.Text = "Fehlerhafte ID! Id konnte nicht gefunden werden";
                }
            }
            catch (Exception)
            {

                txt_status.Text = "Fehler bei der Eingabe";
            }

        }

        private void setMenu()
        {

            list_menu.Items.Clear();
            list_menu.Columns.Clear();
            list_menu.Columns.Add("", 20);
            list_menu.Columns.Add("Name", 80);
            list_menu.Columns.Add("Preis", 60);

            foreach (MenuItem menuItem in Data.MenuItems)
            {

                ListViewItem listViewItem = new ListViewItem(menuItem.Nummer);
                listViewItem.SubItems.Add(menuItem.Name);
                listViewItem.SubItems.Add(menuItem.Price.ToString("C"));


                list_menu.Items.Add(listViewItem);
            }
        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            steuerung.safeOrder("1");
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            steuerung.safeOrder("2");
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            steuerung.safeOrder("3");
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            steuerung.safeOrder("4");
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            steuerung.safeOrder("5");
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            steuerung.safeOrder("6");
        }

        private void btn_7_Click(object sender, EventArgs e)
        {
            steuerung.safeOrder("7");
        }

        private void btn_8_Click(object sender, EventArgs e)
        {
            steuerung.safeOrder("8");
        }

        private void btn_9_Click(object sender, EventArgs e)
        {
            steuerung.safeOrder("9");
        }

        private void btn_pay_Click(object sender, EventArgs e)
        {
            decimal balance = Steuerung.GetBalanceById(steuerung.getId());
            if (steuerung.getRegistered())
            {
                

                if (oredered == false)
                {
                    seeMenu();
                    btn_dismiss.Enabled = false;
                    txt_Id.ReadOnly = true;
                }
                else
                {
                    if (balance >= getTotalCost())
                    {
                        pay();
                        reset();
                        oredered = false;
                    }
                    else
                    {
                        MessageBox.Show("Nicht genügend Guthaben");
                        oredered = false;
                    }
                }
                
                
            
            }
            else
            {
                MessageBox.Show("Bitte geben Sie eine gültige ID ein");
            }

        }

        private void seeMenu()
        {
            list_menu.Items.Clear();
            list_menu.Columns.Clear();
            list_menu.Columns.Add("", 110);
            list_menu.Columns.Add("", 60);
            oredered = true;
            btn_pay.Text = "Zahlen";
            lbl_menu.Text = "Warenkorb";



            foreach (OrderGen order in steuerung.Order)
            {
                MenuItem menuItem = Data.MenuItems.Find(menuItem => menuItem.Nummer == order.Id);
                ListViewItem listViewItem = new ListViewItem(order.count.ToString() + "x " + menuItem.Name);

                listViewItem.SubItems.Add((menuItem.Price * order.count).ToString("C"));

                list_menu.Items.Add(listViewItem);

                totalCost += menuItem.Price * order.count;
            }

            
            list_menu.Items.Add(new ListViewItem(new string[] { "--------------------", "---------", "" }));

            
            ListViewItem totalCostItem = new ListViewItem("Gesamtkosten:");
            totalCostItem.SubItems.Add(totalCost.ToString("C"));
            list_menu.Items.Add(totalCostItem);
            list_menu.Scrollable = true;
        }

        private void pay()
        {
            decimal balance = Steuerung.GetBalanceById(steuerung.getId());
            steuerung.UpdateBalance(steuerung.getId(), balance - getTotalCost());
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void btn_dismiss_Click(object sender, EventArgs e)
        {
            steuerung.deleteOrder();
        }

        private void reset()
        {
            steuerung.deleteOrder();
            totalCost = 0;
            txt_Id.Text = "";
            txt_status.Text = "";
            txt_bal.Text = "";
            btn_pay.Text = "Zum Zahlen";
            lbl_menu.Text = "Speisekarte";
            txt_Id.ReadOnly = false;
            setMenu();

        }
    }
}
