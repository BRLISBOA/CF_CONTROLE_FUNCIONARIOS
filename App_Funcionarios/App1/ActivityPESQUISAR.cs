using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace App1
{
    [Activity(Label = "ActivityPESQUISAR")]
    public class ActivityPESQUISAR : Activity
    {
        string CATEGORIA;
        string RESULTADOCARGOOUNOME;

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
            ListView listviewPESQUISA = FindViewById<ListView>(Resource.Id.listViewPESQUISA);
            List<string> listaPESQUISA = new List<string>();


            string StringConexaoMySQL = StringConexao();
            string consulta = "SELECT * FROM funcionarios WHERE " + RESULTADOCARGOOUNOME + " LIKE '%" + CATEGORIA + "%'";

            MySqlDataReader consultaReader = null;

            try
            {
                conexaoMySQL = new MySqlConnection(StringConexaoMySQL);
                conexaoMySQL.Open();

                MySqlCommand consultaComando = new MySqlCommand(consulta, conexaoMySQL);

                consultaReader = (MySqlDataReader)consultaComando.ExecuteReader();

                while (consultaReader.Read())
                {
                    listaPESQUISA.Add(consultaReader["nome"].ToString());
                }
            }
            catch
            {

            }
            finally
            {
                conexaoMySQL.Close();
            }
            ArrayAdapter<string> adapterPESQUISA = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, listaPESQUISA);
            listviewPESQUISA.Adapter = adapterPESQUISA;
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.layoutPESQUISAR);

            // Preencher list view
            preenchelistview();

            Button PESQUISA = FindViewById<Button>(Resource.Id.buttonPESQUISA);
            EditText RESULTADO = FindViewById<EditText>(Resource.Id.editTextPESQUISA);
            RadioButton CARGO = FindViewById<RadioButton>(Resource.Id.radioButtonCARGO);
            RadioButton NOME = FindViewById<RadioButton>(Resource.Id.radioButtonNOME);

            PESQUISA.Click += delegate
            {
                if (CARGO.Checked)
                {
                    RESULTADOCARGOOUNOME = "cargo";

                }
                else
                {
                    RESULTADOCARGOOUNOME = "nome";
                }

                CATEGORIA = RESULTADO.Text;
                preenchelistview();
            };
        }
    }
}