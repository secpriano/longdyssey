namespace UIL
{
    public partial class UserAdmin : Form
    {
        readonly UserContainer c = new();

        public UserAdmin()
        {
            InitializeComponent();
        }

        private void ButtonCreateUser_Click(object sender, EventArgs e)
        {
            c.Create(textBoxFirstName.Text, textBoxLastName.Text, textBoxEmail.Text, textBoxPassword.Text, (long)numericUpDownSpaceMiles.Value);
        }            
                     
        private void ButtonUpdateUser_Click(object sender, EventArgs e)
        {
            c.Update((long)numericUpDownId.Value, textBoxFirstName.Text, textBoxLastName.Text, textBoxEmail.Text, textBoxPassword.Text, (long)numericUpDownSpaceMiles.Value);
        }

        private void ButtonDeleteUser_Click(object sender, EventArgs e)
        {
            c.Delete((long)numericUpDownId.Value);
        }

        private void ButtonViewOneById_Click(object sender, EventArgs e)
        {
            UserDTO[] dto = new UserDTO[1];
            dto[0] = c.GetById((long)numericUpDownId.Value);
            dataGridViewUser.DataSource = dto;
        }

        private void ButtonViewAll_Click(object sender, EventArgs e)
        {
            dataGridViewUser.DataSource = c.GetAll();
        }
    }
}
