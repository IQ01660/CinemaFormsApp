using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheCinemaProblem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            FilmHolder.allFilms.Add("Anabelle");
            FilmHolder.allFilms.Add("Conjured Island");
            FilmHolder.allFilms.Add("Killer's Bodyguard");
            FilmHolder.allFilms.Add("Prestige");
            int filmTopPos = 50;
            for(int j = 0; j < 4; j++)
            {
                // new film button
                FilmHolderBtn.allFilmsBtn.Add(new Button());
                Controls.Add(FilmHolderBtn.allFilmsBtn[j]);
                FilmHolderBtn.allFilmsBtn[j].Click += new System.EventHandler(this.film_Click);
                FilmHolderBtn.allFilmsBtn[j].Text = FilmHolder.allFilms[j];
                FilmHolderBtn.allFilmsBtn[j].Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                FilmHolderBtn.allFilmsBtn[j].Left = 300;
                FilmHolderBtn.allFilmsBtn[j].Top = filmTopPos;
                FilmHolderBtn.allFilmsBtn[j].BackColor = Color.White;
                FilmHolderBtn.allFilmsBtn[j].ForeColor = Color.DarkBlue;
                FilmHolderBtn.allFilmsBtn[j].TabStop = false;
                FilmHolderBtn.allFilmsBtn[j].FlatStyle = FlatStyle.Flat;
                FilmHolderBtn.allFilmsBtn[j].FlatAppearance.BorderSize = 0;
                FilmHolderBtn.allFilmsBtn[j].FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent
                FilmHolderBtn.allFilmsBtn[j].Size = new System.Drawing.Size(400, 73);
                filmTopPos += 80;
            }
        }
        private void film_Click(object sender , EventArgs e)
        {
            Controls.Clear();
            int topPos = 10;
            int leftPos = 260;
            for (int i = 0; i < 60; i++)
            {
                // adding the button
                SeatHolderBtn.allSeatsBtn.Add(new Button());
                // adding the seat
                SeatHolder.allSeats.Add(new Seat());
                SeatHolderBtn.allSeatsBtn[i].Click += new System.EventHandler(this.seat_Click);
                Controls.Add(SeatHolderBtn.allSeatsBtn[i]);
                int seatNum = i + 1;
                SeatHolderBtn.allSeatsBtn[i].Name = "Empty";
                SeatHolderBtn.allSeatsBtn[i].Text = " " + seatNum + " ";
                SeatHolderBtn.allSeatsBtn[i].Left = leftPos;
                SeatHolderBtn.allSeatsBtn[i].Top = topPos;
                SeatHolderBtn.allSeatsBtn[i].BackColor = Color.White;
                SeatHolderBtn.allSeatsBtn[i].TabStop = false;
                SeatHolderBtn.allSeatsBtn[i].FlatStyle = FlatStyle.Flat;
                SeatHolderBtn.allSeatsBtn[i].FlatAppearance.BorderSize = 0;
                SeatHolderBtn.allSeatsBtn[i].FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent
                SeatHolderBtn.allSeatsBtn[i].Size = new System.Drawing.Size(45, 43);
                leftPos += 50;
                if (i < 20)
                {
                    if ((i + 1) % 10 == 0)
                    {
                        topPos += 60;
                        leftPos = 260;
                    }
                    if (i == 19)
                    {
                        leftPos = 310;
                    }
                }
                else
                {
                    if ((i + 1 - 20) % 8 == 0)
                    {
                        topPos += 60;
                        leftPos = 310;
                    }
                }

            }
            Button selectBtn = new Button();
            selectBtn.Text = "Select Seats";
            selectBtn.Left = 820;
            selectBtn.Top = 300;
            selectBtn.BackColor = Color.White;
            selectBtn.Click += new System.EventHandler(this.select_Click);
            Controls.Add(selectBtn);
            TextBox bill = new TextBox();
            bill.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            bill.Left = 30;
            bill.Top = 200;
            Bill.myBillOnly[0] = bill;
            Controls.Add(Bill.myBillOnly[0]);
        }
        private void select_Click(object sender , EventArgs e)
        {
               
            foreach (var item in SeatHolderBtn.allSeatsBtn)
            {
                if(item.BackColor == Color.Red)
                {
                    item.Name = "Reserved";
                    item.BackColor = Color.DarkBlue;
                   
                }
            }
            RedSeats.redSeatsCount = 0;
        }
        private void seat_Click(object sender , EventArgs e)
        {
            Button clickedSeat = sender as Button;
            if (clickedSeat.Name == "Empty")
            {
                // clickedSeat.Name = "Reserved";
                clickedSeat.BackColor = Color.Red;
                clickedSeat.ForeColor = Color.White;
                RedSeats.redSeatsCount++;
                int myTotalBill = RedSeats.redSeatsCount * 8;
                Bill.myBillOnly[0].Text = myTotalBill + " $";

            }
            else
            {
                MessageBox.Show("This Seat is already reserved");
            }
        }
    }
    class FilmHolder
    {
        static public List<string> allFilms = new List<string>();
    }
    class FilmHolderBtn
    {
        static public List<Button> allFilmsBtn = new List<Button>();
    }
    class Seat
    {
        public string status = "Empty";
    }
    class SeatHolder
    {
        static public List<Seat> allSeats = new List<Seat>();
    }
    class SeatHolderBtn
    {
        static public List<Button> allSeatsBtn = new List<Button>();
    }
    class Bill
    {
        static public TextBox[] myBillOnly = new TextBox[1];
    }
    class RedSeats
    {
        static public int redSeatsCount = 0;
    }
}
