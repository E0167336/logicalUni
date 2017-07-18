using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace venkat
{
    
    public partial class Form1 : Form
    {
        
        int rowcount = 0;
        Movy m = new Movy();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DafestyEntities context = new DafestyEntities();
            var qry = from x in context.Movies select x;
            List<Movy> clst = qry.ToList<Movy>();
            dataGridView1.DataSource = clst;

            DafestyEntities contexts = new DafestyEntities();
            List<Movy> clsts = qry.ToList<Movy>();
            dataGridView2.DataSource = clsts;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            DafestyEntities context = new DafestyEntities();
            var qry = from x in context.Movies orderby x.MovieTitle select x ;
            List<Movy> clst = qry.ToList<Movy>();
            dataGridView1.DataSource = clst;

            DafestyEntities contexts = new DafestyEntities();
            List<Movy> clsts = contexts.Movies.OrderBy(x => x.MovieTitle).ToList();
            dataGridView2.DataSource = clsts;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DafestyEntities context = new DafestyEntities();
            var qry = from x in context.Movies orderby x.MovieTitle descending select x;
            List<Movy> clst = qry.ToList<Movy>();
            dataGridView1.DataSource = clst;

            DafestyEntities contexts = new DafestyEntities();
            List<Movy> clsts = contexts.Movies.OrderByDescending(x => x.MovieTitle).ToList();
            dataGridView2.DataSource = clsts;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DafestyEntities context = new DafestyEntities();
            var qry = from x in context.Movies
                      where x.Rating == "R"
                      select new { x.VideoCode, x.MovieTitle, x.RentalPrice };
            dataGridView1.DataSource = qry.ToList();
            dataGridView2.DataSource = context.Movies.Where(x => x.Rating == "R").Select(x => new { x.VideoCode, x.MovieTitle, x.RentalPrice}).ToList();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DafestyEntities context = new DafestyEntities();
            var qry = from x in context.Movies where x.MovieType == "Sci-fi" && x.ProducerID =="Warner" select x;
            List<Movy> clst = qry.ToList<Movy>();
            dataGridView1.DataSource = clst;

            DafestyEntities contexts = new DafestyEntities();
            List<Movy> clsts = contexts.Movies.Where(x => x.MovieType == "Sci-fi" && x.ProducerID == "Warner").ToList();
            dataGridView2.DataSource = clsts;
        }

        private void button6_Click(object sender, EventArgs e)
        {
           


            DafestyEntities context = new DafestyEntities();
            int i = context.Movies.Where(x => x.MovieType == "Action").Count();
            MessageBox.Show(i.ToString());

            DafestyEntities contexts = new DafestyEntities();
            List<Movy> clsts = contexts.Movies.Where(x => x.MovieType == "Action").ToList();
            dataGridView2.DataSource = clsts;



        }

        private void button7_Click(object sender, EventArgs e)
        {
            DafestyEntities context = new DafestyEntities();
            var qry = from x in context.Movies
                      group x by (x.MovieType) into g

                      select new { mc = g.Key, amt = g.Sum(x => x.TotalStock) };
            dataGridView1.DataSource = qry.ToList();

            dataGridView2.DataSource = context.Movies.GroupBy(x => x.MovieType).Select(x => new { mc = x.Key, amt = x.Sum(y => y.TotalStock) }).ToList();




        }

        private void button8_Click(object sender, EventArgs e)
        {
            DafestyEntities context = new DafestyEntities();
            var qry = from x in context.Movies
                      where x.MovieType == "Comedy"
                      select x;
            label1.Text = qry.Average(x => x.RentalPrice).ToString();
             label2.Text = context.Movies.Where(x => x.MovieType == "Comedy").Average(x => x.RentalPrice).ToString();


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            DafestyEntities context = new DafestyEntities();
            var qry = from x in context.Movies
                      where x.VideoCode == 5
                      select new { x.MovieTitle, x.Rating, x.Producer.ProducerName };
            dataGridView1.DataSource = qry.ToList();
            dataGridView2.DataSource = context.Movies.Where(x => x.VideoCode == 5).Select (x => new{ x.MovieTitle, x.Rating, x.Producer.ProducerName }).ToList();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DafestyEntities context = new DafestyEntities();
            var qry = from x in context.Movies
                      where x.ProducerID == "Walt"
                      select new { x.MovieTitle, x.MovieType, x.Producer.ProducerName };
            dataGridView1.DataSource = qry.ToList();
            dataGridView2.DataSource = context.Movies.Where(x => x.ProducerID == "Walt").Select(x => new { x.MovieTitle, x.MovieType, x.Producer.ProducerName }).ToList();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            DafestyEntities context = new DafestyEntities();
            var qry = from x in context.Movies
                      
                      select new { x.MovieTitle, x.MovieType, x.Producer.ProducerName,x.Rating };
            dataGridView1.DataSource = qry.ToList();
            dataGridView2.DataSource = context.Movies.Select(x => new { x.MovieTitle, x.MovieType, x.Producer.ProducerName }).ToList();       
    }

        private void button17_Click(object sender, EventArgs e)
        {      
                DafestyEntities context = new DafestyEntities();
                var ID = Convert.ToInt16(textBox2.Text);
                m = context.Movies.Where(x => x.VideoCode == ID + 1).First();
                textBox2.Text = m.VideoCode.ToString();
                textBox3.Text = m.MovieTitle;
                textBox4.Text = m.MovieType;
                textBox5.Text = m.RentalPrice.ToString();
            
           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            DafestyEntities context = new DafestyEntities();
            m = context.Movies.Select(x => x).First();
            textBox2.Text = m.VideoCode.ToString();
            textBox3.Text = m.MovieTitle;
            textBox4.Text = m.MovieType;
            textBox5.Text = m.RentalPrice.ToString();

        }

        private void button13_Click(object sender, EventArgs e)
        {
            DafestyEntities context = new DafestyEntities();
            var id = Convert.ToInt16(textBox2.Text);
            m = context.Movies.Where(x => x.VideoCode == id).First();
            m.MovieTitle = textBox3.Text;
            m.MovieType = textBox4.Text;
            m.RentalPrice = float.Parse(textBox5.Text.ToString());

            context.SaveChanges();


        }

        private void button14_Click(object sender, EventArgs e)
        {
            DafestyEntities context = new DafestyEntities();
            m.VideoCode = Convert.ToInt16(textBox2.Text);
            m.MovieTitle = textBox3.Text;
            m.MovieType = textBox4.Text;
            m.RentalPrice =float.Parse (textBox5.Text);

            context.Movies.Add(m);
            context.SaveChanges();

        }

        private void button15_Click(object sender, EventArgs e)
        {
            DafestyEntities context = new DafestyEntities();

            var id = Convert.ToInt16(textBox2.Text);
            m = context.Movies.Where(x => x.VideoCode == id).First();

            context.Movies.Remove(m);
            context.SaveChanges();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            DafestyEntities context = new DafestyEntities();
            var ID = Convert.ToInt16(textBox1.Text);
            m = context.Movies.Where(x => x.VideoCode == ID).First();
            textBox2.Text = m.VideoCode.ToString();
            textBox3.Text = m.MovieTitle;
            textBox4.Text = m.MovieType;
            textBox5.Text = m.RentalPrice.ToString();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            var ID = Convert.ToInt16(textBox2.Text);
            if (ID != 1)
            {
                 
                DafestyEntities context = new DafestyEntities();
                m = context.Movies.Where(x => x.VideoCode == ID - 1).First();
                textBox2.Text = m.VideoCode.ToString();
                textBox3.Text = m.MovieTitle;
                textBox4.Text = m.MovieType;
                textBox5.Text = m.RentalPrice.ToString();
            }
            else
            {
                MessageBox.Show("Dont Press More");
            }
            }

        private void button18_Click(object sender, EventArgs e)
        {
            DafestyEntities context = new DafestyEntities();
            m = context.Movies.OrderBy(x => x.VideoCode).First();
            textBox2.Text = m.VideoCode.ToString();
            textBox3.Text = m.MovieTitle;
            textBox4.Text = m.MovieType;
            textBox5.Text = m.RentalPrice.ToString();


        }

        private void button19_Click(object sender, EventArgs e)
        {
            
            DafestyEntities context = new DafestyEntities();
            m = context.Movies.OrderByDescending(x => x.VideoCode).First();
            textBox2.Text = m.VideoCode.ToString();
            textBox3.Text = m.MovieTitle;
            textBox4.Text = m.MovieType;
            textBox5.Text = m.RentalPrice.ToString();
        }
    }
}
