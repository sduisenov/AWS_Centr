
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using System.Threading;
using System.Timers;
using System.Data;
using System.Data.OleDb;
using Awsd5.BusinessObjects;

namespace Awsd5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        public static List<string> numsprvag;
        public int pr11_4;
        public int pr11_5;

        private string ip_file;
        private int num_record = 0;
        // start with license
        public string sqlExpression = "Select * from lic_data";
        public string key_data;
        public string mac_data;
        public static string[] ipserver;
        public static string[] Lic;
        public static string[] ipcontroller;
        public static string connectionString;
        public static string connectionString1;
        // end with license
      //  public string connectionString1 =
          //"Data Source=SALIKH-PC\\SQLEXPRESS;Initial Catalog=awsd; Connect Timeout=120;Integrated Security=SSPI;Persist Security Info=False;Packet Size=4096";
       //  "Data Source=192.168.50.103;Initial Catalog=awsd; Connect Timeout=120;Integrated Security=SSPI;Persist Security Info=False;Packet Size=4096";
        //"Data Source=WIN-G7APJPTONBM\\SQLEXPRESS; Initial Catalog = awsd; Persist Security Info = True; User ID = sa; Password = s250099S";
        // "Data Source=SALIKH-PC\\SQLEXPRESS;Initial Catalog=awsd;Persist Security Info=True;User ID=sa;Password=12345";
        //"Data Source = WIN-G7APJPTONBM\\SQLEXPRESS;Initial Catalog=awsd; Connect Timeout=120;Integrated Security=SSPI;Persist Security Info=False;Packet Size=4096";
        public event PropertyChangedEventHandler PropertyChanged;
        public int ip_i = 0;
        private DispatcherTimer timer = null;
        private DispatcherTimer timer1 = null;
        public static int trainid4=0;
        public static int trainid5=0;

        public static int trainid1 = 0;
        public static int trainid2 = 0;
        public static int trainid3 = 0;

        public DataTable vtable4;
        public DataTable vtable5;

        public DataTable vtable1;
        public DataTable vtable2;
        public DataTable vtable3;

        public static DateTime w2time1;
        public static DateTime w2time2;
        public static DateTime w2time3;
        public static DateTime w2time4;
        public static DateTime w2time5;
        
        public static int min_speed;
        public static DateTime vn1time1;
        public static DateTime vn2time1;

        public static DateTime vn1time2;
        public static DateTime vn2time2;

        public static DateTime vn1time3;
        public static DateTime vn2time3;

        public static DateTime vn1time4;
        public static DateTime vn2time4;

        public static DateTime vn1time5;
        public static DateTime vn2time5;

        public static DateTime vntimeT;


        public static double speed_d;
        public static int speed_i;
        public static double L_Dumpcar=13.816;
        public static double L_Gondol = 14.280;
        public static double L_Lokomotiv = 18.150;
        public static double L_vagon;
        public static byte[] vid1;
        public static int Direction ;
        public static int TrainNumber ;
        //  int Trains = AddTrains(1);
        //      AddVagons(1, Trains);




        //MessageBox.Show(ipcontr[0].ToString()+"--"+ ipcontr[1].ToString());





        //            timerStart(); // Таймер по БД


        DateTime beg_date = DateTime.Now;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            CurDate.Text = beg_date.ToString();
            //start with license
            ipserver = XDocument.Load(@"..\AWSD_S_ZHOF3_set.xml").Descendants("IpServer")
                  .Select(element => element.Value).ToArray();
            ipcontroller = XDocument.Load(@"..\AWSD_S_ZHOF3_set.xml").Descendants("IpController")
                  .Select(element => element.Value).ToArray();
            Lic = XDocument.Load(@"..\AWSD_S_ZHOF3_set.xml").Descendants("License")
                      .Select(element => element.Value).ToArray();
            connectionString = "Data Source=" + ipserver[0].ToString() + ";Initial Catalog=Lic_db; Persist Security Info = True; User ID =sa; Password =s250099S";
            connectionString1 = "Data Source=" + ipserver[0].ToString() + ";Initial Catalog=awsd; Persist Security Info = True; User ID =sa; Password =s250099S";

            key_data = Lic[0];
            // end with license
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

            numsprvag = SprVagonRead();
            // запуск в автоматическом режиме
            ip_file = new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "..\\Logo_miratek.png"), UriKind.Absolute).AbsoluteUri;
            logoMiratec.Source = ImageSource;
            //sql_pr11_4(connectionString1);
            //sql_pr11_5(connectionString1);
            if (License_check() == true)
            {
                timerStart();
            }
            else
            {
                MessageBox.Show("Лицензия не активирована!");
            }


            // запуск вручсную 1 путь

            //int number = 46;
            //NumRec4.Text = "2 Путь -" + number.ToString();
            ////// number = number + 1;

            //int Trains = AddTrains2(number, 2);
            //if (Trains != 0)
            //{

            //    AddVagons2(trainid2, Trains);
            //}



        }

        private string GetMacAddress()
        {
            string macAddresses = string.Empty;

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    macAddresses += nic.GetPhysicalAddress().ToString();
                    break;
                }
            }

            return macAddresses;
        }

        private bool License_check()
        {
            mac_data = GetMacAddress();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (key_data == reader[0].ToString() && mac_data == reader[1].ToString())
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }
        }



        private void timerTick(object sender, EventArgs e)
        {
            sql_pr11_4(connectionString1);
            sql_pr11_5(connectionString1);
            AddR1();
            AddR2();
            AddR3();
            AddR4();
            AddR5();
        }


        private void timerTick1(object sender, EventArgs e)
        {
            
            //AddR1();

        }
        /*
        private void ReadVCam()
        {

            //AddR1();
            if (vtable4 != null) vtable4.Clear();

            
       //     vtable4  = LoadTableCamer4(1, "2018/08/30 22:55:42");

            for (int i=0;i< vtable4.Rows.Count; i++)
            {
                MessageBox.Show("--" + vtable4.Rows[i]["number"].ToString()+
                    "--"+ vtable4.Rows[i]["p1"].ToString()+"--" +
                    "--" + vtable4.Rows[i]["v1time"].ToString() + "--" +
                    "--" + vtable4.Rows[i]["wntime"].ToString() + "--" +
                    "--" + vtable4.Rows[i]["lineid"].ToString() + "--" +
                    "--" + vtable4.Rows[i]["Direction"].ToString() + "--" +
                    "--" + vtable4.Rows[i]["lineid"].ToString() + "--" +
                    "--" + vtable4.Rows[i]["vid1"].ToString() 
                    );
            }
        }

            */

        private void timerStart()
        {
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timerTick);
           // timer.Interval = new TimeSpan(0, 0, 0, 0, 360000); // 1 час
            timer.Interval = new TimeSpan(0, 0, 0, 0, 60000); // 60 сек
            timer.Start();

        }


        private void timerStart1()
        {
            timer1 = new DispatcherTimer();
            timer1.Tick += new EventHandler(timerTick1);
           // timer1.Interval = new TimeSpan(0, 0, 0, 0, 3600000); // 1 час
            timer1.Interval = new TimeSpan(0, 0, 0, 0, 60000); // 60 сек
            timer1.Start();

        }


        private void AddR1()
        {
            int number = LastTrainNumber(1);
            
          
            NumRec1.Text = "1 Путь -" + number.ToString();
            number = number + 1;
            int Trains = AddTrains1(number, 1);
            if (Trains != 0)
            {

                AddVagons1(trainid1, Trains);
            }

        }


        private void AddR2()
        {

            int number = LastTrainNumber(2);
            

            
            NumRec2.Text = "2 Путь -" + number.ToString();
            number = number + 1;
            int Trains = AddTrains2(number, 2);
            if (Trains != 0)
            {

                AddVagons2(trainid2, Trains);
            }

        }

        private void AddR3()
        {

            int number = LastTrainNumber(3);



            NumRec3.Text = "3 Путь -" + number.ToString();
            number = number + 1;
            int Trains = AddTrains3(number, 3);
            if (Trains != 0)
            {

                AddVagons3(trainid3, Trains);
            }

        }

        private void AddR4 ()
        {
            int number = LastTrainNumber(4);
            
           
            NumRec4.Text = "4 Путь -" + number.ToString();
            number = number + 1;
            int Trains = AddTrains4(number,4);
            if (Trains != 0)
            {

                AddVagons4(trainid4, Trains);
            }
         
        }

        private void AddR5()
        {
            
            int number = LastTrainNumber(5);
            
            
            
            NumRec5.Text = "5 Путь -" + number.ToString();
            number = number + 1;
            int Trains = AddTrains5(number,5);
            if (Trains != 0)
            {
              AddVagons5(trainid5, Trains);
            }
         }

        

        private int AddTrains1(int TrainID, int line)
        {

                       
            //string connectionString = @"Provider = Microsoft.Jet.OLEDB.4.0;  Data Source = \\WIMSYSTEM1\ARM\Tables\RRDB1_be.mdb";
            string connectionString = @"Provider = Microsoft.Jet.OLEDB.4.0;  Data Source = \\" + ipcontroller[0].ToString() + @"\ARM\Tables\RRDB1_be.mdb";
            
            string strSQL = "SELECT * FROM SourceTrains  where  TrainID =" + TrainID.ToString();
            int IdTrains = 0;
            // Create a connection  

            //MessageBox.Show("-------" + strSQL);
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                // Create a command and set its connection  
                OleDbCommand command = new OleDbCommand(strSQL, connection);
                // Open the connection and execute the select command.  
                try
                {
                    // Open connecton  
                    connection.Open();

                    // Execute command  
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {


                            try
                            {

                                BOTrail _InsertBOTrail = new BOTrail();
                                if (vtable1 != null) vtable1.Clear();

                                //MessageBox.Show("------0" + reader["TrainNumber"].ToString());
                                trainid1 = Convert.ToInt32(reader["TrainID"].ToString());
                                _InsertBOTrail.Trainid1 = Convert.ToInt32(reader["TrainNumber"].ToString());
                                _InsertBOTrail.Trainid2 = Convert.ToInt32(reader["TrainID"].ToString());
                                _InsertBOTrail.Lineid = Convert.ToInt32(reader["ScaleID"].ToString());
                                _InsertBOTrail.Pr3 = 0;
                                _InsertBOTrail.Pr2 = 0;
                                //MessageBox.Show("------1");


                                if (reader["Direction"].ToString() == "True") _InsertBOTrail.Pr1 = 1; else _InsertBOTrail.Pr1 = 0;

                                Direction = (int)_InsertBOTrail.Pr1;
                                TrainNumber = (int)_InsertBOTrail.Trainid1;

                                //MessageBox.Show("------2");
                                if (reader["When"].ToString() != "")
                                {
                                    _InsertBOTrail.W2time = DateTime.Parse((reader["When"].ToString()));
                                    w2time1 = (DateTime)_InsertBOTrail.W2time;
                                    vn1time1 = w2time1;                                                                //++++++++++
                                    _InsertBOTrail.W1time = DateTime.Now;

                                    
                                    //vtable1 = LoadTableCamer(1, _InsertBOTrail.W2time.ToString());

                                }
                                //MessageBox.Show("------3");
                                _InsertBOTrail.Operationid = 5;
                                _InsertBOTrail.Lineid = 1;
                               
                                _InsertBOTrail.SaveNew();

                              //  MessageBox.Show("------4");
                                IdTrains = Convert.ToInt32(_InsertBOTrail.Id.ToString());


                               //  MessageBox.Show(reader["TrainNumber"].ToString() + "-- -" + reader["Direction"].ToString());
                            }
                            catch (Exception ex)
                            {
                             //   MessageBox.Show(ex.Message);
                                ConnCloseOLe(connection);
                                return IdTrains;
                            }
                        }

                    }
                    connection.Close();

                }
                catch (Exception ex)
                {
                  //  MessageBox.Show(ex.Message);
                    ConnCloseOLe(connection);
                    return IdTrains;
                }

                ConnCloseOLe(connection);
                return IdTrains;
            }
        }


        void AddVagons1(int TrainID, int TrainID1)
        {
            // Connection string and SQL query  
            //string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\\WIMSYSTEM1\ARM\Tables\RRDB1_be.mdb";
            string connectionString = @"Provider = Microsoft.Jet.OLEDB.4.0;  Data Source = \\" + ipcontroller[0].ToString() + @"\ARM\Tables\RRDB1_be.mdb";

            string strSQL = "SELECT * FROM SourceVagons  where  TrainID=" + trainid1.ToString() + " order by VagonNumber desc ";
            // Create a connection  
            // MessageBox.Show("------0");
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                // Create a command and set its connection  
                OleDbCommand command = new OleDbCommand(strSQL, connection);
                // Open the connection and execute the select command.  
                try
                {
                    // Open connecton 


                    connection.Open();
                    // Execute command  

                    using (OleDbDataReader reader = command.ExecuteReader())
                    {


                        while (reader.Read())
                        {

                            try
                            {
                                //  "([TrainID],[VagonID], [VagonNumber],[VagonTypeID],[Axles],[Weight]," +
                                //   "[GVID],[WeighingModeID],[Speed]," +
                                //   "[NotUse],"   " [Tel1], [Tel2])" +
                                BOContainers _InsertContainers = new BOContainers();
                             

                                int vnumber = Convert.ToInt32(reader["VagonNumber"].ToString());

                                _InsertContainers.Number = reader["VagonNumber"].ToString();
                                //_InsertContainers.Tvagonid = Convert.ToInt32( reader["VagonNumber"].ToString());
                                int vt = Convert.ToInt32(reader["VagonTypeID"].ToString());
                                int Scale = Convert.ToInt32(reader["Axles"].ToString());

                                _InsertContainers.Pr1 = Direction;
                                _InsertContainers.Weightcount = TrainNumber;
                                _InsertContainers.W2time = w2time1;
                                
                                 speed_d = Convert.ToSingle(reader["Speed"].ToString());
                                if (vt == 1 && Scale == 6) L_vagon = L_Dumpcar;
                                if (vt == 1 && Scale == 8) L_vagon = L_Gondol;
                                if (vt == 2 && Scale == 6) L_vagon = L_Lokomotiv;
                                min_speed = Convert.ToInt32(L_vagon / ((speed_d * 1000) / 3600)) + 2;
                                vn2time1 = vn1time1.AddSeconds(-(min_speed));                                  
                                 _InsertContainers.W1time = vn2time1;                                               
                                 
                                _InsertContainers.W2scale = Convert.ToInt32(reader["Axles"].ToString());
                                _InsertContainers.Speed = Convert.ToSingle(reader["Speed"].ToString());
                                _InsertContainers.W1brutto = Convert.ToSingle(reader["Weight"].ToString());
                                _InsertContainers.Tvagonid = 6;
                                _InsertContainers.Pr3 = 0;
                                _InsertContainers.Pr2 = 0;
                                if (vt == 1 && Scale == 6)
                                {
                                    _InsertContainers.Tvagonid = 4;
                                    _InsertContainers.W1tara = pr11_4;
                                    _InsertContainers.W1netto = _InsertContainers.W1brutto - pr11_4;

                                }
                                if (vt == 1 && Scale == 8)
                                {
                                    _InsertContainers.Tvagonid = 5;
                                    _InsertContainers.W1tara = pr11_5;
                                    _InsertContainers.W1netto = _InsertContainers.W1brutto - pr11_5;
                                }
                                if (vt == 2 && Scale == 6) _InsertContainers.Tvagonid = 6;

                               
                                
                                    if (_InsertContainers.Tvagonid != 6)
                                    {
                                        string nVagon = findnumber(1, vn1time1.ToString(), vn2time1.ToString());
                                       // if (nVagon != null && numsprvag.Find((x) => x == nVagon) != null && _InsertContainers.Tvagonid == 4)
                                          if (nVagon != null && numsprvag.Find((x) => x == nVagon) != null )
                                        {
                                            _InsertContainers.Lotnumber = nVagon;
                                            _InsertContainers.Vid1 = vid1;
                                            //  _InsertContainers.W2time=vntimeT; //фактическое время прохождения вагона
                                            _InsertContainers.W2time = w2time1; //время прохождения состава
                                            if (Direction == 1)
                                            {
                                                  int W1tara = SprVagonTaraRead(nVagon);

                                                if (W1tara != 0)
                                                {
                                                    _InsertContainers.W1tara = (float)W1tara;
                                                    _InsertContainers.W1netto = _InsertContainers.W1brutto -
                                                        _InsertContainers.W1tara;
                                                }
                                            }
                                            else
                                            {
                                                SprVagonTaraSaveTara(nVagon, reader["Weight"].ToString());

                                            }

                                        }
        //                                _InsertContainers.W2time = Convert.ToDateTime(vtable1.Rows[vnumber - 1]["wntime"].ToString());
                                    }
                                


                                _InsertContainers.Trailid = TrainID1;
                                _InsertContainers.SaveNew();
                                vn1time1= vn2time1;                                                  
                                ConnCloseOLe(connection);
                                // MessageBox.Show(reader["TrainID"].ToString() + "---" + reader["VagonNumber"].ToString());
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                                ConnCloseOLe(connection);


                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    ConnCloseOLe(connection);

                }

                ConnCloseOLe(connection);
            }


        }


        private int AddTrains2(int TrainID, int line)
        {

           
            //string connectionString = @"Provider = Microsoft.Jet.OLEDB.4.0;  Data Source = \\WIMSYSTEM2\ARM\Tables\RRDB1_be.mdb";
            string connectionString = @"Provider = Microsoft.Jet.OLEDB.4.0;  Data Source = \\" + ipcontroller[1].ToString() + @"\ARM\Tables\RRDB1_be.mdb";

            string strSQL = "SELECT * FROM SourceTrains  where  TrainID =" + TrainID.ToString();
            int IdTrains = 0;
            // Create a connection  

            // MessageBox.Show("-------"+ strSQL);
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                // Create a command and set its connection  
                OleDbCommand command = new OleDbCommand(strSQL, connection);
                // Open the connection and execute the select command.  
                try
                {
                    // Open connecton  
                    connection.Open();

                    // Execute command  
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {


                            try
                            {

                                BOTrail _InsertBOTrail = new BOTrail();
                           //     if (vtable2 != null) vtable2.Clear();

                                //MessageBox.Show("------0"+ reader["TrainNumber"].ToString());
                                trainid2 = Convert.ToInt32(reader["TrainID"].ToString());
                                _InsertBOTrail.Trainid1 = Convert.ToInt32(reader["TrainNumber"].ToString());
                                _InsertBOTrail.Trainid2 = Convert.ToInt32(reader["TrainID"].ToString());
                                _InsertBOTrail.Lineid = Convert.ToInt32(reader["ScaleID"].ToString());
                                _InsertBOTrail.Pr3 = 0;
                                _InsertBOTrail.Pr2 = 0;
                                //MessageBox.Show("------1");


                                if (reader["Direction"].ToString() == "True") _InsertBOTrail.Pr1 = 1; else _InsertBOTrail.Pr1 = 0;

                                Direction = (int)_InsertBOTrail.Pr1;
                                TrainNumber = (int)_InsertBOTrail.Trainid1;

                                //MessageBox.Show("------2");
                                if (reader["When"].ToString() != "")
                                {
                                    _InsertBOTrail.W2time = DateTime.Parse((reader["When"].ToString()));
                                    w2time2 = (DateTime)_InsertBOTrail.W2time;
                                    _InsertBOTrail.W1time = DateTime.Now;
                                    vn1time2 = w2time2;
                                    
                                    //vtable2 = LoadTableCamer(2, _InsertBOTrail.W2time.ToString());

                                }
                                //MessageBox.Show("------3");
                                _InsertBOTrail.Operationid = 5;
                                _InsertBOTrail.Lineid = 2;
                               



                                _InsertBOTrail.SaveNew();

                                //MessageBox.Show("------4");
                                IdTrains = Convert.ToInt32(_InsertBOTrail.Id.ToString());

                                // MessageBox.Show(reader["TrainNumber"].ToString() + "-- -" + reader["Direction"].ToString());
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                                ConnCloseOLe(connection);
                                return IdTrains;
                            }
                        }

                    }
                    connection.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    ConnCloseOLe(connection);
                    return IdTrains;
                }

                ConnCloseOLe(connection);
                return IdTrains;
            }
        }


        void AddVagons2(int TrainID, int TrainID1)
        {
            // Connection string and SQL query  

            //string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\\WIMSYSTEM2\ARM\Tables\RRDB1_be.mdb";
            string connectionString = @"Provider = Microsoft.Jet.OLEDB.4.0;  Data Source = \\" + ipcontroller[1].ToString() + @"\ARM\Tables\RRDB1_be.mdb";

            string strSQL = "SELECT * FROM SourceVagons  where  TrainID=" + trainid2.ToString()+" order by VagonNumber desc";
            // Create a connection  
            // MessageBox.Show("------0");
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                // Create a command and set its connection  
                OleDbCommand command = new OleDbCommand(strSQL, connection);
                // Open the connection and execute the select command.  
                try
                {
                    // Open connecton 


                    connection.Open();
                    // Execute command  

                    using (OleDbDataReader reader = command.ExecuteReader())
                    {


                        while (reader.Read())
                        {

                            try
                            {
                                //  "([TrainID],[VagonID], [VagonNumber],[VagonTypeID],[Axles],[Weight]," +
                                //   "[GVID],[WeighingModeID],[Speed]," +
                                //   "[NotUse],"   " [Tel1], [Tel2])" +
                                BOContainers _InsertContainers = new BOContainers();
                             

                                int vnumber = Convert.ToInt32(reader["VagonNumber"].ToString());

                                _InsertContainers.Number = reader["VagonNumber"].ToString();
                                //_InsertContainers.Tvagonid = Convert.ToInt32( reader["VagonNumber"].ToString());

                                


                                int vt = Convert.ToInt32(reader["VagonTypeID"].ToString());
                                int Scale = Convert.ToInt32(reader["Axles"].ToString());

                                _InsertContainers.Pr1 = Direction;
                                _InsertContainers.Weightcount = TrainNumber;
                                _InsertContainers.W2time = w2time2;
                                _InsertContainers.W1time = DateTime.Now;

                                speed_d = Convert.ToSingle(reader["Speed"].ToString());
                                if (vt == 1 && Scale == 6) L_vagon = L_Dumpcar;
                                if (vt == 1 && Scale == 8) L_vagon = L_Gondol;
                                if (vt == 2 && Scale == 6) L_vagon = L_Lokomotiv;
                                min_speed = Convert.ToInt32(L_vagon / ((speed_d * 1000) / 3600)) + 2;
                                vn2time2 = vn1time2.AddSeconds(-(min_speed));                               
                                _InsertContainers.W1time = vn2time2;                                            
                                
                                _InsertContainers.W2scale = Convert.ToInt32(reader["Axles"].ToString());
                                _InsertContainers.Speed = Convert.ToSingle(reader["Speed"].ToString());
                                _InsertContainers.W1brutto = Convert.ToSingle(reader["Weight"].ToString());
                                _InsertContainers.Tvagonid = 6;
                                _InsertContainers.Pr3 = 0;
                                _InsertContainers.Pr2 = 0;
                                if (vt == 1 && Scale == 6)
                                {
                                    _InsertContainers.Tvagonid = 4;
                                    _InsertContainers.W1tara = pr11_4;
                                    _InsertContainers.W1netto = _InsertContainers.W1brutto - pr11_4;

                                }
                                if (vt == 1 && Scale == 8)
                                {
                                    _InsertContainers.Tvagonid = 5;
                                    _InsertContainers.W1tara = pr11_5;
                                    _InsertContainers.W1netto = _InsertContainers.W1brutto - pr11_5;
                                }
                                if (vt == 2 && Scale == 6) _InsertContainers.Tvagonid = 6;


                                
                                    if (_InsertContainers.Tvagonid != 6)
                                    {
                                        string nVagon = findnumber(2, vn1time2.ToString(), vn2time2.ToString());
                                      //  if (nVagon != null && numsprvag.Find((x) => x == nVagon) != null && _InsertContainers.Tvagonid == 4)
                                         if (nVagon != null && numsprvag.Find((x) => x == nVagon) != null )
                                        {
                                            _InsertContainers.Lotnumber = nVagon;
                                            _InsertContainers.Vid1 = vid1;
                                            // _InsertContainers.W2time = vntimeT; //фактическое время прохождения вагона
                                            _InsertContainers.W2time = w2time2; //время прохождения состава
                                            if (Direction == 1)
                                            {
                                                int W1tara = SprVagonTaraRead(nVagon);

                                                if (W1tara != 0)
                                                {
                                                    _InsertContainers.W1tara = (float)W1tara;
                                                    _InsertContainers.W1netto = _InsertContainers.W1brutto -
                                                        _InsertContainers.W1tara;
                                                }
                                            }
                                            else
                                            {
                                                SprVagonTaraSaveTara(nVagon, reader["Weight"].ToString());
                                                
                                            }

                                        }
                                     //   _InsertContainers.W2time = Convert.ToDateTime(vtable2.Rows[vnumber - 1]["wntime"].ToString());
                                    }
                                


                                _InsertContainers.Trailid = TrainID1;
                                _InsertContainers.SaveNew();
                                vn1time2 = vn2time2;
                                ConnCloseOLe(connection);
                                // MessageBox.Show(reader["TrainID"].ToString() + "---" + reader["VagonNumber"].ToString());
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                                ConnCloseOLe(connection);


                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    ConnCloseOLe(connection);

                }

                ConnCloseOLe(connection);
            }


        }

        // 3 путь начало

        private int AddTrains3(int TrainID, int line)
        {

            //string connectionString = @"Provider = Microsoft.Jet.OLEDB.4.0;  Data Source = \\WIMSYSTEM3\ARM\Tables\RRDB1_be.mdb";
            string connectionString = @"Provider = Microsoft.Jet.OLEDB.4.0;  Data Source = \\" + ipcontroller[2].ToString() + @"\ARM\Tables\RRDB1_be.mdb";

            string strSQL = "SELECT * FROM SourceTrains  where  TrainID =" + TrainID.ToString();
            int IdTrains = 0;
            // Create a connection  

            // MessageBox.Show("-------"+ strSQL);
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                // Create a command and set its connection  
                OleDbCommand command = new OleDbCommand(strSQL, connection);
                // Open the connection and execute the select command.  
                try
                {
                    // Open connecton  
                    connection.Open();

                    // Execute command  
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {


                            try
                            {

                                BOTrail _InsertBOTrail = new BOTrail();
                                //     if (vtable2 != null) vtable2.Clear();

                                //MessageBox.Show("------0"+ reader["TrainNumber"].ToString());
                                trainid2 = Convert.ToInt32(reader["TrainID"].ToString());
                                _InsertBOTrail.Trainid1 = Convert.ToInt32(reader["TrainNumber"].ToString());
                                _InsertBOTrail.Trainid2 = Convert.ToInt32(reader["TrainID"].ToString());
                                _InsertBOTrail.Lineid = Convert.ToInt32(reader["ScaleID"].ToString());
                                _InsertBOTrail.Pr3 = 0;
                                _InsertBOTrail.Pr2 = 0;
                                // MessageBox.Show("------1");


                                if (reader["Direction"].ToString() == "True") _InsertBOTrail.Pr1 = 1; else _InsertBOTrail.Pr1 = 0;

                                Direction = (int)_InsertBOTrail.Pr1;
                                TrainNumber = (int)_InsertBOTrail.Trainid1;

                               // MessageBox.Show("------2");
                                if (reader["When"].ToString() != "")
                                {
                                    _InsertBOTrail.W2time = DateTime.Parse((reader["When"].ToString()));
                                    w2time3 = (DateTime)_InsertBOTrail.W2time;
                                    _InsertBOTrail.W1time = DateTime.Now;
                                    vn1time3 = w2time3;

                                    //vtable2 = LoadTableCamer(2, _InsertBOTrail.W2time.ToString());

                                }
                               // MessageBox.Show("------3");
                                _InsertBOTrail.Operationid = 5;
                                _InsertBOTrail.Lineid = 3;
                                



                                _InsertBOTrail.SaveNew();

                               // MessageBox.Show("------4");
                                IdTrains = Convert.ToInt32(_InsertBOTrail.Id.ToString());

                                // MessageBox.Show(reader["TrainNumber"].ToString() + "-- -" + reader["Direction"].ToString());
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                                ConnCloseOLe(connection);
                                return IdTrains;
                            }
                        }

                    }
                    connection.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    ConnCloseOLe(connection);
                    return IdTrains;
                }

                ConnCloseOLe(connection);
                return IdTrains;
            }
        }


        void AddVagons3(int TrainID, int TrainID1)
        {
            // Connection string and SQL query  
            //string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\\WIMSYSTEM3\ARM\Tables\RRDB1_be.mdb";
            string connectionString = @"Provider = Microsoft.Jet.OLEDB.4.0;  Data Source = \\" + ipcontroller[2].ToString() + @"\ARM\Tables\RRDB1_be.mdb";

            string strSQL = "SELECT * FROM SourceVagons  where  TrainID=" + trainid2.ToString() + " order by VagonNumber desc";
            // Create a connection  
            // MessageBox.Show("------0");
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                // Create a command and set its connection  
                OleDbCommand command = new OleDbCommand(strSQL, connection);
                // Open the connection and execute the select command.  
                try
                {
                    // Open connecton 


                    connection.Open();
                    // Execute command  

                    using (OleDbDataReader reader = command.ExecuteReader())
                    {


                        while (reader.Read())
                        {

                            try
                            {
                                //  "([TrainID],[VagonID], [VagonNumber],[VagonTypeID],[Axles],[Weight]," +
                                //   "[GVID],[WeighingModeID],[Speed]," +
                                //   "[NotUse],"   " [Tel1], [Tel2])" +
                                BOContainers _InsertContainers = new BOContainers();


                                int vnumber = Convert.ToInt32(reader["VagonNumber"].ToString());

                                _InsertContainers.Number = reader["VagonNumber"].ToString();
                                //_InsertContainers.Tvagonid = Convert.ToInt32( reader["VagonNumber"].ToString());




                                int vt = Convert.ToInt32(reader["VagonTypeID"].ToString());
                                int Scale = Convert.ToInt32(reader["Axles"].ToString());

                                _InsertContainers.Pr1 = Direction;
                                _InsertContainers.Weightcount = TrainNumber;
                                _InsertContainers.W2time = w2time3;
                                _InsertContainers.W1time = DateTime.Now;

                                speed_d = Convert.ToSingle(reader["Speed"].ToString());
                                if (vt == 1 && Scale == 6) L_vagon = L_Dumpcar;
                                if (vt == 1 && Scale == 8) L_vagon = L_Gondol;
                                if (vt == 2 && Scale == 6) L_vagon = L_Lokomotiv;
                                min_speed = Convert.ToInt32(L_vagon / ((speed_d * 1000) / 3600)) + 2;
                                vn2time3 = vn1time3.AddSeconds(-(min_speed));
                                _InsertContainers.W1time = vn2time3;

                                _InsertContainers.W2scale = Convert.ToInt32(reader["Axles"].ToString());
                                _InsertContainers.Speed = Convert.ToSingle(reader["Speed"].ToString());
                                _InsertContainers.W1brutto = Convert.ToSingle(reader["Weight"].ToString());
                                _InsertContainers.Tvagonid = 6;
                                _InsertContainers.Pr3 = 0;
                                _InsertContainers.Pr2 = 0;
                                if (vt == 1 && Scale == 6)
                                {
                                    _InsertContainers.Tvagonid = 4;
                                    _InsertContainers.W1tara = pr11_4;
                                    _InsertContainers.W1netto = _InsertContainers.W1brutto - pr11_4;

                                }
                                if (vt == 1 && Scale == 8)
                                {
                                    _InsertContainers.Tvagonid = 5;
                                    _InsertContainers.W1tara = pr11_5;
                                    _InsertContainers.W1netto = _InsertContainers.W1brutto - pr11_5;
                                }
                                if (vt == 2 && Scale == 6) _InsertContainers.Tvagonid = 6;


                                
                                    if (_InsertContainers.Tvagonid != 6)
                                    {
                                        string nVagon = findnumber(3, vn1time3.ToString(), vn2time3.ToString());
                                        //if (nVagon != null && numsprvag.Find((x) => x == nVagon) != null && _InsertContainers.Tvagonid == 4)
                                           if (nVagon != null && numsprvag.Find((x) => x == nVagon) != null )
                                        {
                                            _InsertContainers.Lotnumber = nVagon;
                                            _InsertContainers.Vid1 = vid1;
                                            //  _InsertContainers.W2time = vntimeT; //фактическое время прохождения состава
                                            _InsertContainers.W2time = w2time3; //время прохождения состава

                                            if (Direction == 1)
                                            {
                                                int W1tara = SprVagonTaraRead(nVagon);

                                                if (W1tara != 0)
                                                {
                                                    _InsertContainers.W1tara = (float)W1tara;
                                                    _InsertContainers.W1netto = _InsertContainers.W1brutto -
                                                        _InsertContainers.W1tara;
                                                }
                                            }
                                            else
                                            {
                                                SprVagonTaraSaveTara(nVagon, reader["Weight"].ToString());

                                            }

                                        }
                                        //   _InsertContainers.W2time = Convert.ToDateTime(vtable2.Rows[vnumber - 1]["wntime"].ToString());
                                    }
                                


                                _InsertContainers.Trailid = TrainID1;
                                _InsertContainers.SaveNew();
                                vn1time3 = vn2time3;
                                ConnCloseOLe(connection);
                              //   MessageBox.Show(reader["TrainID"].ToString() + "---" + reader["VagonNumber"].ToString());
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                                ConnCloseOLe(connection);


                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    ConnCloseOLe(connection);

                }

                ConnCloseOLe(connection);
            }


        }


        // 3 путь конец



        private int AddTrains4(int TrainID,int line )
        {

            //string connectionString = @"Provider = Microsoft.Jet.OLEDB.4.0;  Data Source = \\WIMSYSTEM4\\ARM\\Tables\\RRDB1_be.mdb";
            string connectionString = @"Provider = Microsoft.Jet.OLEDB.4.0;  Data Source = \\" + ipcontroller[3].ToString() + @"\ARM\Tables\RRDB1_be.mdb";

            string strSQL = "SELECT * FROM SourceTrains  where  TrainID =" + TrainID.ToString();
                int IdTrains = 0;
            // Create a connection  

           // MessageBox.Show("-------"+ strSQL);
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                // Create a command and set its connection  
                OleDbCommand command = new OleDbCommand(strSQL, connection);
                // Open the connection and execute the select command.  
                try
                {
                    // Open connecton  
                    connection.Open();
         
                    // Execute command  
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {


                            try
                            {

                                BOTrail _InsertBOTrail = new BOTrail();
                                if (vtable4 != null) vtable4.Clear();

                                //MessageBox.Show("------0"+ reader["TrainNumber"].ToString());
                                trainid4 = Convert.ToInt32(reader["TrainID"].ToString());
                                _InsertBOTrail.Trainid1 = Convert.ToInt32(reader["TrainNumber"].ToString());
                                _InsertBOTrail.Trainid2 = Convert.ToInt32(reader["TrainID"].ToString());
                                _InsertBOTrail.Lineid = Convert.ToInt32(reader["ScaleID"].ToString());
                                _InsertBOTrail.Pr3 = 0;
                                _InsertBOTrail.Pr2 = 0;
                                //MessageBox.Show("------1");


                                if (reader["Direction"].ToString() == "True") _InsertBOTrail.Pr1 = 1; else _InsertBOTrail.Pr1 = 0;

                                  Direction =(int) _InsertBOTrail.Pr1;
                                 TrainNumber = (int)_InsertBOTrail.Trainid1;
                                
                                  //MessageBox.Show("------2");
                                if (reader["When"].ToString() != "")
                                {
                                    _InsertBOTrail.W2time = DateTime.Parse((reader["When"].ToString()));
                                    w2time4 = (DateTime) _InsertBOTrail.W2time;
                                    _InsertBOTrail.W1time = DateTime.Now;
                                    vn1time4 = w2time4;
                                    //vtable4 = LoadTableCamer(4, _InsertBOTrail.W2time.ToString());

                                }
                                //MessageBox.Show("------3");
                                _InsertBOTrail.Operationid = 5;
                                _InsertBOTrail.Lineid = 4;
                                



                                _InsertBOTrail.SaveNew();
                                
                                
                                IdTrains = Convert.ToInt32(_InsertBOTrail.Id.ToString());

                              //  MessageBox.Show("------4");
                                // MessageBox.Show(reader["TrainNumber"].ToString() + "-- -" + reader["Direction"].ToString());
                            }
                            catch (Exception ex)
                            {

                                ConnCloseOLe(connection);
                                return IdTrains;
                            }
                        }

                    }
                    connection.Close();

                }
                catch (Exception ex)
                {
                    ConnCloseOLe(connection);
               //     MessageBox.Show(ex.Message);
                    return IdTrains;
                }

                ConnCloseOLe(connection);
                return IdTrains;
            }
        }


        void AddVagons4(int TrainID, int TrainID1)
        {
            // Connection string and SQL query  
            //string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\\WIMSYSTEM4\ARM\Tables\RRDB1_be.mdb";
            string connectionString = @"Provider = Microsoft.Jet.OLEDB.4.0;  Data Source = \\" + ipcontroller[3].ToString() + @"\ARM\Tables\RRDB1_be.mdb";

            string strSQL = "SELECT * FROM SourceVagons  where  TrainID="+ trainid4.ToString() + " order by VagonNumber desc";
            // Create a connection  
           // MessageBox.Show("------0");
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                // Create a command and set its connection  
                OleDbCommand command = new OleDbCommand(strSQL, connection);
                // Open the connection and execute the select command.  
                try
                {
                    // Open connecton 
                    
                  
                    connection.Open();
                    // Execute command  

                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                      

                        while (reader.Read())
                        {

                            try
                            {
                                //  "([TrainID],[VagonID], [VagonNumber],[VagonTypeID],[Axles],[Weight]," +
                                //   "[GVID],[WeighingModeID],[Speed]," +
                                //   "[NotUse],"   " [Tel1], [Tel2])" +
                                BOContainers _InsertContainers = new BOContainers();
                             //   if (vtable4 != null) vtable4.Clear();

                                int vnumber = Convert.ToInt32(reader["VagonNumber"].ToString());

                                _InsertContainers.Number= reader["VagonNumber"].ToString();
                                //_InsertContainers.Tvagonid = Convert.ToInt32( reader["VagonNumber"].ToString());
                                



                                  int vt= Convert.ToInt32(reader["VagonTypeID"].ToString());
                                 int Scale = Convert.ToInt32(reader["Axles"].ToString());

                                _InsertContainers.Pr1 = Direction;
                                _InsertContainers.Weightcount = TrainNumber;
                                _InsertContainers.W2time = w2time4;
                                _InsertContainers.W1time = DateTime.Now;

                                speed_d = Convert.ToSingle(reader["Speed"].ToString());
                                if (vt == 1 && Scale == 6) L_vagon = L_Dumpcar;
                                if (vt == 1 && Scale == 8) L_vagon = L_Gondol;
                                if (vt == 2 && Scale == 6) L_vagon = L_Lokomotiv;
                                min_speed = Convert.ToInt32(L_vagon / ((speed_d * 1000) / 3600)) + 2;
                                vn2time4 = vn1time4.AddSeconds(-(min_speed));                                 
                                _InsertContainers.W1time = vn2time4;                                             

                                _InsertContainers.W2scale = Convert.ToInt32(reader["Axles"].ToString());
                                _InsertContainers.Speed = Convert.ToSingle(reader["Speed"].ToString());
                                _InsertContainers.W1brutto = Convert.ToSingle(reader["Weight"].ToString());
                                _InsertContainers.Tvagonid = 6;
                                _InsertContainers.Pr3 = 0;
                                _InsertContainers.Pr2 = 0;
                                if (vt == 1 && Scale == 6)
                                {
                                    _InsertContainers.Tvagonid = 4;
                                    _InsertContainers.W1tara = pr11_4;
                                    _InsertContainers.W1netto = _InsertContainers.W1brutto - pr11_4;

                                }
                                if (vt == 1 && Scale == 8)
                                {
                                    _InsertContainers.Tvagonid = 5;
                                    _InsertContainers.W1tara = pr11_5;
                                    _InsertContainers.W1netto = _InsertContainers.W1brutto - pr11_5;
                                }
                                if (vt == 2 && Scale == 6) _InsertContainers.Tvagonid = 6;



                                
                                    if (_InsertContainers.Tvagonid != 6)
                                    {
                                        string nVagon = findnumber(4, vn1time4.ToString(), vn2time4.ToString());
                                        //if (nVagon != null && numsprvag.Find((x) => x == nVagon) != null && _InsertContainers.Tvagonid == 4)
                                           if (nVagon != null && numsprvag.Find((x) => x == nVagon) != null)
                                        {
                                            _InsertContainers.Lotnumber = nVagon;
                                            _InsertContainers.Vid1 = vid1;
                                           // _InsertContainers.W2time = vntimeT; //фактическое время прохождения состава
                                            _InsertContainers.W2time = w2time4; //время прохождения состава

                                            if (Direction == 1)
                                            {
                                                int W1tara = SprVagonTaraRead(nVagon);
                                                if (W1tara != 0)
                                                {
                                                    _InsertContainers.W1tara = (float)W1tara;
                                                    _InsertContainers.W1netto = _InsertContainers.W1brutto -
                                                        _InsertContainers.W1tara;
                                                }
                                            }
                                            else
                                            {
                                                
                                                SprVagonTaraSaveTara(nVagon, reader["Weight"].ToString());
                                            }
                                        }
                                        //_InsertContainers.W2time = Convert.ToDateTime(vtable4.Rows[vnumber - 1]["wntime"].ToString());
                                                                          

                                    }
                                

                                _InsertContainers.Trailid = TrainID1;
                               _InsertContainers.SaveNew();
                                vn1time4 = vn2time4;
                                ConnCloseOLe(connection);
                               // MessageBox.Show(reader["TrainID"].ToString() + "---" + reader["VagonNumber"].ToString());
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                                ConnCloseOLe(connection);
                                
                                
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                    ConnCloseOLe(connection);
                    
                }

                ConnCloseOLe(connection);
            }
            

        }

        private int AddTrains5(int TrainID, int line)
        {

            //string connectionString = @"Provider = Microsoft.Jet.OLEDB.4.0;  Data Source = \\WIMSYSTEM5\ARM\Tables\RRDB1_be.mdb";
            string connectionString = @"Provider = Microsoft.Jet.OLEDB.4.0;  Data Source = \\" + ipcontroller[4].ToString() + @"\ARM\Tables\RRDB1_be.mdb";

            string strSQL = "SELECT * FROM SourceTrains  where  TrainID =" + TrainID.ToString();

            int IdTrains = 0;
            // Create a connection  

               //MessageBox.Show("-------"+ strSQL);
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                // Create a command and set its connection  
                OleDbCommand command = new OleDbCommand(strSQL, connection);
                // Open the connection and execute the select command.  
                try
                {
                  

                    // Open connecton  
                    connection.Open();
                    
                    // Execute command  
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {


                            try
                            {

                                BOTrail _InsertBOTrail = new BOTrail();
                                if (vtable5 != null) vtable5.Clear(); //---------------

                                //MessageBox.Show("------0"+ reader["TrainNumber"].ToString());
                                trainid5 = Convert.ToInt32(reader["TrainID"].ToString());
                                _InsertBOTrail.Trainid1 = Convert.ToInt32(reader["TrainNumber"].ToString());
                                _InsertBOTrail.Trainid2 = Convert.ToInt32(reader["TrainID"].ToString());

                                _InsertBOTrail.Lineid = Convert.ToInt32(reader["ScaleID"].ToString());
                                _InsertBOTrail.Pr3 = 0;
                                _InsertBOTrail.Pr2 = 0;

                                //MessageBox.Show("------1");

                                if (reader["Direction"].ToString() == "True") _InsertBOTrail.Pr1 = 1; else _InsertBOTrail.Pr1 = 0;

                                Direction = (int)_InsertBOTrail.Pr1;
                                TrainNumber = (int)_InsertBOTrail.Trainid1;

                                  //MessageBox.Show("------2");
                                if (reader["When"].ToString() != "")
                                {
                                    _InsertBOTrail.W2time = DateTime.Parse((reader["When"].ToString()));
                                    w2time5 = (DateTime)_InsertBOTrail.W2time;
                                    _InsertBOTrail.W1time = DateTime.Now;
                                    //-------------------
                                    vn1time5 = w2time5;
                                    //vtable5 = LoadTableCamer(5, _InsertBOTrail.W2time.ToString());
                                }

                                  //MessageBox.Show("------3");
                                _InsertBOTrail.Operationid = 5; 
                                _InsertBOTrail.Lineid = 5;     //-------
                                


                                _InsertBOTrail.SaveNew();
                                  //MessageBox.Show("------4");
                                IdTrains = Convert.ToInt32(_InsertBOTrail.Id.ToString());
                                ConnCloseOLe(connection);
                                 //  MessageBox.Show(reader["TrainID"].ToString() + "---" + reader["Direction"].ToString());
                            }
                            catch (Exception ex)
                            {
                             //   MessageBox.Show(ex.Message);
                                ConnCloseOLe(connection);
                                return IdTrains;
                            }
                        }

                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    ConnCloseOLe(connection);
                 //  MessageBox.Show(ex.Message);
                    return IdTrains;
                }
                
                ConnCloseOLe(connection);
                //  MessageBox.Show(IdTrains.ToString());
                return IdTrains;
            }
        }


        void AddVagons5(int TrainID, int TrainID1)
        {
            // Connection string and SQL query  
            //string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\\WIMSYSTEM5\ARM\Tables\RRDB1_be.mdb";
            string connectionString = @"Provider = Microsoft.Jet.OLEDB.4.0;  Data Source = \\" + ipcontroller[4].ToString() + @"\ARM\Tables\RRDB1_be.mdb";

            string strSQL = "SELECT * FROM SourceVagons  where  TrainID=" + trainid5.ToString() + " order by VagonNumber desc";
            // Create a connection  
            // MessageBox.Show("------0");
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                // Create a command and set its connection  
                OleDbCommand command = new OleDbCommand(strSQL, connection);
                // Open the connection and execute the select command.  
                try
                {
        
                    // Open connecton  
                    connection.Open();
                    // Execute command  
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {


                        while (reader.Read())
                        {

                            try
                            {


                                //  "([TrainID],[VagonID], [VagonNumber],[VagonTypeID],[Axles],[Weight]," +
                                //   "[GVID],[WeighingModeID],[Speed]," +
                                //   "[NotUse],"   " [Tel1], [Tel2])" +
                                BOContainers _InsertContainers = new BOContainers();

                                int vnumber = Convert.ToInt32(reader["VagonNumber"].ToString());

                                _InsertContainers.Number = reader["VagonNumber"].ToString();
                                //_InsertContainers.Tvagonid = Convert.ToInt32( reader["VagonNumber"].ToString());
                                //_InsertContainers.Tvagonid = Convert.ToInt32(reader["VagonTypeID"].ToString());
                                int vt = Convert.ToInt32(reader["VagonTypeID"].ToString());
                                int Scale = Convert.ToInt32(reader["Axles"].ToString());


                                _InsertContainers.Pr1 = Direction;
                                _InsertContainers.Weightcount = TrainNumber;
                                _InsertContainers.W2time = w2time5;
                                _InsertContainers.W1time = DateTime.Now;
                                speed_d = Convert.ToSingle(reader["Speed"].ToString());

                                if (vt == 1 && Scale == 6) L_vagon = L_Dumpcar;
                                if (vt == 1 && Scale == 8) L_vagon = L_Gondol;
                                if (vt == 2 && Scale == 6) L_vagon = L_Lokomotiv;
                                min_speed = Convert.ToInt32(L_vagon / ((speed_d * 1000) / 3600)) + 2;     
                                vn2time5 = vn1time5.AddSeconds(-(min_speed));                                 
                                _InsertContainers.W1time = vn2time5;                                              

                                //  MessageBox.Show("------2");

                                _InsertContainers.W2scale = Convert.ToInt32(reader["Axles"].ToString());
                                _InsertContainers.Speed = Convert.ToSingle(reader["Speed"].ToString());
                                _InsertContainers.W1brutto = Convert.ToSingle(reader["Weight"].ToString());
                                _InsertContainers.Tvagonid = 6;
                                _InsertContainers.Pr3 = 0;
                                _InsertContainers.Pr2 = 0;
                                if (vt == 1 && Scale == 6)
                                {
                                    _InsertContainers.Tvagonid = 4;
                                    _InsertContainers.W1tara = pr11_4;
                                    _InsertContainers.W1netto = _InsertContainers.W1brutto - pr11_4;

                                }
                                if (vt == 1 && Scale == 8)
                                {
                                    _InsertContainers.Tvagonid = 5;
                                    _InsertContainers.W1tara = pr11_5;
                                    _InsertContainers.W1netto = _InsertContainers.W1brutto - pr11_5;
                                }
                                if (vt == 2 && Scale == 6) _InsertContainers.Tvagonid = 6;

                                
                                    if (_InsertContainers.Tvagonid != 6)
                                    {
                                        string nVagon = findnumber(5, vn1time5.ToString(), vn2time5.ToString());
                                        //if (nVagon != null && numsprvag.Find((x) => x == nVagon) != null && _InsertContainers.Tvagonid == 4)
                                           if (nVagon != null && numsprvag.Find((x) => x == nVagon) != null)
                                        {
                                            _InsertContainers.Lotnumber = nVagon;
                                            _InsertContainers.Vid1 = vid1;
                                          //  _InsertContainers.W2time = vntimeT; //фактическое время прохождения состава
                                           _InsertContainers.W2time = w2time5; //время прохождения состава


                                            if (Direction == 1)
                                            {
                                                int W1tara = SprVagonTaraRead(nVagon);
                                                if (W1tara != 0)
                                                {
                                                    _InsertContainers.W1tara = (float)W1tara;
                                                    _InsertContainers.W1netto = _InsertContainers.W1brutto -
                                                        _InsertContainers.W1tara;
                                                }
                                            }
                                            else
                                            {
                                                
                                                SprVagonTaraSaveTara(nVagon, reader["Weight"].ToString());
                                            }
                                        }
                                        //_InsertContainers.W2time = Convert.ToDateTime(vtable5.Rows[vnumber - 1]["wntime"].ToString());
                                        
                                    }
                                
                            

                                _InsertContainers.Trailid = TrainID1;
                                _InsertContainers.SaveNew();
                                vn1time5 = vn2time5;
                                ConnCloseOLe(connection);
                             //     MessageBox.Show(reader["TrainID"].ToString() + "---" + reader["VagonNumber"].ToString());
                            }
                            catch (Exception ex)
                            {
                                ConnCloseOLe(connection);
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ConnCloseOLe(connection);
                    //MessageBox.Show(ex.Message);
                }


            }

        }



        private string findnumber(int lineid, string d2, string d1)
        {

            
            int n = 0;
            //            string strSQL = "SELECT * FROM numvag  where lineid=4 and Direction= " + direction.ToString() + " and (" +
            string strSQL = "SELECT * FROM numvag  where lineid=" + lineid.ToString() + " and (" +
                " wntime >='" + d1.ToString() +
                "' and  wntime <='" + d2.ToString() + "')";

            string result = null;
            string connectionString = connectionString1;
            //  "Data Source=192.168.50.103;Initial Catalog=awsd; Connect Timeout=120;Integrated Security=SSPI;Persist Security Info=False;Packet Size=4096";
            //"Data Source=WIN-G7APJPTONBM\\SQLEXPRESS; Initial Catalog = awsd; Persist Security Info = True; User ID = sa; Password = s250099S";
            //"Data Source=SALIKH-PC\\SQLEXPRESS;Initial Catalog=awsd;Persist Security Info=True;User ID=sa;Password=12345";
            // "Data Source = SALIKH-PC\\SQLEXPRESS; Initial Catalog = awsd; Connect Timeout = 120; Integrated Security = SSPI; Persist Security Info = False; Packet Size = 4096";
            //MessageBox.Show(strSQL);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create a command and set its connection  
                SqlCommand command = new SqlCommand(strSQL, connection);
                // Open the connection and execute the select command.  
                try
                {


                    // Open connecton  
                    connection.Open();
                    // Execute command  
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            try
                            {
                                n = n + 1;
                                result = reader["number"].ToString();
                                vid1 = (byte[]) reader["vid1"];
                                vntimeT = Convert.ToDateTime( reader["wntime"].ToString());
                                if  ( Direction==0 &&   n == 1)
                                {
                                    return result;
                                }
                                if (lineid == 1 && n==1)
                                {
                                    return result;
                                }
                                if (lineid == 3 && n == 1)
                                {
                                    return result;
                                }
                            }
                            catch (Exception ex)
                            {
                                ConnCloseSql(connection);
                                //MessageBox.Show(ex.Message);

                            }
                        }
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    ConnCloseSql(connection);

                    // MessageBox.Show(ex.Message);
                    return result;
                }
                ConnCloseSql(connection);
                return result;
            }

        }



            //DataTable LoadCamer (DateTime dateinput)
            DataTable LoadTableCamer(int lineid, string grtime)
        {


          string  sv1time=LastTime(lineid,grtime);

            
            string sql = "SELECT * FROM numvag  where lineid="+ lineid.ToString() + 
                "  and  v1time ='" + sv1time + "'" +
                    "  and  wntime <='" + grtime + "'";

            string connectionString = connectionString1;
            //"Data Source=SALIKH-PC\\SQLEXPRESS;Initial Catalog=awsd;Persist Security Info=True;User ID=sa;Password=12345";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                DataSet ds = new DataSet();
                adapter.Fill(ds);
                connection.Close();
                return ds.Tables[0];
            }

        }
        

        private string LastTime(int lineid,string grtime)
        {

            DateTime grtime1 = Convert.ToDateTime(grtime);
            DateTime d1 = grtime1.AddMinutes(-1);
            DateTime d2 = grtime1;
            int n = 0;
            //            string strSQL = "SELECT * FROM numvag  where lineid=4 and Direction= " + direction.ToString() + " and (" +
            string strSQL = "SELECT * FROM numvag  where lineid=" + lineid.ToString() +" and (" +
                " wntime >='" + d1.ToString() +
                "' and  wntime <='" + d2.ToString() + "')";

            string result = "";
            string connectionString = connectionString1;
            //  "Data Source=192.168.50.103;Initial Catalog=awsd; Connect Timeout=120;Integrated Security=SSPI;Persist Security Info=False;Packet Size=4096";
            //"Data Source=WIN-G7APJPTONBM\\SQLEXPRESS; Initial Catalog = awsd; Persist Security Info = True; User ID = sa; Password = s250099S";
           //"Data Source=SALIKH-PC\\SQLEXPRESS;Initial Catalog=awsd;Persist Security Info=True;User ID=sa;Password=12345";
            // "Data Source = SALIKH-PC\\SQLEXPRESS; Initial Catalog = awsd; Connect Timeout = 120; Integrated Security = SSPI; Persist Security Info = False; Packet Size = 4096";
            //MessageBox.Show(strSQL);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create a command and set its connection  
                SqlCommand command = new SqlCommand(strSQL, connection);
                // Open the connection and execute the select command.  
                try
                {


                    // Open connecton  
                    connection.Open();
                    // Execute command  
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            try
                            {
                                n = n + 1;
                                result =reader["v1time"].ToString();
                                if (n == 1)
                                { return result; }
                            }
                            catch (Exception ex)
                            {
                                ConnCloseSql(connection);
                                //MessageBox.Show(ex.Message);

                                result ="";
                                
                            }
                        }
                    }
                    
                    connection.Close();
                }
                catch (Exception ex)
                {
                    ConnCloseSql(connection);

                   // MessageBox.Show(ex.Message);
                    return result;
                }
                ConnCloseSql(connection);
                return result;
            }


        }
        

        private int LastTrainNumber(int lineid)
        {

            int TrainNumber = 0;

            string strSQL =

                 "select trainid2 "
                    + " from trail   where lineid = " + lineid.ToString() + " order by trainid2  asc ";
            // " group by t.lineid ";
            int result = 0;
            string connectionString = connectionString1;
                //"Data Source=192.168.50.103;Initial Catalog=awsd; Connect Timeout=120;Integrated Security=SSPI;Persist Security Info=False;Packet Size=4096";
                //"Data Source=WIN-G7APJPTONBM\\SQLEXPRESS; Initial Catalog = awsd; Persist Security Info = True; User ID = sa; Password = s250099S";
                //"Data Source=SALIKH-PC\\SQLEXPRESS;Initial Catalog=awsd;Persist Security Info=True;User ID=sa;Password=s250099S";
                // "Data Source = SALIKH-PC\\SQLEXPRESS; Initial Catalog = awsd; Connect Timeout = 120; Integrated Security = SSPI; Persist Security Info = False; Packet Size = 4096";
                //MessageBox.Show(strSQL);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create a command and set its connection  
                SqlCommand command = new SqlCommand(strSQL, connection);
                // Open the connection and execute the select command.  
                try
                {
                  

                    // Open connecton  
                    connection.Open();
                    // Execute command  
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {


                            try
                            {
                                if (reader["trainid2"].ToString() != "")
                                {
                                    TrainNumber = Convert.ToInt32(reader["trainid2"].ToString());
                                }
                               // MessageBox.Show(TrainNumber.ToString());
                                int e = 0;
                                
                            }
                            catch (Exception ex)
                            {
                                ConnCloseSql(connection);
                                //MessageBox.Show(ex.Message);
                                return TrainNumber;
                            }
                        }
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    ConnCloseSql(connection);

                    MessageBox.Show(ex.Message);
                    return TrainNumber;
                }
                ConnCloseSql(connection);
                return TrainNumber;
            }


        }


        void ConnCloseOLe(OleDbConnection connection)
        {
          //  if (connection.State == ConnectionState.Open)
          //  {
          //      connection.Close();
          //  }

        }

        void ConnCloseSql(SqlConnection connection)
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }

        }

        
        private void SprVagonTaraSaveTara(string VagonNum, string VesTara)
        {
            using (SqlConnection connection = new SqlConnection(connectionString1))
            {


                string strSQL = " UPDATE  sprvag SET numberi = " + VesTara +
               " Where number = " + VagonNum;
                // Create a command and set its connection  
                SqlCommand command = new SqlCommand(strSQL, connection);
                // Open the connection and execute the select command.  
                try
                {
                    // Open connecton  
                    connection.Open();
                    command.ExecuteNonQuery();
                    // Execute command  

                    connection.Close();

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);

                }

            }

        }

        private int  SprVagonTaraRead(string VagonNum)
        {
            using (SqlConnection connection = new SqlConnection(connectionString1))
            {
                int vtara = 0;
                string strSQL = " select *  from sprvag "
              + " Where number = " + VagonNum;
                // Create a command and set its connection  
                SqlCommand command = new SqlCommand(strSQL, connection);
                // Open the connection and execute the select command.  
                try
                {
                    
                    // Open connecton  
                    connection.Open();
                    // Execute command  
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {


                            try
                            {

                                vtara = Convert.ToInt32(reader["numberi"].ToString());

                                int e = 0;

                            }
                            catch (Exception ex)
                            {

                                //MessageBox.Show(ex.Message);

                            }
                        }
                        connection.Close();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);

                }
               return   vtara;
            }
        }


                
        private void sql_pr11_4(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string strSQL = " select r1  from twagon "
              + " Where id = 4";
                // Create a command and set its connection  
                SqlCommand command = new SqlCommand(strSQL, connection);
                // Open the connection and execute the select command.  
                try
                {
                    // Open connecton  
                    connection.Open();
                    // Execute command  
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {


                            try
                            {

                                pr11_4 = Convert.ToInt32(reader["r1"].ToString());

                                int e = 0;

                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show(ex.Message);

                            }
                        }
                        connection.Close();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);

                }

            }
        }



        private void sql_pr11_5(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string strSQL = " select r1  from twagon "
              + " Where id = 5 ";
                // Create a command and set its connection  
                SqlCommand command = new SqlCommand(strSQL, connection);
                // Open the connection and execute the select command.  
                try
                {
                    // Open connecton  
                    connection.Open();
                    // Execute command  
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {


                            try
                            {

                                pr11_5 = Convert.ToInt32(reader["r1"].ToString());

                                int e = 0;

                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show(ex.Message);

                            }
                        }
                        connection.Close();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);

                }

            }
        }

        
        private bool StrBool(string obj_sjet)
        {
            int parsed = 0;


            if (int.TryParse(obj_sjet, out parsed))
            {
                if (parsed > 1) return true;
                else return false;
            }
            else
            {
                return false;
            }
        }

        private int StrShort(string obj_sjet)
        {
            int parsed = 0;

            if (int.TryParse(obj_sjet, out parsed))
            {

                return parsed;
            }
            else
            {
                return parsed;
            }
        }


        private byte StrByte(string proizv)
        {
            double parsed = 0;
            int i1 = 0;
            byte proizv1 = 0;

            if (double.TryParse(proizv, out parsed))
            {
                i1 = (int)parsed;
                proizv1 = (byte)i1;
                return proizv1;
            }
            else
            {
                proizv1 = 0;
                return proizv1;
            }
        }

        public BitmapImage ImageSource
        {
            get
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = new Uri(ip_file);
                image.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                image.EndInit();
                //Return the image
                return image;
            }


        }
        private List<string> SprVagonRead()
        {
            //  string nnVag = numsprvag.Find((x) => x == nVag);
            //public static List<string> numsprvag;
            //numsprvag = SprVagonRead();

            List<string> NumList = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString1))
            {
                int vtara = 0;
                string strSQL = " select *  from sprvag ";
                //+ " Where number = " + VagonNum;
                // Create a command and set its connection  
                SqlCommand command = new SqlCommand(strSQL, connection);
                // Open the connection and execute the select command.  
                try
                {


                    // Open connecton  
                    connection.Open();
                    // Execute command  
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            try
                            {
                                string numb = reader["number"].ToString();
                                NumList.Add(numb);
                                int e = 0;

                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show(ex.Message);

                            }
                        }
                        connection.Close();
                        return NumList;
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);

                }
                return NumList;

            }

        }

    }



    /*
    Имя хранимой процедуры - dbo.CreateConveyorWeighings
        Вот ее параметры:

         @Operator nvarchar(50), --Оператор
        @Conveyor    nvarchar(50), --Конвейер
        @Speed     float, --Скорость ленты
         @Performance tinyint, --Производительность
        @CurrentStateMessage nvarchar(50), --Сообщение о текущем состоянии
         @CurrentReadings int, --Текущие показания счетчика
        @GeneralReadings  int, --Общие показания счетчика
        @ProductMass   smallint, --Масса продукции
         @State nvarchar(50) --Состояние

        Сейчас база данных размещена на временном сервере.Вот параметры для подключения:
        сервер - dev.188.kz,52145
        имя пользователя - said
        пароль - 1qaz!QAZ
        база данных - scales

        Вот пример строки подключения: "Data Source=dev.188.kz,52145;Initial Catalog=scales;Persist Security Info=True;User ID=said;Password=1qaz!QAZ"




        */



}
