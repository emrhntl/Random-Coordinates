/*
 * Author:Emirhan ETLİ
 * Date created: 3/12/2022
 * This script generates the desired number of random coordinates from within the rectangular area created by the
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Random_Coordinates
{
    public partial class RandomCoordinates : Form
    {
        public RandomCoordinates()
        {
            InitializeComponent();
        }
        int coorCount = 0;//this is the global variable that holds the Random number of coordinates
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Random Coordinates";
            grpbxEast.Text = "Larger Meridian Value";
            grpbxWest.Text = "Smaller Meridian Value";
            grpbxNorth.Text = "Larger Paralelle Value";
            grpbxSouth.Text = "Smaller Paralelle Value";
            AcceptButton = btnCalculate;
        }
        private void randomCoor(Coordinate coor1,Coordinate coor2,ListBox lst)
        {
            double coor1Millisec = convertToMillisec(coor1.degree, coor1.minute, coor1.second, coor1.milliSecond);// A coordinate entered as a parameter has a millisecond total millisecond value.
            double coor2Millisec = convertToMillisec(coor2.degree, coor2.minute, coor2.second, coor2.milliSecond);
            Random rnd = new Random();
            Coordinate newCoor = new Coordinate();
            /*
             A random millisecond value is created between the millisecond values of the entered parameters,
            and this random millisecond is assigned to the convertToCoor function to be converted into a coordinate.
            As a result of this value assigned, the convertToCoor function returns an object from the Coordinates class.
            We assign this returned value to newCoor.*/
            newCoor = convertToCoor(rnd.Next((int)coor1Millisec, (int)coor2Millisec + 1));
            //We also add the new coordinate to the values listed in the listbox
            lst.Items.Add(coorCount + "-> " + newCoor.degree + "° " + newCoor.minute + "' " + newCoor.second + ". " + newCoor.milliSecond + "''");
        }
        private double convertToMillisec(double coorDegree,double coorMinute, double coorSecond, double coorMillisec)
        {
            /*
             Multiplying the degrees of the coordinate by 60 gives us the value of the degrees of the coordinate in minutes.
             We add this value we found with the minute value of the coordinate. When we multiply the new minute value created by 60,
             it gives us the value of the new minute in seconds. We sum this second with the second value of the coordinate.
             When we multiply the new second created by 60, it gives us the split second value of the second.
             We add the split second value of the coordinate and the split second value we found. As a result,
             we find the value of the entered coordinate from the split second type.
             */
            return (coorSecond+(60*((coorDegree*60)+coorMinute)))*60 + coorMillisec;
        }
        private Coordinate convertToCoor(double milliSec)
        {
            Coordinate newCoor = new Coordinate();
            newCoor.degree = Math.Round((((milliSec / 60) / 60) / 60),MidpointRounding.ToNegativeInfinity);//When we divide the split second by 60 three times, the integer part of the number gives us the degree.
            milliSec = milliSec - ((((newCoor.degree)*60)*60)*60);//We subtract the split second value of the degree we just found from the split second value.
            if (milliSec >= 3600)
            {
                //We divide the remaining split second by 60 twice. The integer part of the resulting number gives us the minute value.
                newCoor.minute = Math.Round(((milliSec / 60) / 60), MidpointRounding.ToNegativeInfinity);
            }
            milliSec = milliSec - (((newCoor.minute) * 60) * 60);//We substract the split second equivalent of the minute we find from the total split second value
            if (milliSec >= 60)
            {
                //When we divide the remaining split second value by 60, the integer part of the number we find gives us the second.
                newCoor.second = Math.Round((milliSec / 60), MidpointRounding.ToNegativeInfinity);
            }
            milliSec = milliSec - ((newCoor.second) * 60);//We subtract the split second value of the minute we found, from the remaining total split second value.
            newCoor.milliSecond = milliSec;//The remaining split second is the split second value of our coordinate.
            return newCoor;
        }
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            int loop = int.Parse(nmrcNumberOfCoor.Text);//We convert the number of coordinates to be created input entered by the user into an integer value and rotate the loop by that number.
            for (int i = 0; i <loop; i++)
            {
                try
                {
                    //We create coordinates from the Coordinate class and assign the values entered by the user to the created coordinates.
                    Coordinate westCoor = new Coordinate();
                    westCoor.degree = Convert.ToDouble(nmrcWestDegree.Text);
                    westCoor.minute = Convert.ToDouble(nmrcWestMinute.Text);
                    westCoor.second = Convert.ToDouble(nmrcWestSecond.Text);
                    westCoor.milliSecond = Convert.ToDouble(nmrcWestSplitSec.Text);
                    Coordinate eastCoor = new Coordinate();
                    eastCoor.degree = Convert.ToDouble(nmrcEastDegree.Text);
                    eastCoor.minute = Convert.ToDouble(nmrcEastMinute.Text);
                    eastCoor.second = Convert.ToDouble(nmrcEastSecond.Text);
                    eastCoor.milliSecond = Convert.ToDouble(nmrcEastSplitSec.Text);
                    Coordinate southCoor = new Coordinate();
                    southCoor.degree = Convert.ToDouble(nmrcSouthDegree.Text);
                    southCoor.minute = Convert.ToDouble(nmrcSouthMinute.Text);
                    southCoor.second = Convert.ToDouble(nmrcSouthSecond.Text);
                    southCoor.milliSecond = Convert.ToDouble(nmrcSouthSplitSec.Text);
                    Coordinate northCoor = new Coordinate();
                    northCoor.degree = Convert.ToDouble(nmrcNorthDegree.Text);
                    northCoor.minute = Convert.ToDouble(nmrcNorthMinute.Text);
                    northCoor.second = Convert.ToDouble(nmrcNorthSecond.Text);
                    northCoor.milliSecond = Convert.ToDouble(nmrcNorthSplitSec.Text);
                    //Since the millisecond equivalent of the smaller meridian value must be less than the millisecond equivalent of the larger meridian value, we checked for this condition.  
                    if (convertToMillisec(westCoor.degree, westCoor.minute, westCoor.second, westCoor.milliSecond) < convertToMillisec(eastCoor.degree, eastCoor.minute, eastCoor.second, eastCoor.milliSecond))
                    {
                        //Also, since the millisecond equivalent of the larger parallel value must be greater than the millisecond equivalent of the smaller parallel value, we checked this.
                        if (convertToMillisec(southCoor.degree, southCoor.minute, southCoor.second, southCoor.milliSecond) < convertToMillisec(northCoor.degree, northCoor.minute, northCoor.second, northCoor.milliSecond))
                        {
                            //If the magnitude comparison of the values is correct, then two random coordinates are generated.
                            coorCount++;
                            randomCoor(westCoor, eastCoor, lstbxEastWest);
                            randomCoor(southCoor, northCoor, lstbxNorthSo);
                        }
                        else
                        {
                            MessageBox.Show("The south coordinate must be smaller than the north coordinate!", "Warning!");
                            break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("The west coordinate must be smaller than the east coordinate!", "Warning!");
                        break;
                    }
                }
                catch
                {
                    MessageBox.Show("Please check the coordinate values ​​you entered!", "Warning!");
                    break;
                }
            }
        }
    }
}
