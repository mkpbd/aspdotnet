namespace EDDWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Click(object sender, EventArgs e)
        {

        }

        private void btnShow_Click(object sender, EventArgs e)
        {


          var firsttName =  txtFistName.Text;
           var lastName = txtLastName.Text;
            Address address = new Address();
            address.Name = firsttName;
            address.SecondName = lastName;
            address.Id =2;

            new DataRepository().InsertDataInDatabase(address);

            MessageBox.Show(firsttName + " " + lastName);
           
        }
    }
}