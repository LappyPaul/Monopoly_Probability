using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly_Probability
{
    class Program
    {
        static void Main(string[] args)
        {
            Random Dice = new Random();                                             //Random class instatiate
            int intJailVisits = 0;                                                  //How many jail visits?
            int intFreeParkingVisits = 0;                                           //How many jail visits?
            int intCurrentRollNumber = 1;                                           //Of all of the rolls, how far are we?
            int intNumberOfDoubles = 0;                                             //Counts the number of doubles in a row
            double intNumberOfRolls = 100000000;
            int intBoardPosition = 0;
            int intBoardRotations = 0;

            int intBrownVisits = 0;
            int intLightBlueVisits = 0;
            int intPinkVisits = 0;
            int intOrangeVisits = 0;
            int intRedVisits = 0;
            int intYellowVisits = 0;
            int intGreenVisits = 0;
            int intDarkBlueVisits = 0;
            int intCommunityChestVisits = 0;
            int intChanceVisits = 0;
            int intIncomeTaxVisits = 0;
            int intTrainStationVisits = 0;
            int intElectricCompanyWaterWorksVisits = 0;
            int intExactlyOnGoVisits = 0;

            //Console.WriteLine("How many rolls?");
            //double intNumberOfRolls = Convert.ToDouble(Console.ReadLine());

            while (intCurrentRollNumber <= intNumberOfRolls)
            {
                // Roll 2 dice
                int intDiceOne = Dice.Next(6) + 1;                                          //Roll the first dice
                int intDiceTwo = Dice.Next(6) + 1;                                          //And the second dice

                if (intDiceOne == intDiceTwo)
                {
                    intNumberOfDoubles += 1;                                                //If we get a double, add 1 to the count
                    if (intNumberOfDoubles == 3)                                            //3 doubles in a row is jail
                    {
                        intJailVisits += 1;                                                 //Sent to jail count increased by 1
                        intNumberOfDoubles = 0;                                             //Then reset the count of doubles back to 0
                    }
                }
                else
                {
                    int intTotalDice = intDiceOne + intDiceTwo;                             //Add the dice up and move

                    intBoardPosition += intTotalDice;

                    if (intBoardPosition > 39)                                              //If we get back to Go (i.e. a complete board roation)
                    {
                        intBoardPosition = intBoardPosition - 40; //+ intTotalDice;
                        intBoardRotations += 1;                                             //Increment the number of board rotations by 1
                    }

                    //if (intBoardPosition == 30)                                           //If we land on the jail square, increment the jail count by 1
                    //{
                    //    intJailVisits += 1;
                    //}

                    switch (intBoardPosition)
                    {
                        case 30:
                            intJailVisits += 1;                                             //If we land on the jail square, increment the jail count by 1
                            intBoardPosition = 10;                                          //and move the piece into Jail
                            break;

                        case 20:
                            intFreeParkingVisits += 1;                                      //If we land on the Free Parking square, increment the Free Parking count by 1
                            break;

                        case 1:
                        case 3:
                            intBrownVisits += 1;
                            break;

                        case 6:
                        case 8:
                        case 9:
                            intLightBlueVisits += 1;
                            break;

                        case 11:
                        case 13:
                        case 14:
                            intPinkVisits += 1;
                            break;

                        case 16:
                        case 18:
                        case 19:
                            intOrangeVisits += 1;
                            break;

                        case 21:
                        case 23:
                        case 24:
                            intRedVisits += 1;
                            break;

                        case 26:
                        case 27:
                        case 29:
                            intYellowVisits += 1;
                            break;

                        case 31:
                        case 32:
                        case 34:
                            intGreenVisits += 1;
                            break;

                        case 37:
                        case 39:
                            intDarkBlueVisits += 1;
                            break;

                        case 5:
                        case 15:
                        case 25:
                        case 35:
                            intTrainStationVisits += 1;
                            break;

                        case 4:
                        case 38:
                            intIncomeTaxVisits += 1;
                            break;

                        case 2:
                        case 17:
                        case 33:
                            intCommunityChestVisits += 1;
                            break;

                        case 7:
                        case 22:
                        case 36:
                            intChanceVisits += 1;
                            break;

                        case 0:
                            intExactlyOnGoVisits += 1;
                            break;

                        case 12:
                        case 28:
                            intElectricCompanyWaterWorksVisits += 1;
                            break;

                    }

                    //intBoardPosition += intTotalDice;

                    intNumberOfDoubles = 0;                                                 //If the dice don't match, don't count it as a double
                }
                intCurrentRollNumber += 1;                                                  //But still add on 1 to the number of throws off the dice
            }
            intCurrentRollNumber -= 1;

            double intTotalSquares = (intBrownVisits + intLightBlueVisits + intPinkVisits + intOrangeVisits + intRedVisits + intYellowVisits + 
                                      intGreenVisits + intDarkBlueVisits + intTrainStationVisits + intElectricCompanyWaterWorksVisits + intIncomeTaxVisits + 
                                      intCommunityChestVisits + intChanceVisits + intFreeParkingVisits + intJailVisits);

            Console.WriteLine("");
            Console.WriteLine("Number of dice rolls: " + intCurrentRollNumber.ToString("N0"));
            Console.WriteLine("Number of complete visits around the board: " + intBoardRotations.ToString("N0"));
            Console.WriteLine("");
            Console.WriteLine("Colour\t\t\t\t\tVisits\t\t\tPercentage");
            Console.WriteLine("-------\t\t\t\t\t------\t\t\t----------");
            Console.WriteLine("Brown: \t\t\t\t\t" + intBrownVisits.ToString("N0") + "\t\t" + Math.Round(intBrownVisits / intTotalSquares * 100, 2) + "%");
            Console.WriteLine("Light Blue: \t\t\t\t" + intLightBlueVisits.ToString("N0") + "\t\t" + Math.Round(intLightBlueVisits / intTotalSquares * 100, 2) + "%");
            Console.WriteLine("Pink: \t\t\t\t\t" + intPinkVisits.ToString("N0") + "\t\t" + Math.Round(intPinkVisits / intTotalSquares * 100, 2) + "%");
            Console.WriteLine("Orange: \t\t\t\t" + intOrangeVisits.ToString("N0") + "\t\t" + Math.Round(intOrangeVisits / intTotalSquares * 100, 2) + "%");
            Console.WriteLine("Red: \t\t\t\t\t" + intRedVisits.ToString("N0") + "\t\t" + Math.Round(intRedVisits / intTotalSquares * 100, 2) + "%");
            Console.WriteLine("Yellow: \t\t\t\t" + intYellowVisits.ToString("N0") + "\t\t" + Math.Round(intYellowVisits / intTotalSquares * 100, 2) + "%");
            Console.WriteLine("Green: \t\t\t\t\t" + intGreenVisits.ToString("N0") + "\t\t" + Math.Round(intGreenVisits / intTotalSquares * 100, 2) + "%");
            Console.WriteLine("Dark Blue: \t\t\t\t" + intDarkBlueVisits.ToString("N0") + "\t\t" + Math.Round(intDarkBlueVisits / intTotalSquares * 100, 2) + "%");
            Console.WriteLine("Train Stations: \t\t\t" + intTrainStationVisits.ToString("N0") + "\t\t" + Math.Round(intTrainStationVisits / intTotalSquares * 100, 2) + "%");
            Console.WriteLine("Electric Company / Water Works: \t" + intElectricCompanyWaterWorksVisits.ToString("N0") + "\t\t" + Math.Round(intElectricCompanyWaterWorksVisits / intTotalSquares * 100, 2) + "%");
            Console.WriteLine("");
            Console.WriteLine("Special squares");
            Console.WriteLine("---------------");
            Console.WriteLine("Income Tax: " + "\t\t\t\t" + intIncomeTaxVisits.ToString("N0") + "\t\t" + Math.Round(intIncomeTaxVisits / intTotalSquares * 100, 2) + "%");
            Console.WriteLine("Community Chest: " + "\t\t\t" + intCommunityChestVisits.ToString("N0") + "\t\t" + Math.Round(intCommunityChestVisits / intTotalSquares * 100, 2) + "%");
            Console.WriteLine("Chance: " + "\t\t\t\t" + intChanceVisits.ToString("N0") + "\t\t" + Math.Round(intChanceVisits / intTotalSquares * 100, 2) + "%");
            Console.WriteLine("Free Parking visits: " + "\t\t\t" + intFreeParkingVisits.ToString("N0") + "\t\t" + Math.Round(intFreeParkingVisits / intTotalSquares * 100, 2) + "%");
            Console.WriteLine("Jail visits: " + "\t\t\t\t" + intJailVisits.ToString("N0") + "\t\t" + Math.Round(intJailVisits / intTotalSquares * 100, 2) + "%");
            //Console.WriteLine("Number of times landed exactly on Go: " + intExactlyOnGoVisits.ToString("N0"));
            Console.ReadLine();
        }
    }
}
