using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using MySql.Data.MySqlClient;
using Android.Widget;
using System;
using System.Collections.Generic;

namespace App1
{
    [Activity(Label = "Registro de Funcionários", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        MySqlConnection conexaoMySQL;
        MySqlConnectionStringBuilder servidor = new MySqlConnectionStringBuilder();

        public string StringConexao()
        {
            servidor.Server = "192.168.10.7";
            servidor.Database = "funcionarios";
            servidor.UserID = "root";
            servidor.Password = "";

            return servidor.ToString();
        }

        private void preenchelistview()
        {
            ListView listviewFUNCIONARIOS = FindViewById<ListView>(Resource.Id.listViewRECEITAS);
            List<string> listaFUNCIONARIOS = new List<string>();


            string StringConexaoMySQL = StringConexao();
            string consulta = "SELECT * FROM funcionarios";

            MySqlDataReader consultaReader = null;

            try
            {
                conexaoMySQL = new MySqlConnection(StringConexaoMySQL);
                conexaoMySQL.Open();

                MySqlCommand consultaComando = new MySqlCommand(consulta, conexaoMySQL);

                consultaReader = (MySqlDataReader)consultaComando.ExecuteReader();

                while (consultaReader.Read())
                {
                    listaFUNCIONARIOS.Add(consultaReader["nome"].ToString());
                }
            }
            catch
            {

            }
            finally
            {
                conexaoMySQL.Close();
            }
            ArrayAdapter<string> adapterFUNCIONARIOS = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, listaFUNCIONARIOS);
            listviewFUNCIONARIOS.Adapter = adapterFUNCIONARIOS;
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            Button PESQUISAR = FindViewById<Button>(Resource.Id.buttonPESQUISAR);
            Button CADASTRAR = FindViewById<Button>(Resource.Id.buttonCADASTRAR);
            EditText campoFUNCIONARIO = FindViewById<EditText>(Resource.Id.editTextNOMEFUNCIONARIO);
            RadioButton campoMASCULINO = FindViewById<RadioButton>(Resource.Id.radioButtonMASCULINO);
            RadioButton campoFEMININO = FindViewById<RadioButton>(Resource.Id.radioButtonFEMININO);
            EditText campoIDADE = FindViewById<EditText>(Resource.Id.editTextIDADE);
            EditText campoCARGO = FindViewById<EditText>(Resource.Id.textInputEditTextCARGO);

            string StringConexaoMySQL = StringConexao();


            //ListView
            preenchelistview();



            CADASTRAR.Click += delegate
            {
                string sexo = "";
                if (campoMASCULINO.Checked)
                {
                    sexo = "MASCULINO";
                }else
                {
                    sexo = "FEMININO";
                }

                string insere = "INSERT INTO funcionarios(nome, sexo, idade, cargo) VALUES ('" + campoFUNCIONARIO.Text + "',  '" + sexo + "',  '" + campoIDADE.Text + "',  '" + campoCARGO.Text + "')";
                               
                try
                {
                    conexaoMySQL = new MySqlConnection(StringConexaoMySQL);
                    conexaoMySQL.Open();
                    MySqlCommand insereComando = new MySqlCommand(insere, conexaoMySQL);


                    insereComando.ExecuteNonQuery();
                }
                catch
                {

                }
                finally
                {
                    conexaoMySQL.Close();
                }
                preenchelistview();
            };
            PESQUISAR.Click += delegate
            {
                StartActivity(typeof(ActivityPESQUISAR));
            };

        }


    }
}
