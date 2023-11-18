using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace KarateSchoolProject
{
    public partial class Administrator : System.Web.UI.Page
    { 
        //sydney's connection string
        string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\sdeat\\Source\\Repos\\KarateSchoolProject\\App_Data\\KarateSchool.mdf;Integrated Security=True;Connect Timeout=30";
        private KarateSchoolDBDataContext dbcon;

        protected void Page_Load(object sender, EventArgs e)
        {
            dbcon = new KarateSchoolDBDataContext(connString);
            ShowAllRecords();
        }

        public void ShowAllRecords()
        {
            var MemRecords = from item in dbcon.Members
                          select item;
            MemberGridView.DataSource = MemRecords;
            MemberGridView.DataBind();

            var InstrRecords = from item in dbcon.Instructors
                          select item;
            InstructorGridView.DataSource = InstrRecords;
            InstructorGridView.DataBind();
        }

        public void RefreshData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string query1 = "SELECT [MemberFirstName], [MemberLastName], [MemberDateJoined], [MemberPhoneNumber] FROM [Member]";
                    SqlCommand cmd = new SqlCommand(query1, conn);

                    SqlDataAdapter dAdapter = new SqlDataAdapter(cmd);

                    DataSet ds = new DataSet();

                    dAdapter.Fill(ds);
                    MemberGridView.DataSource = ds.Tables[0];

                    string query2 = "SELECT[InstructorFirstName], [InstructorLastName] FROM[Instructor]";
                    SqlCommand cmd2 = new SqlCommand(query2, conn);

                    SqlDataAdapter dAdapter2 = new SqlDataAdapter(cmd2);
                    DataSet ds2 = new DataSet();
                    dAdapter2.Fill(ds2);
                    InstructorGridView.DataSource = ds2.Tables[0];

                }
            } catch (Exception ex)
            {
                
            }
        }

        protected void AssignMemberBtn_Click(object sender, EventArgs e)
        {
            
            
        }

        protected void MemberGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void AddInstructorBtn_Click1(object sender, EventArgs e)
        {
           Instructor newInstr = new Instructor();
            newInstr.InstructorFirstName = TxtInstrFirstName.Text;
            newInstr.InstructorLastName = TxtInstrLastName.Text;
            newInstr.InstructorPhoneNumber = TxtInstrPhoneNum.Text;

            dbcon.Instructors.InsertOnSubmit(newInstr);
            dbcon.SubmitChanges();
            ShowAllRecords();
        }

        protected void AddMemberBtn_Click1(object sender, EventArgs e)
        {
            Member newMember = new Member();
            newMember.MemberFirstName = TxtMemberFirstName.Text;
            newMember.MemberLastName = TxtMemberLastName.Text;
            newMember.MemberDateJoined = CalMemberDateJoined.SelectedDate;
            newMember.MemberPhoneNumber = TxtMemberPhoneNum.Text;
            newMember.MemberEmail = TxtMemberEmail.Text;

            dbcon.Members.InsertOnSubmit(newMember);
            dbcon.SubmitChanges();
            ShowAllRecords();
        }
    }
}