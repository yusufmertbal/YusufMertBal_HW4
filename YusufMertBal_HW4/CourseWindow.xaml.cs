using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace YusufMertBal_HW4
{
    /// <summary>
    /// Interaction logic for CourseWindow.xaml
    /// </summary>
    public partial class CourseWindow : Window
    {
        public CourseWindow()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Course course = new Course();
            course.Cname = txtCourseName.Text;
            course.Code = Int32.Parse(txtCourseCode.Text);
            course.Capacity = Int32.Parse(txtCourseCapacity.Text);
            course.Credit = Int32.Parse(txtCourseCredit.Text);




            CetDb db = new CetDb();
            db.Courses.Add(course);

            db.SaveChanges();
            MessageBox.Show("Ders Kaydedildi.");
            //lblStudentId.Content = "";
            txtCourseName.Text= "";
            txtCourseCode.Text = "";
            txtCourseCredit.Text = "";
            txtCourseCapacity.Text = "";
            LoadCourses();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Course course = dgCourses.SelectedItem as Course;
            if (course != null)
            {
                CetDb db = new CetDb();
                db.Courses.Remove(course);
                db.SaveChanges();
                MessageBox.Show("Ders Silindi!");
                LoadCourses();

            }
            else
            {
                MessageBox.Show("Silmek için ders seçmelisin!");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Course course = dgCourses.SelectedItem as Course;
            if (course != null)
            {
                CetDb db = new CetDb();
                var coursenew = db.Courses.Find(course.ID);
                coursenew.Cname = txtCourseName.Text;
                coursenew.Code = Int32.Parse(txtCourseCode.Text);
                coursenew.Capacity = Int32.Parse(txtCourseCapacity.Text);
                coursenew.Credit = Int32.Parse(txtCourseCredit.Text);
                db.SaveChanges();
                LoadCourses();
                MessageBox.Show("Güncellendi.");
            }
            else
            {
                MessageBox.Show("güncellemek için öğrenci seçmelisin!");
            }
        }

        private void dgCourses_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            Course course = dgCourses.SelectedItem as Course;
            if (course != null)
            {
                
                txtCourseName.Text = course.Cname;
                txtCourseCode.Text = Convert.ToString(course.Code);
                txtCourseCapacity.Text = Convert.ToString(course.Capacity);
                txtCourseCredit.Text = Convert.ToString(course.Credit);
            }
        }
        private void LoadCourses()
        {
            CetDb db = new CetDb();
            List<Course> courses = db.Courses.ToList();
            dgCourses.ItemsSource = courses;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCourses();
        }
    }
}
