using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
namespace ClassRegistrationApp
{
     public partial class ClassSelectionForm : Form
     {
            string strRegistration;
            public Student currentStudent;
            public User currentUser;
            public int idxRegistration;
            LoginForm ParentForm;
            public ClassSelectionForm()
            {
                InitializeComponent();
                ParentForm = LoginForm.OriginalForm;

                foreach (Course obj in ParentForm.CourseList)
                    lstCourseList.Items.Add(obj.CourseName);

                rtxtRegistrationInfo.Text = "";
            }



        public void SetCurrentUser(User user)
        {
            currentUser = user;
            currentStudent = ParentForm.StudentList.Find(x => (x.StudentID == currentUser.StudentID));

            idxRegistration = ParentForm.StudentList.FindIndex(x => (x.StudentID == currentStudent.StudentID));
            if (idxRegistration >= 0)
            {
                foreach (Course obj in ParentForm.CourseRegList[idxRegistration].CourseEnrollList)
                {
                    int idx = lstCourseList.FindString(obj.CourseName.Trim());
                    lstCourseList.SetSelected(idx, true);
                }
            }

        }
        public string ShowRegistrationInfo()
            {
                strRegistration = "\t\t\t Course Registration of Student \n:";
                strRegistration += "___________________________________________________\n";
                strRegistration += String.Format("\tStudentID:{0}\n \tSutdent Name: {1}", currentStudent.StudentID, currentStudent.StudentName);
                int sumcredit;
                if (idxRegistration >= 0)
                    sumcredit = ParentForm.CourseRegList[idxRegistration].CalculateSumCredit();
                else
                    sumcredit = 0;

            strRegistration += String.Format("\tSum of Registration Credit:{0} \n", sumcredit);
                strRegistration += "___________________________________________________\n";
                strRegistration += "\n" + "CourseID" + "\t\t" + "Number of Credit" + "\t\t" + "Course Name";

                Course obj;
                foreach (Object selectedItem in lstCourseList.SelectedItems)
                {
                    obj = ParentForm.CourseList.Find(x => (x.CourseName == selectedItem.ToString()));
                    if (obj != null)
                    {
                        strRegistration += "\n" + obj.CourseID + "\t\t" + obj.NumCredit + "\t\t" + obj.CourseName;
                    }
                }

                rtxtRegistrationInfo.Text = strRegistration;

                return strRegistration;
            }

            private void btnAdd_Click(object sender, EventArgs e)
            {
                if (idxRegistration < 0)
                {
                    ParentForm.CourseRegList.Add(new CourseRegistration(currentStudent.StudentID));
                    idxRegistration = ParentForm.CourseRegList.FindIndex(x => (x?.StudentID == currentStudent.StudentID));

                    Course obj;
                    foreach (object selectedItem in lstCourseList.SelectedItems)
                    {
                        obj = ParentForm.CourseList.Find(x => (x.CourseName == selectedItem.ToString()));
                        ParentForm.CourseRegList[idxRegistration].CourseEnrollList.Add(obj);
                    }
                }
                ShowRegistrationInfo();
            }

            private void btnConfirm_Click(object sender, EventArgs e)
            {
                MessageBox.Show(ShowRegistrationInfo(), "Thank you", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            private void btnLogOut_Click(object sender, EventArgs e)
            {
                this.Close();
                ParentForm.ResetLogin = true;
                ParentForm.Show();
            }
            private void label1_Click(object sender, EventArgs e)
            {

            }

            private void label2_Click(object sender, EventArgs e)
            {

            }
        }

    }

