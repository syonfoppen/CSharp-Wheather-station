using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeerStation
{
    class Menu
    {
        private WeekMetingOverzicht weekMeting = new WeekMetingOverzicht();
        private JaarMetingOverzicht jaarmeting = new JaarMetingOverzicht();
        public void Start()
        {

            try
            {
                Console.Clear();
                Console.WriteLine("WEERSTATION MENU");
                Console.WriteLine("1 - Voeg een meting toe");
                Console.WriteLine("2 - WeekOverzicht");
                Console.WriteLine("3 - JaarOverzicht");
                Console.WriteLine("4 - Reset All");
                Console.WriteLine("5 - Bewerk een meting");
                Console.WriteLine("6 - Vull het hele jaar (debug)");
                Console.WriteLine("=============================");
                Console.Write("\nVoer een optie in (1 - 4): ");

                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        AddMeting();
                        break;

                    case 2:
                        WeekOverzicht();
                        break;

                    case 3:
                        JaarOverzicht();
                        break;
                    case 4:
                        Reset();
                        break;
                    case 5:
                        BewerkMeting();
                        break;
                    case 6:
                        FillYear();
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;

                    default:
                        throw new System.ArgumentException("Dit is geen optie");
                        
                }
            }
            catch (Exception error)
            {
                Console.Clear();
                Console.WriteLine(error.Message);
                Console.WriteLine("Druk op enter om terug te gaan naar het menu");
                Console.ReadLine();
                Start();
            }
        }

        private void AddMeting()
        {
                Console.Clear();
                Console.Write("\nVoer de datum van deze meting in: ");
                DateTime datum = DateTime.Parse(Console.ReadLine());
                Console.Write("\nVoer de Tempratuur van deze meting in: ");
                float temp = float.Parse(Console.ReadLine());


                DagTempMeting meting = new DagTempMeting { _Date = datum, Temp = temp  };

                if (weekMeting.WeekNr == meting.WeekNr)
                {

                    weekMeting.Add(meting);
                    
                }
                else
                {
                    if (jaarmeting.Jaar == weekMeting.Jaar)
                    {
                        jaarmeting.Add(weekMeting);
                        weekMeting = new WeekMetingOverzicht();
                        weekMeting.Add(meting);
                    }
                    else
                    {
                        jaarmeting = new JaarMetingOverzicht();
                        jaarmeting.Add(weekMeting);
                    }
                }
                Console.WriteLine("Uw Meting is toegevoeg! Druk op enter om terug te gaan naar het menu");
                Console.ReadLine();
                Start();
                

  

        }
        private void Maandoverzith()
        {

        }

        private void WeekOverzicht()
        {
                Console.Clear();

                Console.WriteLine("Week Menu");
                Console.WriteLine("1 - Bekijk Deze week");
                Console.WriteLine("2 - Selecteer een week");
                Console.WriteLine("3 - Ga terug naar het hoofd menu");
                Console.WriteLine("=============================");
                Console.Write("\nVoer een optie in (1 - 3): ");

                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("De Gemmidelde tempratuur van deze week is: {0}", weekMeting.Avgtemp);
                        Console.WriteLine("De Hoogste tempratuur van deze week is: {0}", weekMeting.MaxTemp);
                        Console.WriteLine("De Laagste tempratuur van deze week is: {0}", weekMeting.MinTemp);
                        Console.WriteLine("====================================================================");
                        Console.WriteLine("Druk op enter om het hele week overzicht te zien");
                        Console.ReadLine();


                        foreach (DagTempMeting meting in weekMeting.Metingen)
                        {
                            Console.WriteLine("Datum: {0}", meting._Date);
                            Console.WriteLine("Dag: {0}", meting.Dag);
                            Console.WriteLine("Week: {0}", meting.WeekNr);
                            Console.WriteLine("Temp: {0}", meting.Temp);
                            Console.WriteLine("==================================");
                        }
                        Console.WriteLine("Druk op enter om terug te gaan naar het menu");
                        Console.ReadLine();
                        WeekOverzicht();
                        break;

                    case 2:
                        if (jaarmeting.Metingen.Count > 0)
                        {
                            Console.Clear();
                            Console.WriteLine("De beschikbare weken zijn:");
                            foreach (WeekMetingOverzicht meting in jaarmeting.Metingen)
                            {
                                Console.WriteLine("Week {0}", meting.WeekNr);
                            }


                            Console.Write("Kies een week: ");
                            int weeknummer = Convert.ToInt32(Console.ReadLine());
                            Console.Clear();
                            foreach (WeekMetingOverzicht meting in jaarmeting.Metingen)
                            {
                                if (meting.WeekNr == weeknummer)
                                {
                                    Console.WriteLine("Week: {0} - Jaar: {1}", meting.WeekNr, meting.Jaar);
                                    Console.WriteLine("De Gemmidelde tempratuur van week {0} was: {1}", weeknummer ,weekMeting.Avgtemp);
                                    Console.WriteLine("De Hoogste tempratuur van week {0} was: {1}", weeknummer , weekMeting.MaxTemp);
                                    Console.WriteLine("De Laagste tempratuur van week {0} was: {1}", weeknummer, weekMeting.MinTemp);
                                    Console.WriteLine("====================================================================");
                                    Console.WriteLine("Druk op enter om het hele week overzicht van week {0} te zien", weeknummer);
                                    Console.ReadLine();


                                    foreach (DagTempMeting metingweek in meting.Metingen)
                                    {
                                        Console.WriteLine("Datum: {0}", metingweek._Date);
                                        Console.WriteLine("Dag: {0}", metingweek.Dag);
                                        Console.WriteLine("Week: {0}", metingweek.WeekNr);
                                        Console.WriteLine("Temp: {0}", metingweek.Temp);
                                        Console.WriteLine("==================================");

                                    }
                                    Console.WriteLine("Druk op enter om terug te gaan naar het menu");
                                    Console.ReadLine();
                                    WeekOverzicht();
                                }
                            }
                            throw new System.ArgumentException("We hebben helaas geen gegevens van deze week kunnen vinden");
                        }
                        else
                        {
                            throw new System.ArgumentException("Er zijn niet genoeg gegevens om dit weer tegeven");
                           
                        }

                    case 3:
                        Start();
                        break;

                    default:
                        throw new System.ArgumentException("Dit is geen optie");
                }

        }

        private void JaarOverzicht()
        {
            if (jaarmeting.Metingen.Count > 0)
            {
                Console.Clear();
                Console.WriteLine("De Gemmidelde tempratuur van {0} is: {1}",jaarmeting.Jaar ,jaarmeting.Avgtemp);
                Console.WriteLine("De Hoogste tempratuur van {0} is: {1}", jaarmeting.Jaar ,jaarmeting.MaxTemp);
                Console.WriteLine("De Laagste tempratuur van {0} is: {1}", jaarmeting.Jaar ,jaarmeting.MinTemp);
                Console.WriteLine("====================================================================");
                Console.WriteLine("Druk op enter om het hele week overzicht te zien");
                Console.ReadLine();


                foreach (WeekMetingOverzicht meting in jaarmeting.Metingen)
                {
                    if (meting.WeekNr != 0)
                    {
                        Console.WriteLine("Week: {0}", meting.WeekNr);
                        Console.WriteLine("Avg Temp: {0}", meting.Avgtemp);
                        Console.WriteLine("Max Temp: {0}", meting.MaxTemp);
                        Console.WriteLine("Min Temp: {0}", meting.MinTemp);
                        Console.WriteLine("==================================");
                    }

                }
                Console.WriteLine("Druk op enter om terug te gaan naar het menu");
                Console.ReadLine();
                Start();
            }
            else
            {
                throw new System.ArgumentException("Er zijn niet genoeg gegevens om dit weer tegeven");
            }

        }

        private void FillYear()
        {
                weekMeting = new WeekMetingOverzicht();
                jaarmeting = new JaarMetingOverzicht();
                
                DateTime startDate = new DateTime(2019, 1, 1);
                Random randomProvier = new Random();


                for (int i = 0; i < 14; i++)
                {


                    DagTempMeting meting = new DagTempMeting { _Date = startDate, Temp = randomProvier.Next(-20, 46) };
                    if (weekMeting.WeekNr == meting.WeekNr)
                    {
                        weekMeting.Add(meting);
                    

                    }
                    else
                    {
                        if (jaarmeting.Jaar == weekMeting.Jaar)
                        {
                            jaarmeting.Add(weekMeting);
                            weekMeting = new WeekMetingOverzicht();
                            weekMeting.Add(meting);
                        }
                        else
                        {
                            jaarmeting = new JaarMetingOverzicht();
                            jaarmeting.Add(weekMeting);
                        }
                    }
                    startDate = startDate.AddDays(1);
                }
                Start();
            
            

        }
        public void BewerkMeting()
        {
            Console.Clear();
            Console.Write("\nSelecteer een week die je wilt bewerken: ");
            int week = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.Write("\nSelecteer een dag die je wilt bewerken (1 - 7): ");

            int dag = Convert.ToInt32(Console.ReadLine());
            if( dag == 7)
            {
                dag = 0;
            }

            if (jaarmeting.Metingen.Count <= 1)
            {
                foreach (DagTempMeting dagmeting in weekMeting.Metingen)
                {
                    if (Convert.ToInt32(dagmeting.Dag) == dag)
                    {
                        Console.Clear();
                        Console.WriteLine("De tempratuur van deze dag is: {0}", dagmeting.Temp);
                        Console.WriteLine("====================================================================");
                        Console.Write("\nVoer de nieuwe tempratuur in: ");
                        dagmeting.Temp = float.Parse(Console.ReadLine());
                        Console.Clear();
                        Console.WriteLine("De dag is aangepast! druk op enter om terug te gaan naar het menu");
                        Console.ReadLine();


                        Start();

                    }
                }
            }
            else
            {
                foreach (WeekMetingOverzicht meting in jaarmeting.Metingen)
                {
                    if (meting.WeekNr == week)
                    {
                        foreach (DagTempMeting dagmeting in meting.Metingen)
                        {
                            if (Convert.ToInt32(dagmeting.Dag) == dag)
                            {
                                Console.Clear();
                                Console.WriteLine("De tempratuur van deze dag is: {0}", dagmeting.Temp);
                                Console.WriteLine("====================================================================");
                                Console.Write("\nVoer de nieuwe tempratuur in: ");
                                dagmeting.Temp = float.Parse(Console.ReadLine());
                                Console.Clear();
                                Console.WriteLine("De dag is aangepast! druk op enter om terug te gaan naar het menu");
                                Console.ReadLine();
                                Start();

                            }
                        }
                    }
                }
            }
            throw new System.ArgumentException("We hebben helaas geen gegevens van deze week kunnen vinden");

        }


        private void Reset()
        {
            Console.Clear();
            Console.WriteLine("Weet je zeker dat je de applicatie wil resetten? (ja/nee)");

            switch (Console.ReadLine())
            {
                case "ja":
                    jaarmeting = new JaarMetingOverzicht();
                    weekMeting = new WeekMetingOverzicht();
                    Start();
                    break;

                case "nee":
                    Start();
                    break;

                default:
                    throw new System.ArgumentException("Dit is geen optie");
            }
        }
    }
}
